// <copyright file="XrmConfigData.cs" company="Ciber">
//     Company Copyright
// </copyright>
namespace Ciber.Xrm.Packages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Query;
    using Microsoft.Xrm.Tooling.Connector;


    /// <summary>
    /// XrmImportSystemData Class - used to import System Data (Users, Teams, Business Units, User Roles, Team Roles, Queues
    /// </summary>
    public class XrmImportSystemData
    {
        #region Properties
        /// <summary>
        /// Gets value for the Organization Service
        /// </summary>
        private CrmServiceClient crmServiceClient;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="XrmImportSystemData"/> class
        /// </summary>
        /// <param name="serviceClient">The CrmServiceClient object passed through from the Package Deployment context</param>
        #region Constructors
        public XrmImportSystemData(CrmServiceClient serviceClient)
        {
            this.crmServiceClient = serviceClient;
        }
        #endregion

        #region Methods

        public void UpdateSystemSettings(XElement systemSettingsXml)
        {
            var wmiRequest = new WhoAmIRequest();

            var wmiResponse = (WhoAmIResponse)this.crmServiceClient.ExecuteCrmOrganizationRequest(wmiRequest);

            var orgId = wmiResponse.OrganizationId;

            var retOrgRequest = new RetrieveRequest();
            var orgCols = new ColumnSet("dateformatstring", "timeformatstring", "localeid");
            retOrgRequest.ColumnSet = orgCols;
            retOrgRequest.Target = new EntityReference("organization", orgId);

            var org = ((RetrieveResponse)this.crmServiceClient.ExecuteCrmOrganizationRequest(retOrgRequest)).Entity;

            var updateOrgRequest = new UpdateRequest();

            org.Attributes["dateformatstring"] = systemSettingsXml.Element("DateFormat").Value;
            org.Attributes["timeformatstring"] = systemSettingsXml.Element("TimeFormat").Value;
            org.Attributes["localeid"] = int.Parse(systemSettingsXml.Element("LocaleId").Value);
            org.Attributes["isautosaveenabled"] = bool.Parse(systemSettingsXml.Element("AutoSave").Value);
            org.Attributes["isauditenabled"] = bool.Parse(systemSettingsXml.Element("AuditEnabled").Value);

            updateOrgRequest.Target = org;

            this.crmServiceClient.ExecuteCrmOrganizationRequest(updateOrgRequest);

        }

        public void UpdateUserDataFormat(XElement systemSettingsXml)
        {
            var wmiRequest = new WhoAmIRequest();

            var wmiResponse = (WhoAmIResponse)this.crmServiceClient.ExecuteCrmOrganizationRequest(wmiRequest);

            var retUserSettingsRequest = new RetrieveRequest();
            var userCols = new ColumnSet("dateformatstring", "timeformatstring", "localeid");
            retUserSettingsRequest.ColumnSet = userCols;
            retUserSettingsRequest.Target = new EntityReference("usersettings", wmiResponse.UserId);

            var userSettings = ((RetrieveResponse)this.crmServiceClient.ExecuteCrmOrganizationRequest(retUserSettingsRequest)).Entity;

            var updateUserSettingsRequest = new UpdateRequest();

            userSettings.Attributes["dateformatstring"] = systemSettingsXml.Element("DateFormat").Value;
            userSettings.Attributes["timeformatstring"] = systemSettingsXml.Element("TimeFormat").Value;
            userSettings.Attributes["localeid"] = int.Parse(systemSettingsXml.Element("LocaleId").Value);

            updateUserSettingsRequest.Target = userSettings;

            this.crmServiceClient.ExecuteCrmOrganizationRequest(updateUserSettingsRequest);

        }

        /// <summary>
        /// Imports the business units specified in the XElement provided
        /// </summary>
        /// <param name="businessUnitData">XElement comprising of the Business Unit data</param>
        public void ImportBusinessUnits(XElement businessUnitData)
        {
            var businessUnits = from item in businessUnitData.Descendants("BusinessUnit")
                                select new
                                {
                                    BusinessUnitName = item.Attribute("name").Value,
                                    ParentBusinessUnit = item.Element("ParentBusinessUnit").Value
                                };

            foreach (var bu in businessUnits)
            {
                this.CreateBusinessUnit(bu.ParentBusinessUnit.ToString(), bu.BusinessUnitName.ToString());
            }
        }

        /// <summary>
        /// Import  the users specified in the XElement provided
        /// </summary>
        /// <param name="systemUserData">XElement comprising of the System User data</param>
        public void ImportUsers(XElement systemUserData)
        {
            var systemUsers = from item in systemUserData.Descendants("SystemUser")
                              select new
                              {
                                  DomainName = item.Attribute("domainname").Value,
                                  FirstName = item.Element("FirstName").Value,
                                  LastName = item.Element("LastName").Value,
                                  BusinessUnit = item.Element("BusinessUnit").Value,
                                  Email = item.Element("Email").Value,
                                  Telephone = item.Element("Telephone").Value,
                                  Manager = item.Element("Manager").Value,
                                  Title = item.Element("Title").Value,
                                  AccessMode = int.Parse(item.Element("AccessMode").Value),
                                  LicenseType = int.Parse(item.Element("LicenseType").Value),
                                  Roles = item.Element("Roles")
                              };

            foreach (var su in systemUsers)
            {
                Entity entSystemUser = new Entity("systemuser");
                entSystemUser.Attributes["domainname"] = su.DomainName.ToString();
                entSystemUser.Attributes["firstname"] = su.FirstName.ToString();
                entSystemUser.Attributes["lastname"] = su.LastName.ToString();
                entSystemUser.Attributes["businessunitid"] = new EntityReference("businessunit", this.GetBusinessUnitId(su.BusinessUnit.ToString()));
                entSystemUser.Attributes["internalemailaddress"] = su.Email.ToString();
                entSystemUser.Attributes["address1_telephone1"] = su.Telephone.ToString();
                entSystemUser.Attributes["title"] = su.Title.ToString();
                entSystemUser.Attributes["accessmode"] = new OptionSetValue(su.AccessMode);
                entSystemUser.Attributes["caltype"] = new OptionSetValue(su.LicenseType);
                if (su.Manager != null && su.Manager != string.Empty)
                {
                    entSystemUser.Attributes["sfa_manager"] = new EntityReference("systemuser", this.GetSystemUserId(su.Manager.ToString()));
                }

                try
                {
                    Guid sysUserGuid = this.CreateSystemUser(entSystemUser, su.BusinessUnit.ToString(), su.Roles);
                }
                catch { }
            }
        }

        /// <summary>
        /// Import  the users specified in the XElement provided
        /// </summary>
        /// <param name="systemUserData">XElement comprising of the System User data</param>
        public void UpdateUsers(XElement systemUserData)
        {
            var systemUsers = from item in systemUserData.Descendants("SystemUser")
                              select new
                              {
                                  DomainName = item.Attribute("domainname").Value,
                                  PrimaryRole = item.Element("PrimaryRole").Value,
                              };

            foreach (var su in systemUsers.Where(s => s.PrimaryRole != string.Empty))
            {
                System.Diagnostics.Debug.Print(su.PrimaryRole);
                Entity entSystemUser = new Entity("systemuser")
                {
                    Id = this.GetSystemUserId(su.DomainName.ToString())
                };

                if (su.PrimaryRole != null && su.PrimaryRole != string.Empty)
                {
                    entSystemUser.Attributes["sfa_primaryrole"] = new EntityReference("team", this.GetTeamId(su.PrimaryRole.ToString()));
                }
                try
                {
                    this.UpdateSystemUser(entSystemUser);
                }
                catch { }
            }
        }

        //
        public void UpdateStatuses(XElement statusesData)
        {
            var statuses = from item in statusesData.Descendants("Status")
                           select new
                           {
                               Name = item.Element("Name").Value,
                               DefaultBulkAction = item.Element("DefaultBulkAction").Value
                           };

            foreach (var s in statuses)
            {
                List<CrmServiceClient.CrmSearchFilter> searchParameters = new List<CrmServiceClient.CrmSearchFilter>();

                var searchConditions = new List<CrmServiceClient.CrmFilterConditionItem>();
                searchConditions.Add(new CrmServiceClient.CrmFilterConditionItem()
                {
                    FieldName = "sfa_name",
                    FieldOperator = ConditionOperator.Equal,
                    FieldValue = s.Name
                });

                searchParameters.Add(new CrmServiceClient.CrmSearchFilter()
                {
                    FilterOperator = LogicalOperator.And,
                    SearchConditions = searchConditions
                });

                var data = this.crmServiceClient.GetEntityDataBySearchParams("sfa_status",
                    searchParameters,
                    CrmServiceClient.LogicalSearchOperator.And,
                    new List<string>() { "sfa_name", "sfa_statusid" });

                foreach (var pair in data)
                {
                    //base.PackageLog.Log("Import Complete.");
                    Console.WriteLine("Key {0} Value {1}", pair.Key, pair.Value);
                }
                var oid = data.Where(x => x.Key.Equals("sfa_statusid")).FirstOrDefault().Value;

                Guid id = Guid.Parse(oid.ToString());

                var updateData = new Dictionary<string, CrmDataTypeWrapper>();

                updateData.Add("sfa_defaultbulkaction", new CrmDataTypeWrapper(s.DefaultBulkAction, CrmFieldType.String));

                bool updateStatus = this.crmServiceClient.UpdateEntity("sfa_status", "sfa_statusid", id, updateData);

                if (updateStatus == true)
                {

                }
            }
        }

        /// <summary>
        /// Import the teams specified in the XElement data
        /// </summary>
        /// <param name="teamData">XElement comprising of the teams data</param>
        public void ImportTeams(XElement teamData)
        {
            var teams = from item in teamData.Descendants("Team")
                        select new
                        {
                            TeamName = item.Attribute("name").Value,
                            BusinessUnit = item.Element("BusinessUnit").Value,
                            Manager = item.Element("Manager").Value,
                            Description = item.Element("Description").Value,
                            Members = item.Element("Members"),
                            Roles = item.Element("Roles")
                        };

            foreach (var t in teams)
            {
                Guid newTeamGuid = this.CreateTeam(t.BusinessUnit.ToString(), t.TeamName.ToString(), t.Manager.ToString(), t.Members, t.Roles);
            }
        }

        /// <summary>
        /// Import the teams specified in the XElement data
        /// </summary>
        /// <param name="teamData">XElement comprising of the teams data</param>
        public void UpdateTransitions(XElement transitionsData)
        {
            var transitions =
                from item in transitionsData.Descendants("TransitionRecord")
                select new
                {
                    Name = item.Element("Name").Value,
                    ManagersTeam = item.Element("ManagersTeam").Value,
                    Owner = item.Element("Owner").Value,

                };

            foreach (var t in transitions)
            {
                this.UpdateTransition(t.Name.ToString(), t.ManagersTeam.ToString(), t.Owner.ToString());
            }
        }

        /// <summary>
        /// Import the Queues specified in the XElement Data
        /// </summary>
        /// <param name="queueData">An XElement object representing the Queue Data</param>
        public void ImportQueues(XElement queueData)
        {
            try
            {
                var queues = from item in queueData.Descendants("Queue")
                             select new
                             {
                                 QueueName = item.Attribute("name").Value,
                                 ViewType = item.Element("ViewType").Value,
                                 Description = item.Element("Description").Value,
                                 Email = item.Element("Email").Value,
                                 FileringMethod = item.Element("FilteringMethod").Value
                             };

                foreach (var q in queues)
                {
                    Entity entQueue = new Entity("queue");
                    entQueue.Attributes["name"] = q.QueueName;
                    entQueue.Attributes["queueviewtype"] = new OptionSetValue(int.Parse(q.ViewType));
                    entQueue.Attributes["description"] = q.Description;
                    entQueue.Attributes["emailaddress"] = q.Email;
                    entQueue.Attributes["incomingemailfilteringmethod"] = new OptionSetValue(int.Parse(q.FileringMethod));

                    Guid newTeamGuid = this.CreateQueue(entQueue);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error While retrieving Importing Queues: " + ex.Message);
            }
        }

        /// <summary>
        /// Deactivate Views specified in the XElement Data
        /// </summary>
        /// <param name="queueData">An XElement object representing the System Views to be deactivated</param>
        public void DeactivateViews(XElement viewData)
        {
            try
            {
                foreach (var v in viewData.Descendants("View"))
                {
                    bool updateViewStatus = this.crmServiceClient.UpdateStateAndStatusForEntity("savedquery", new Guid(v.Attribute("id").Value), 1, 2);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error While retrieving Deactivating Views: " + ex.Message);
            }
        }

        /// <summary>
        /// Get the record from the specified filter criteria
        /// </summary>
        /// <param name="filterField">Filter to be applied</param>
        /// <param name="queryField">Field to be queried by filter</param>
        /// <param name="entityType">Logical name of the entity</param>
        /// <param name="returnColumnName">Return column name (ID)</param>
        /// <returns>The Guid of the record</returns>
        public Guid GetRecordId(string filterField, string queryField, string entityType, string returnColumnName)
        {
            try
            {
                // Checks whether the Record NAme is null or zero length
                if (filterField != null && filterField.Length > 0)
                {
                    QueryByAttribute qba = new QueryByAttribute(entityType);

                    qba.AddAttributeValue(queryField, filterField);

                    // Values need to be retrieved is the Guid of the entity requested
                    qba.ColumnSet = new ColumnSet(true); //returnColumnName, "createdon");

                    DataCollection<Entity> recordDetails;

                    RetrieveMultipleRequest request = new RetrieveMultipleRequest();
                    request.Query = qba;

                    EntityCollection entCol = (this.crmServiceClient.ExecuteCrmOrganizationRequest(request) as RetrieveMultipleResponse).EntityCollection;

                    // Retrieve the value based on the condition given
                    recordDetails = entCol.Entities;

                    // Return the Guid of the record
                    if (recordDetails.Count == 1)
                    {
                        if (recordDetails[0] != null)
                        {
                            if (recordDetails[0].Id != null)
                            {
                                return new Guid(recordDetails[0].Id.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error While retrieving Guid of entity " + entityType + ": " + ex.Message);
            }

            return Guid.Empty;
        }

        /// <summary>
        /// Overloaded method to filter by two parameters (used for looking up user roles by name and BU)
        /// </summary>
        /// <param name="filterField1">First filter</param>
        /// <param name="queryField1">Field to be queried by first filter</param>
        /// <param name="entityType">Logical name of the entity</param>
        /// <param name="returnColumnName">Return column name (ID)</param>
        /// <param name="filterField2">Second filter</param>
        /// <param name="queryField2">Field to be queried by second filter</param>
        /// <returns>The guid of the record</returns>
        public Guid GetRecordId(string filterField1, string queryField1, string entityType, string returnColumnName, string filterField2, string queryField2)
        {
            try
            {
                // Checks whether the Record Name is null or zero length
                if (filterField1 != null && filterField1.Length > 0 && filterField2 != null && filterField2.Length > 0)
                {
                    QueryByAttribute qba = new QueryByAttribute(entityType);

                    // Condition parameters
                    qba.AddAttributeValue(queryField1, filterField1);

                    // Second condiiton parameter - used for Business Unit filtering
                    qba.AddAttributeValue(queryField2, this.GetBusinessUnitId(filterField2));

                    // Value need to be retrieved is the Guid of Record
                    qba.ColumnSet = new ColumnSet(returnColumnName, "createdon");

                    DataCollection<Entity> recordDetails;

                    RetrieveMultipleRequest request = new RetrieveMultipleRequest();
                    request.Query = qba;

                    EntityCollection entCol = (this.crmServiceClient.ExecuteCrmOrganizationRequest(request) as RetrieveMultipleResponse).EntityCollection;

                    // Retrieve the value based on the condition given
                    recordDetails = entCol.Entities;

                    // Return the Guid of the record
                    if (recordDetails.Count == 1)
                    {
                        if (recordDetails[0] != null)
                        {
                            if (recordDetails[0].Id != null)
                            {
                                return new Guid(recordDetails[0].Id.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error While retrieving Guid of entity " + entityType + ": " + ex.Message);
            }

            return Guid.Empty;
        }

        /// <summary>
        /// Retrieve business unit ID by business unit name
        /// </summary>
        /// <param name="businessUnitName">The name of the business unit</param>
        /// <returns>The business unit guid</returns>
        public Guid GetBusinessUnitId(string businessUnitName)
        {
            try
            {
                return this.GetRecordId(businessUnitName, "name", "businessunit", "businessunitid");
            }
            catch (Exception ex)
            {
                throw new Exception("Error While retrieving Guid of Business Unit " + ex.Message);
            }

            return Guid.Empty;
        }

        /// <summary>
        /// Retrieve system user id by domain name
        /// </summary>
        /// <param name="strDomainName">The Domain Name (DOMAIN\LOGON) of the system user</param>
        /// <returns>THe system user guid</returns>
        public Guid GetSystemUserId(string strDomainName)
        {
            try
            {
                return this.GetRecordId(strDomainName, "domainname", "systemuser", "systemuserid");
            }
            catch (Exception ex)
            {
                throw new Exception("Error While retrieving Guid of User " + ex.Message);
            }

            return Guid.Empty;
        }

        /// <summary>
        /// Retrieve Queue id by name
        /// </summary>
        /// <param name="strQueueName">The name of the queue</param>
        /// <returns>The queue guid</returns>
        public Guid GetQueueId(string strQueueName)
        {
            try
            {
                return this.GetRecordId(strQueueName, "name", "queue", "queueid");
            }
            catch (Exception ex)
            {
                throw new Exception("Error While retrieving Guid of User " + ex.Message);
            }

            return Guid.Empty;
        }

        /// <summary>
        /// Retrieve Security Role by business unit and name
        /// </summary>
        /// <param name="strRoleName">The name of the security role</param>
        /// <param name="strBusinessUnitName">The name of the business unit</param>
        /// <returns>The security role guid</returns>
        public Guid GetRoleId(string strRoleName, string strBusinessUnitName)
        {
            try
            {
                return this.GetRecordId(strRoleName, "name", "role", "roleid", strBusinessUnitName, "businessunitid");
            }
            catch (Exception ex)
            {
                throw new Exception("Error While retrieving Guid of Role " + ex.Message);
            }

            return Guid.Empty;
        }

        /// <summary>
        /// Retrieve Team by name
        /// </summary>
        /// <param name="strTeamName">The name of the team</param>
        /// <returns>The team guid</returns>
        public Guid GetTeamId(string strTeamName)
        {
            try
            {
                return this.GetRecordId(strTeamName, "name", "team", "teamid");
            }
            catch (Exception ex)
            {
                throw new Exception("Error While retrieving Guid of Team " + ex.Message);
            }

            return Guid.Empty;
        }

        /// <summary>
        /// Creates a business unit with the specified name and parent business unit
        /// </summary>
        /// <param name="strParentName">Name of the parent business unit</param>
        /// <param name="strName">Name of the business unit</param>
        /// <returns>The guid of the newly created business unit</returns>
        public Guid CreateBusinessUnit(string strParentName, string strName)
        {
            try
            {
                Entity e = new Entity("businessunit");
                e.Attributes["name"] = strName;

                // Check for the valid Guid. If it is not a guid retrieve the guid based on the name of the business unit
                Guid parentGuid = this.GetBusinessUnitId(strParentName);

                // If Guid Exists then place it into the ParentBusinessUnitId lookup field of BusinessUnit entity
                if (parentGuid != Guid.Empty)
                {
                    EntityReference refParentBusinessUnit = new EntityReference("businessunit", parentGuid);
                    e.Attributes["parentbusinessunitid"] = refParentBusinessUnit;
                }

                CreateRequest request = new CreateRequest();
                request.Target = e;
                CreateResponse response = (CreateResponse)this.crmServiceClient.ExecuteCrmOrganizationRequest(request);

                // Create Business Unit
                Guid businessUnitGuid = response.id;

                return businessUnitGuid;
            }
            catch (Exception ex)
            {
                throw new Exception("Error While Creating a Business Unit :  " + strName + ". Error Message: " + ex.Message);
            }

            return Guid.Empty;
        }

        /// <summary>
        /// Creates a system user with the details specified in the entity parameter, in the business unit specified. 
        /// </summary>
        /// <param name="userEntity">An entity object corresponding to the system user to be created</param>
        /// <param name="businessUnit">The name of the users business unit</param>
        /// <param name="roles">The roles to be assigned to the user</param>
        /// <returns>The guid of the newly created business unit</returns>
        public Guid CreateSystemUser(Entity userEntity, string businessUnit, XElement roles)
        {
            try
            {
                CreateRequest request = new CreateRequest();

                request.Target = userEntity;
                CreateResponse response = (CreateResponse)this.crmServiceClient.ExecuteCrmOrganizationRequest(request);
                Guid systemUserGuid;
                if (this.crmServiceClient.LastCrmException != null)
                {
                    if ((crmServiceClient.LastCrmException.Message != "An object with the specified name already exists.")
                        && (crmServiceClient.LastCrmException.Message != "The specified Active Directory user already exists as a CRM user."))
                    {
                        throw this.crmServiceClient.LastCrmException;
                    }

                    systemUserGuid = this.GetRecordId(userEntity.Attributes["domainname"].ToString(), "domainname",
                        "systemuser", "systemuserid");
                }
                else
                {
                    // Create System User
                    systemUserGuid = response.id;

                }

                // Import Roles for User - Pass System User and BU Guid and Roles collection
                this.CreateRolesForUser(systemUserGuid, userEntity.Attributes["domainname"].ToString(), businessUnit, roles);

                return systemUserGuid;

            }
            catch (Exception ex)
            {
                throw new Exception("Error While creating system user " + userEntity.Attributes["domainname"] + " - " + ex.Message);
            }

            return Guid.Empty;
        }

        /// <summary>
        /// Updates a system user with the details specified in the entity parameter, in the business unit specified. 
        /// </summary>
        /// <param name="userEntity">An entity object corresponding to the system user to be created</param>
        /// <param name="businessUnit">The name of the users business unit</param>
        /// <param name="roles">The roles to be assigned to the user</param>
        /// <returns>The guid of the newly created business unit</returns>
        public void UpdateSystemUser(Entity userEntity)
        {
            var request = new UpdateRequest()
            {
                Target = userEntity
            };
            var response = (UpdateResponse)this.crmServiceClient.ExecuteCrmOrganizationRequest(request);
        }

        /// <summary>
        /// Updates a system user with the details specified in the entity parameter, in the business unit specified. 
        /// </summary>
        /// <param name="userEntity">An entity object corresponding to the system user to be created</param>
        /// <param name="businessUnit">The name of the users business unit</param>
        /// <param name="roles">The roles to be assigned to the user</param>
        /// <returns>The guid of the newly created business unit</returns>
        public void UpdateTransition(string transitionName, string managersTeam, string ownerTeam)
        {
            var transitionId = this.GetRecordId(transitionName, "sfa_name", "sfa_transition", "sfa_transitionid");

            var managersTeamId = this.GetRecordId(managersTeam, "name", "team", "teamid");
            var ownerTeamId = this.GetRecordId(ownerTeam, "name", "team", "teamid");

            AssignRequest assignRequest = new AssignRequest
            {
                Assignee = new EntityReference("team", ownerTeamId),
                Target = new EntityReference("sfa_transition", transitionId)
            };
            var response = (AssignResponse)this.crmServiceClient.ExecuteCrmOrganizationRequest(assignRequest);

            Entity entity = new Entity("sfa_transition")
            {
                Id = transitionId,
                Attributes = new AttributeCollection()
            };
            entity.Attributes.Add("sfa_managersteam", new Microsoft.Xrm.Sdk.EntityReference("team", managersTeamId));

            var request = new UpdateRequest()
            {
                Target = entity
            };
            var response2 = (UpdateResponse)this.crmServiceClient.ExecuteCrmOrganizationRequest(request);

        }

        /// <summary>
        /// Assigns appropriate roles to the system user specified 
        /// </summary>
        /// <param name="systemUser">The guid of the system user</param>
        /// <param name="systemUserName">The domain name of the system user</param>
        /// <param name="businessUnit">The business unit of the system user</param>
        /// <param name="systemUserRoleData">An XElement consisting of the user roles to be assigned</param>
        public void CreateRolesForUser(Guid systemUser, string systemUserName, string businessUnit, XElement systemUserRoleData)
        {
            try
            {
                EntityReferenceCollection roles = new EntityReferenceCollection();

                var systemUserRoles = from item in systemUserRoleData.Descendants("Role")
                                      select new EntityReference("role", this.GetRoleId(item.Attribute("name").Value, businessUnit));

                foreach (var sur in systemUserRoles)
                {
                    roles.Add(sur);
                }

                AssociateRequest associateRequest = new AssociateRequest();
                associateRequest.Target = new EntityReference("systemuser", systemUser);
                associateRequest.Relationship = new Relationship("systemuserroles_association");
                associateRequest.RelatedEntities = roles;

                AssociateResponse associateResponse = (AssociateResponse)this.crmServiceClient.ExecuteCrmOrganizationRequest(associateRequest);
            }
            catch (Exception ex)
            {
                throw new Exception("Error While associating system user roles for user: " + systemUserName + " - " + ex.Message);
            }
        }

        /// <summary>
        /// Assigns designated roles for a team
        /// </summary>
        /// <param name="team">The Guid of the team</param>
        /// <param name="businessUnit">The name of the teams business unit</param>
        /// <param name="teamRoleData">An XElement object consisting of the roles to be assigned</param>
        public void CreateRolesForTeam(Guid team, string businessUnit, XElement teamRoleData)
        {
            try
            {
                EntityReferenceCollection roles = new EntityReferenceCollection();

                var teamRoles = from item in teamRoleData.Descendants("Role")
                                select new EntityReference("role", this.GetRoleId(item.Attribute("name").Value, businessUnit));

                foreach (var sur in teamRoles)
                {
                    roles.Add(sur);
                }

                AssociateRequest associateRequest = new AssociateRequest();
                associateRequest.Target = new EntityReference("team", team);
                associateRequest.Relationship = new Relationship("teamroles_association");
                associateRequest.RelatedEntities = roles;

                AssociateResponse associateResponse = (AssociateResponse)this.crmServiceClient.ExecuteCrmOrganizationRequest(associateRequest);
            }
            catch (Exception ex)
            {
                throw new Exception("Error While associating team roles " + ex.Message);
            }
        }

        /// <summary>
        /// Creates a new team based on the parameters provided
        /// </summary>
        /// <param name="strBUName">Name of the business unit</param>
        /// <param name="strTeamName">Name of the team</param>
        /// <param name="administratorName">Domain name of the teams administrator</param>
        /// <param name="teamMembers">An XElement consisting of of the members of the team</param>
        /// <param name="teamRoles">An XElement consisting of the roles to be assigned to the team</param>
        /// <returns>The guid of the newly created team</returns>
        private Guid CreateTeam(string strBUName, string strTeamName, string administratorName, XElement teamMembers, XElement teamRoles)
        {
            Entity e = new Entity("team");
            e.Attributes["name"] = strTeamName;
            e.Attributes["administratorid"] = new EntityReference("systemuser", this.GetSystemUserId(administratorName));
            e.Attributes["businessunitid"] = new EntityReference("businessunit", this.GetBusinessUnitId(strBUName));
            e.Attributes["teamtype"] = new OptionSetValue(0);

            CreateRequest request = new CreateRequest()
            {
                Target = e
            };
            CreateResponse response = (CreateResponse)this.crmServiceClient.ExecuteCrmOrganizationRequest(request);

            // Create Team
            Guid teamId;

            if (this.crmServiceClient.LastCrmException != null)
            {
                if (crmServiceClient.LastCrmException.Message != "An object with the specified name already exists." &&
                    crmServiceClient.LastCrmException.Message != "The specified Active Directory user already exists as a CRM user")
                {
                    throw this.crmServiceClient.LastCrmException;
                }

                teamId = this.GetRecordId(strTeamName, "name", "team", "teamid");
            }
            else
            {
                teamId = response.id;
            }
            Guid[] membersId = (from item in teamMembers.Descendants("Member")
                                select this.GetSystemUserId(item.Attribute("domainname").Value)).ToArray();

            AddMembersTeamRequest addTeamRequest = new AddMembersTeamRequest();

            // Associate Guid 
            addTeamRequest.TeamId = teamId;

            // Assocate Member Array
            addTeamRequest.MemberIds = membersId;

            // Execute request
            this.crmServiceClient.ExecuteCrmOrganizationRequest(addTeamRequest);

            this.CreateRolesForTeam(teamId, strBUName, teamRoles);

            return teamId;
        }

        /// <summary>
        /// Creates a new team based on the parameters provided
        /// </summary>
        /// <param name="strTeamName">Name of the team</param>
        /// <param name="teamMembers">An XElement consisting of of the members of the team</param>
        /// <returns>The guid of the newly created team</returns>
        public Guid CreateTeamMembers(string strTeamName, XElement teamMembers)
        {
            try
            {
                var qba = new QueryByAttribute("team");
                qba.AddAttributeValue("name", strTeamName);

                // Values need to be retrieved is the Guid of the entity requested
                qba.ColumnSet = new ColumnSet("teamid");

                DataCollection<Entity> recordDetails;

                var request = new RetrieveMultipleRequest()
                {
                    Query = qba
                };

                EntityCollection entCol = (this.crmServiceClient.ExecuteCrmOrganizationRequest(request) as RetrieveMultipleResponse).EntityCollection;

                // Retrieve the value based on the condition given
                recordDetails = entCol.Entities;

                // Return the Guid of the record
                if (recordDetails.Count > 0)
                {
                    foreach (var team in recordDetails)
                    {
                        // Create Team
                        Guid teamId = team.Id;

                        Guid[] membersId = (from item in teamMembers.Descendants("Member")
                                            select this.GetSystemUserId(item.Attribute("domainname").Value)).ToArray();

                        AddMembersTeamRequest addTeamRequest = new AddMembersTeamRequest();

                        // Associate Guid 
                        addTeamRequest.TeamId = teamId;

                        // Assocate Member Array
                        addTeamRequest.MemberIds = membersId;

                        // Execute request
                        this.crmServiceClient.ExecuteCrmOrganizationRequest(addTeamRequest);
                    }
                }
                // return teamId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error While Creating a Team:  " + strTeamName + ". Error Message: " + ex.Message);
                //Console.WriteLine("Error While Creating a Team:  " + strTeamName + ". Error Message: " + ex.Message);
            }

            return Guid.Empty;
        }

        /// <summary>
        /// Creates a queue based on the name provided
        /// </summary>
        /// <param name="queue">An entity object representing the queue to be created</param>
        /// <returns>The guid of the newly created queue</returns>
        public Guid CreateQueue(Entity queue)
        {
            try
            {
                CreateRequest request = new CreateRequest();
                request.Target = queue;
                CreateResponse response = (CreateResponse)this.crmServiceClient.ExecuteCrmOrganizationRequest(request);
                Guid queueId = new Guid();
                if (this.crmServiceClient.LastCrmException != null)
                {
                    if (crmServiceClient.LastCrmException.Message != "An object with the specified name already exists.")
                    {
                        throw this.crmServiceClient.LastCrmException;
                    }

                    // teamId = this.GetRecordId(strTeamName, "name", "team", "teamid");
                }
                else
                {
                    // Create Queue
                    queueId = response.id;
                }
                return queueId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error While creating Queue: " + queue.Attributes["name"] + " - " + ex.Message);
            }

            return Guid.Empty;
        }

        #endregion
    }
}
