// =====================================================================
//  File:       ErrorCodes.cs
//  Summary:    Contains helper types for building queries.
// =====================================================================
//
//  This file is part of the Microsoft CRM 2011 SDK Code Samples.
//
//  Copyright (C) 2007 Microsoft Corporation.  All rights reserved.
//
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
//
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//
// =====================================================================

namespace Ciber.Xrm.Common
{
    using System.Collections;

    public static class XrmErrorCodes
    {
        public const int CannotUpdateOrgDbOrgSettingWhenOffline = unchecked((int)0x80048515); // -2147187435
        public const int InvalidOrgDbOrgSetting = unchecked((int)0x80048514); // -2147187436
        public const int UnknownInvalidTransformationParameterGeneric = unchecked((int)0x80048513); // -2147187437
        public const int InvalidTransformationParameterOutsideRangeGeneric = unchecked((int)0x80048512); // -2147187438
        public const int InvalidTransformationParameterEmptyCollection = unchecked((int)0x80048511); // -2147187439
        public const int InvalidTransformationParameterOutsideRange = unchecked((int)0x80048510); // -2147187440
        public const int InvalidTransformationParameterZeroToRange = unchecked((int)0x80048509); // -2147187447
        public const int InvalidTransformationParameterString = unchecked((int)0x80048508); // -2147187448
        public const int InvalidTransformationParametersGeneric = unchecked((int)0x80048507); // -2147187449
        public const int InsufficientTransformationParameters = unchecked((int)0x80048506); // -2147187450
        public const int MaximumNumberHandlersExceeded = unchecked((int)0x80048505); // -2147187451
        public const int ErrorInUnzipAlternate = unchecked((int)0x80048503); // -2147187453
        public const int IncorrectSingleFileMultipleEntityMap = unchecked((int)0x80048502); // -2147187454
        public const int ActivityEntityCannotBeActivityParty = unchecked((int)0x80048501); // -2147187455
        public const int TargetAttributeInvalidForIgnore = unchecked((int)0x80048500); // -2147187456
        public const int MaxUnzipFolderSizeExceeded = unchecked((int)0x80048499); // -2147187559
        public const int InvalidMultipleMapping = unchecked((int)0x80048498); // -2147187560
        public const int ErrorInStoringImportFile = unchecked((int)0x80048497); // -2147187561
        public const int UnzipTimeout = unchecked((int)0x80048496); // -2147187562
        public const int UnsupportedZipFileForImport = unchecked((int)0x80048495); // -2147187563
        public const int UnzipProcessCountLimitReached = unchecked((int)0x80048494); // -2147187564
        public const int AttachmentNotFound = unchecked((int)0x80048493); // -2147187565
        public const int TooManyPicklistValues = unchecked((int)0x80048492); // -2147187566
        public const int VeryLargeFileInZipImport = unchecked((int)0x80048491); // -2147187567
        public const int InvalidAttachmentsFolder = unchecked((int)0x80048490); // -2147187568
        public const int ZipInsideZip = unchecked((int)0x80048489); // -2147187575
        public const int InvalidZipFileFormat = unchecked((int)0x80048488); // -2147187576
        public const int EmptyFileForImport = unchecked((int)0x80048487); // -2147187577
        public const int EmptyFilesInZip = unchecked((int)0x80048486); // -2147187578
        public const int ZipFileHasMixOfCsvAndXmlFiles = unchecked((int)0x80048485); // -2147187579
        public const int DuplicateFileNamesInZip = unchecked((int)0x80048484); // -2147187580
        public const int ErrorInUnzip = unchecked((int)0x80048483); // -2147187581
        public const int InvalidZipFileForImport = unchecked((int)0x80048482); // -2147187582
        public const int InvalidLookupMapNode = unchecked((int)0x80048481); // -2147187583
        public const int ImportMailMergeTemplateEntityMissingError = unchecked((int)0x80048480); // -2147187584
        public const int CannotUpdateOpportunityCurrency = unchecked((int)0x80048479); // -2147187591
        public const int ParentRecordAlreadyExists = unchecked((int)0x80048478); // -2147187592
        public const int MissingWebToLeadRedirect = unchecked((int)0x80048477); // -2147187593
        public const int InvalidWebToLeadRedirect = unchecked((int)0x80048476); // -2147187594
        public const int TemplateNotAllowedForInternetMarketing = unchecked((int)0x80048475); // -2147187595
        public const int CopyNotAllowedForInternetMarketing = unchecked((int)0x80048474); // -2147187596
        public const int MissingOrInvalidRedirectId = unchecked((int)0x80048473); // -2147187597
        public const int ImportNotComplete = unchecked((int)0x80048472); // -2147187598
        public const int UiDataMissingInWorkflow = unchecked((int)0x80048471); // -2147187599
        public const int RefEntityRelationshipRoleRequired = unchecked((int)0x80048470); // -2147187600
        public const int ImportTemplateLanguageIgnored = unchecked((int)0x8004847a); // -2147187590
        public const int ImportTemplatePersonalIgnored = unchecked((int)0x8004847b); // -2147187589
        public const int ImportComponentDeletedIgnored = unchecked((int)0x8004847c); // -2147187588
        public const int RelationshipRoleNodeNumberInvalid = unchecked((int)0x80048469); // -2147187607
        public const int AssociationRoleOrdinalInvalid = unchecked((int)0x80048468); // -2147187608
        public const int RelationshipRoleMismatch = unchecked((int)0x80048467); // -2147187609
        public const int ImportMapInUse = unchecked((int)0x80048465); // -2147187611
        public const int PreviousOperationNotComplete = unchecked((int)0x80048464); // -2147187612
        public const int TransformationResumeNotSupported = unchecked((int)0x80048463); // -2147187613
        public const int CannotDisableDuplicateDetection = unchecked((int)0x80048462); // -2147187614
        public const int TargetEntityNotMapped = unchecked((int)0x80048460); // -2147187616
        public const int BulkDeleteChildFailure = unchecked((int)0x80048459); // -2147187623
        public const int CannotRemoveNonListMember = unchecked((int)0x80048458); // -2147187624
        public const int JobNameIsEmptyOrNull = unchecked((int)0x80048457); // -2147187625
        public const int ImportMailMergeTemplateError = unchecked((int)0x80048456); // -2147187626
        public const int ErrorsInWorkflowDefinition = unchecked((int)0x80048455); // -2147187627
        public const int DistributeNoListAssociated = unchecked((int)0x80048454); // -2147187628
        public const int DistributeListAssociatedVary = unchecked((int)0x80048453); // -2147187629
        public const int OfflineFilterParentDownloaded = unchecked((int)0x80048451); // -2147187631
        public const int OfflineFilterNestedDateTimeOr = unchecked((int)0x80048450); // -2147187632
        public const int DuplicateOfflineFilter = unchecked((int)0x80048449); // -2147187639
        public const int CannotAssignAddressBookFilters = unchecked((int)0x80048448); // -2147187640
        public const int CannotCreateAddressBookFilters = unchecked((int)0x80048447); // -2147187641
        public const int CannotGrantAccessToAddressBookFilters = unchecked((int)0x80048446); // -2147187642
        public const int CannotModifyAccessToAddressBookFilters = unchecked((int)0x80048445); // -2147187643
        public const int CannotRevokeAccessToAddressBookFilters = unchecked((int)0x80048444); // -2147187644
        public const int DuplicateMapName = unchecked((int)0x80048443); // -2147187645
        public const int InvalidWordXmlFile = unchecked((int)0x80048441); // -2147187647
        public const int FileNotFound = unchecked((int)0x80048440); // -2147187648
        public const int MultipleFilesFound = unchecked((int)0x80048439); // -2147187655
        public const int InvalidAttributeMapping = unchecked((int)0x80048438); // -2147187656
        public const int FileReadError = unchecked((int)0x80048437); // -2147187657
        public const int ViewForDuplicateDetectionNotDefined = unchecked((int)0x80048838); // -2147186632
        public const int FileInUse = unchecked((int)0x80048837); // -2147186633
        public const int NoPublishedDuplicateDetectionRules = unchecked((int)0x80048436); // -2147187658
        public const int NoEntitiesForBulkDelete = unchecked((int)0x80048442); // -2147187646
        public const int BulkDeleteRecordDeletionFailure = unchecked((int)0x80048435); // -2147187659
        public const int RuleAlreadyPublishing = unchecked((int)0x80048434); // -2147187660
        public const int RuleNotFound = unchecked((int)0x80048433); // -2147187661
        public const int CannotDeleteSystemEmailTemplate = unchecked((int)0x80048432); // -2147187662
        public const int EntityDupCheckNotSupportedSystemWide = unchecked((int)0x80048431); // -2147187663
        public const int DuplicateDetectionNotSupportedOnAttributeType = unchecked((int)0x80048430); // -2147187664
        public const int MaxMatchCodeLengthExceeded = unchecked((int)0x80048429); // -2147187671
        public const int CannotDeleteUpdateInUseRule = unchecked((int)0x80048428); // -2147187672
        public const int ImportMappingsInvalidIdSpecified = unchecked((int)0x80048427); // -2147187673
        public const int NotAWellFormedXml = unchecked((int)0x80048426); // -2147187674
        public const int NoncompliantXml = unchecked((int)0x80048425); // -2147187675
        public const int DuplicateDetectionTemplateNotFound = unchecked((int)0x80048424); // -2147187676
        public const int RulesInInconsistentStateFound = unchecked((int)0x80048423); // -2147187677
        public const int BulkDetectInvalidEmailRecipient = unchecked((int)0x80048422); // -2147187678
        public const int CannotEnableDuplicateDetection = unchecked((int)0x80048421); // -2147187679
        public const int CannotDeleteInUseEntity = unchecked((int)0x80048420); // -2147187680
        public const int StringAttributeIndexError = unchecked((int)0x8004d292); // -2147167598
        public const int CannotChangeAttributeRequiredLevel = unchecked((int)0x8004d293); // -2147167597
        public const int MaximumNumberOfAttributesForEntityReached = unchecked((int)0x8004841a); // -2147187686
        public const int CannotPublishMoreRules = unchecked((int)0x80048419); // -2147187687
        public const int CannotDeleteInUseAttribute = unchecked((int)0x80048418); // -2147187688
        public const int CannotDeleteInUseOptionSet = unchecked((int)0x80048417); // -2147187689
        public const int InvalidEntityName = unchecked((int)0x80048416); // -2147187690
        public const int InvalidOperatorCode = unchecked((int)0x80048415); // -2147187691
        public const int CannotPublishEmptyRule = unchecked((int)0x80048414); // -2147187692
        public const int CannotPublishInactiveRule = unchecked((int)0x80048413); // -2147187693
        public const int DuplicateCheckNotEnabled = unchecked((int)0x80048412); // -2147187694
        public const int DuplicateCheckNotSupportedOnEntity = unchecked((int)0x80048410); // -2147187696
        public const int InvalidStateCodeStatusCode = unchecked((int)0x80048408); // -2147187704
        public const int SyncToMsdeFailure = unchecked((int)0x80048407); // -2147187705
        public const int AccessDenied = unchecked((int)0x80048405); // -2147187707
        public const int CannotDeleteOptionSet = unchecked((int)0x80048404); // -2147187708
        public const int InvalidOptionSetOperation = unchecked((int)0x80048403); // -2147187709
        public const int OptionValuePrefixOutOfRange = unchecked((int)0x80048402); // -2147187710
        public const int CheckPrivilegeGroupForUserOnPremiseError = unchecked((int)0x80048401); // -2147187711
        public const int CheckPrivilegeGroupForUserOnSplaError = unchecked((int)0x80048400); // -2147187712
        public const int UnManagedIdsAccessDenied = unchecked((int)0x80048306); // -2147187962
        public const int EntityIsIntersect = unchecked((int)0x8004830f); // -2147187953
        public const int CannotDeleteTeamOwningRecords = unchecked((int)0x8004830e); // -2147187954
        public const int CannotRemoveMembersFromDefaultTeam = unchecked((int)0x8004830c); // -2147187956
        public const int CannotAddMembersToDefaultTeam = unchecked((int)0x8004830b); // -2147187957
        public const int CannotUpdateNameDefaultTeam = unchecked((int)0x8004830a); // -2147187958
        public const int CannotSetParentDefaultTeam = unchecked((int)0x80048308); // -2147187960
        public const int CannotDeleteDefaultTeam = unchecked((int)0x80048307); // -2147187961
        public const int TeamNameTooLong = unchecked((int)0x80048305); // -2147187963
        public const int InvalidDomainName = unchecked((int)0x80048015); // -2147188715
        public const int InvalidUserName = unchecked((int)0x80048095); // -2147188587
        public const int BulkMailServiceNotAccessible = unchecked((int)0x80048304); // -2147187964
        public const int RsMoveItemError = unchecked((int)0x80048330); // -2147187920
        public const int ReportParentChildNotCustomizable = unchecked((int)0x8004832f); // -2147187921
        public const int ConvertFetchDataSetError = unchecked((int)0x8004832e); // -2147187922
        public const int ConvertReportToCrmError = unchecked((int)0x8004832d); // -2147187923
        public const int ReportViewerError = unchecked((int)0x8004832c); // -2147187924
        public const int RsGetItemTypeError = unchecked((int)0x8004832b); // -2147187925
        public const int RsSetPropertiesError = unchecked((int)0x8004832a); // -2147187926
        public const int RsReportParameterTypeMismatchError = unchecked((int)0x80048329); // -2147187927
        public const int RsUpdateReportExecutionSnapshotError = unchecked((int)0x80048328); // -2147187928
        public const int RsSetReportHistoryLimitError = unchecked((int)0x80048327); // -2147187929
        public const int RsSetReportHistoryOptionsError = unchecked((int)0x80048326); // -2147187930
        public const int RsSetExecutionOptionsError = unchecked((int)0x80048325); // -2147187931
        public const int RsSetReportParametersError = unchecked((int)0x80048324); // -2147187932
        public const int RsGetReportParametersError = unchecked((int)0x80048323); // -2147187933
        public const int RsSetItemDataSourcesError = unchecked((int)0x80048322); // -2147187934
        public const int RsGetItemDataSourcesError = unchecked((int)0x80048321); // -2147187935
        public const int RsCreateBatchError = unchecked((int)0x80048320); // -2147187936
        public const int RsListReportHistoryError = unchecked((int)0x8004831f); // -2147187937
        public const int RsGetReportHistoryLimitError = unchecked((int)0x8004831e); // -2147187938
        public const int RsExecuteBatchError = unchecked((int)0x8004831d); // -2147187939
        public const int RsCancelBatchError = unchecked((int)0x8004831c); // -2147187940
        public const int RsListExtensionsError = unchecked((int)0x8004831b); // -2147187941
        public const int RsGetDataSourceContentsError = unchecked((int)0x8004831a); // -2147187942
        public const int RsSetDataSourceContentsError = unchecked((int)0x80048319); // -2147187943
        public const int RsFindItemsError = unchecked((int)0x80048318); // -2147187944
        public const int RsDeleteItemError = unchecked((int)0x80048317); // -2147187945
        public const int ReportSecurityError = unchecked((int)0x80048316); // -2147187946
        public const int ReportMissingReportSourceError = unchecked((int)0x80048315); // -2147187947
        public const int ReportMissingParameterError = unchecked((int)0x80048314); // -2147187948
        public const int ReportMissingEndpointError = unchecked((int)0x80048313); // -2147187949
        public const int ReportMissingDataSourceError = unchecked((int)0x80048312); // -2147187950
        public const int ReportMissingDataSourceCredentialsError = unchecked((int)0x80048311); // -2147187951
        public const int ReportLocalProcessingError = unchecked((int)0x80048310); // -2147187952
        public const int ReportServerSp2HotFixNotApplied = unchecked((int)0x80048309); // -2147187959
        public const int DataSourceProhibited = unchecked((int)0x8004830d); // -2147187955
        public const int ReportServerVersionLow = unchecked((int)0x80048303); // -2147187965
        public const int ReportServerNoPrivilege = unchecked((int)0x80048302); // -2147187966
        public const int ReportServerInvalidUrl = unchecked((int)0x80048301); // -2147187967
        public const int ReportServerUnknownException = unchecked((int)0x80048300); // -2147187968
        public const int ReportNotAvailable = unchecked((int)0x80048299); // -2147188071
        public const int ErrorUploadingReport = unchecked((int)0x80048298); // -2147188072
        public const int ReportFileTooBig = unchecked((int)0x80048297); // -2147188073
        public const int ReportFileZeroLength = unchecked((int)0x80048296); // -2147188074
        public const int ReportTypeBlocked = unchecked((int)0x80048295); // -2147188075
        public const int ReportUploadDisabled = unchecked((int)0x80048294); // -2147188076
        public const int BothConnectionSidesAreNeeded = unchecked((int)0x80048218); // -2147188200
        public const int CannotConnectToSelf = unchecked((int)0x80048217); // -2147188201
        public const int UnrelatedConnectionRoles = unchecked((int)0x80048216); // -2147188202
        public const int ConnectionRoleNotValidForObjectType = unchecked((int)0x80048215); // -2147188203
        public const int ConnectionCannotBeEnabledOnThisEntity = unchecked((int)0x80048214); // -2147188204
        public const int ConnectionNotSupported = unchecked((int)0x80048213); // -2147188205
        public const int ConnectionObjectsMissing = unchecked((int)0x80048210); // -2147188208
        public const int ConnectionInvalidStartEndDate = unchecked((int)0x80048209); // -2147188215
        public const int ConnectionExists = unchecked((int)0x80048208); // -2147188216
        public const int DecoupleUserOwnedEntity = unchecked((int)0x80048207); // -2147188217
        public const int DecoupleChildEntity = unchecked((int)0x80048206); // -2147188218
        public const int ExistingParentalRelationship = unchecked((int)0x80048205); // -2147188219
        public const int InvalidCascadeLinkType = unchecked((int)0x80048204); // -2147188220
        public const int InvalidDeleteModification = unchecked((int)0x80048203); // -2147188221
        public const int CustomerOpportunityRoleExists = unchecked((int)0x80048202); // -2147188222
        public const int CustomerRelationshipExists = unchecked((int)0x80048201); // -2147188223
        public const int MultipleRelationshipsNotSupported = unchecked((int)0x80048200); // -2147188224
        public const int ImportDuplicateEntity = unchecked((int)0x8004810c); // -2147188468
        public const int CascadeProxyEmptyCallerId = unchecked((int)0x8004810b); // -2147188469
        public const int CascadeProxyInvalidPrincipalType = unchecked((int)0x8004810a); // -2147188470
        public const int CascadeProxyInvalidNativeDaPtr = unchecked((int)0x80048109); // -2147188471
        public const int CascadeFailToCreateNativeDaWrapper = unchecked((int)0x80048108); // -2147188472
        public const int CascadeReparentOnNonUserOwned = unchecked((int)0x80048107); // -2147188473
        public const int CascadeMergeInvalidSpecialColumn = unchecked((int)0x80048106); // -2147188474
        public const int CascadeRemoveLinkOnNonNullable = unchecked((int)0x80048104); // -2147188476
        public const int CascadeDeleteNotAllowDelete = unchecked((int)0x80048103); // -2147188477
        public const int CascadeInvalidLinkType = unchecked((int)0x80048102); // -2147188478
        public const int IsvExtensionsPrivilegeNotPresent = unchecked((int)0x80048029); // -2147188695
        public const int RelationshipNameLengthExceedsLimit = unchecked((int)0x8004802a); // -2147188694
        public const int ImportEmailTemplateErrorMissingFile = unchecked((int)0x8004802b); // -2147188693
        public const int CascadeInvalidExtraConditionValue = unchecked((int)0x80048101); // -2147188479
        public const int ImportWorkflowNameConflictError = unchecked((int)0x80048027); // -2147188697
        public const int ImportWorkflowPublishedError = unchecked((int)0x80048028); // -2147188696
        public const int ImportWorkflowEntityDependencyError = unchecked((int)0x80048023); // -2147188701
        public const int ImportWorkflowAttributeDependencyError = unchecked((int)0x80048022); // -2147188702
        public const int ImportWorkflowError = unchecked((int)0x80048021); // -2147188703
        public const int ImportGenericEntitiesError = unchecked((int)0x80048020); // -2147188704
        public const int ImportRolePermissionError = unchecked((int)0x80048018); // -2147188712
        public const int ImportRoleError = unchecked((int)0x80048017); // -2147188713
        public const int ImportOrgSettingsError = unchecked((int)0x80048019); // -2147188711
        public const int InvalidSharePointSiteCollectionUrl = unchecked((int)0x80048052); // -2147188654
        public const int InvalidSiteRelativeUrlFormat = unchecked((int)0x80048053); // -2147188653
        public const int InvalidRelativeUrlFormat = unchecked((int)0x80048054); // -2147188652
        public const int InvalidAbsoluteUrlFormat = unchecked((int)0x80048055); // -2147188651
        public const int InvalidUrlConsecutiveSlashes = unchecked((int)0x80048056); // -2147188650
        public const int SharePointRecordWithDuplicateUrl = unchecked((int)0x80048057); // -2147188649
        public const int SharePointAbsoluteAndRelativeUrlEmpty = unchecked((int)0x80048149); // -2147188407
        public const int ImportOptionSetsError = unchecked((int)0x80048030); // -2147188688
        public const int ImportRibbonsError = unchecked((int)0x80048031); // -2147188687
        public const int ImportReportsError = unchecked((int)0x80048032); // -2147188686
        public const int ImportSolutionError = unchecked((int)0x80048033); // -2147188685
        public const int ImportDependencySolutionError = unchecked((int)0x80048034); // -2147188684
        public const int ExportSolutionError = unchecked((int)0x80048035); // -2147188683
        public const int ExportManagedSolutionError = unchecked((int)0x80048036); // -2147188682
        public const int ExportMissingSolutionError = unchecked((int)0x80048037); // -2147188681
        public const int ImportSolutionManagedError = unchecked((int)0x80048038); // -2147188680
        public const int ImportOptionSetAttributeError = unchecked((int)0x80048039); // -2147188679
        public const int ImportSolutionManagedToUnmanagedMismatch = unchecked((int)0x80048040); // -2147188672
        public const int ImportSolutionUnmanagedToManagedMismatch = unchecked((int)0x80048041); // -2147188671
        public const int ImportSolutionIsvConfigWarning = unchecked((int)0x80048042); // -2147188670
        public const int ImportSolutionSiteMapWarning = unchecked((int)0x80048043); // -2147188669
        public const int ImportSolutionOrganizationSettingsWarning = unchecked((int)0x80048044); // -2147188668
        public const int ImportExportDeprecatedError = unchecked((int)0x80048045); // -2147188667
        public const int ImportSystemSolutionError = unchecked((int)0x80048046); // -2147188666
        public const int ImportTranslationMissingSolutionError = unchecked((int)0x80048047); // -2147188665
        public const int ExportDefaultAsPackagedError = unchecked((int)0x80048048); // -2147188664
        public const int ImportDefaultAsPackageError = unchecked((int)0x80048049); // -2147188663
        public const int ImportCustomizationsBadZipFileError = unchecked((int)0x80048060); // -2147188640
        public const int ImportTranslationsBadZipFileError = unchecked((int)0x80048061); // -2147188639
        public const int ImportAttributeNameError = unchecked((int)0x80048062); // -2147188638
        public const int ImportFieldSecurityProfileIsSecuredMissingError = unchecked((int)0x80048063); // -2147188637
        public const int ImportFieldSecurityProfileAttributesMissingError = unchecked((int)0x80048064); // -2147188636
        public const int ImportFileSignatureInvalid = unchecked((int)0x80048065); // -2147188635
        public const int ImportSolutionPackageNotValid = unchecked((int)0x80048066); // -2147188634
        public const int ImportSolutionPackageNeedsUpgrade = unchecked((int)0x80048067); // -2147188633
        public const int ImportSolutionPackageMinimumVersionNeeded = unchecked((int)0x80048068); // -2147188632
        public const int ImportSdkMessagesError = unchecked((int)0x80048016); // -2147188714
        public const int ImportEmailTemplatePersonalError = unchecked((int)0x80048014); // -2147188716
        public const int ImportNonWellFormedFileError = unchecked((int)0x80048013); // -2147188717
        public const int ImportPluginTypesError = unchecked((int)0x80048012); // -2147188718
        public const int ImportSiteMapError = unchecked((int)0x80048011); // -2147188719
        public const int ImportMappingsMissingEntityMapError = unchecked((int)0x80048010); // -2147188720
        public const int ImportMappingsSystemMapError = unchecked((int)0x8004800f); // -2147188721
        public const int ImportIsvConfigError = unchecked((int)0x8004800e); // -2147188722
        public const int ImportArticleTemplateError = unchecked((int)0x8004800d); // -2147188723
        public const int ImportEmailTemplateError = unchecked((int)0x8004800c); // -2147188724
        public const int ImportContractTemplateError = unchecked((int)0x8004800b); // -2147188725
        public const int ImportRelationshipRoleMapsError = unchecked((int)0x8004800a); // -2147188726
        public const int ImportRelationshipRolesError = unchecked((int)0x80048009); // -2147188727
        public const int ImportRelationshipRolesPrivilegeError = unchecked((int)0x8004802f); // -2147188689
        public const int ImportEntityNameMismatchError = unchecked((int)0x80048008); // -2147188728
        public const int ImportFormXmlError = unchecked((int)0x80048007); // -2147188729
        public const int ImportFieldXmlError = unchecked((int)0x80048006); // -2147188730
        public const int ImportSavedQueryExistingError = unchecked((int)0x80048005); // -2147188731
        public const int ImportSavedQueryOtcMismatchError = unchecked((int)0x80048004); // -2147188732
        public const int ImportEntityCustomResourcesNewStringError = unchecked((int)0x80048003); // -2147188733
        public const int ImportEntityCustomResourcesError = unchecked((int)0x80048002); // -2147188734
        public const int ImportEntityIconError = unchecked((int)0x80048001); // -2147188735
        public const int ImportSavedQueryDeletedError = unchecked((int)0x8004801b); // -2147188709
        public const int ImportEntitySystemUserOnPremiseMismatchError = unchecked((int)0x80048024); // -2147188700
        public const int ImportEntitySystemUserLiveMismatchError = unchecked((int)0x80048025); // -2147188699
        public const int ImportLanguagesIgnoredError = unchecked((int)0x80048026); // -2147188698
        public const int ImportInvalidFileError = unchecked((int)0x80048000); // -2147188736
        public const int ImportXsdValidationError = unchecked((int)0x8004801a); // -2147188710
        public const int ImportInvalidXmlError = unchecked((int)0x8004802c); // -2147188692
        public const int ImportWrongPublisherError = unchecked((int)0x8004801c); // -2147188708
        public const int ImportMissingDependenciesError = unchecked((int)0x8004801d); // -2147188707
        public const int ImportGenericError = unchecked((int)0x8004801e); // -2147188706
        public const int ImportMissingComponent = unchecked((int)0x8004801f); // -2147188705
        public const int ImportMissingRootComponentEntry = unchecked((int)0x8004803a); // -2147188678
        public const int UnmanagedComponentParentsManagedComponent = unchecked((int)0x8004803b); // -2147188677
        public const int FailedToGetNetworkServiceName = unchecked((int)0x80047103); // -2147192573
        public const int CustomParentingSystemNotSupported = unchecked((int)0x80047102); // -2147192574
        public const int InvalidFormatParameters = unchecked((int)0x80047101); // -2147192575
        public const int ConfigurationPageNotValidForSolution = unchecked((int)0x8004701d); // -2147192803
        public const int SolutionConfigurationPageMustBeHtmlWebResource = unchecked((int)0x8004701c); // -2147192804
        public const int InvalidSolutionConfigurationPage = unchecked((int)0x8004701b); // -2147192805
        public const int InvalidLanguageForSolution = unchecked((int)0x80047019); // -2147192807
        public const int CannotHaveDuplicateYomi = unchecked((int)0x80047018); // -2147192808
        public const int SavedQueryIsNotCustomizable = unchecked((int)0x80047017); // -2147192809
        public const int CannotDeleteChildAttribute = unchecked((int)0x80047016); // -2147192810
        public const int EntityHasNoStateCode = unchecked((int)0x80047015); // -2147192811
        public const int NoAttributesForEntityCreate = unchecked((int)0x80047014); // -2147192812
        public const int DuplicateAttributeSchemaName = unchecked((int)0x80047013); // -2147192813
        public const int DuplicateDisplayCollectionName = unchecked((int)0x80047012); // -2147192814
        public const int DuplicateDisplayName = unchecked((int)0x80047011); // -2147192815
        public const int DuplicateName = unchecked((int)0x80047010); // -2147192816
        public const int InvalidRelationshipType = unchecked((int)0x8004700f); // -2147192817
        public const int InvalidPrimaryFieldType = unchecked((int)0x8004700e); // -2147192818
        public const int InvalidOwnershipTypeMask = unchecked((int)0x8004700d); // -2147192819
        public const int InvalidDisplayName = unchecked((int)0x8004700c); // -2147192820
        public const int InvalidSchemaName = unchecked((int)0x8004700b); // -2147192821
        public const int RelationshipIsNotCustomRelationship = unchecked((int)0x8004700a); // -2147192822
        public const int AttributeIsNotCustomAttribute = unchecked((int)0x80047009); // -2147192823
        public const int EntityIsNotCustomizable = unchecked((int)0x80047008); // -2147192824
        public const int MultipleParentsNotSupported = unchecked((int)0x80047007); // -2147192825
        public const int CannotCreateActivityRelationship = unchecked((int)0x80047006); // -2147192826
        public const int CyclicalRelationship = unchecked((int)0x80047004); // -2147192828
        public const int InvalidRelationshipDescription = unchecked((int)0x80047003); // -2147192829
        public const int CannotDeletePrimaryUiAttribute = unchecked((int)0x80047002); // -2147192830
        public const int RowGuidIsNotValidName = unchecked((int)0x80047001); // -2147192831
        public const int FailedToScheduleActivity = unchecked((int)0x80047000); // -2147192832
        public const int CannotDeleteLastEmailAttribute = unchecked((int)0x80046fff); // -2147192833
        public const int SystemAttributeMap = unchecked((int)0x80046205); // -2147196411
        public const int UpdateAttributeMap = unchecked((int)0x80046204); // -2147196412
        public const int InvalidAttributeMap = unchecked((int)0x80046203); // -2147196413
        public const int SystemEntityMap = unchecked((int)0x80046202); // -2147196414
        public const int UpdateEntityMap = unchecked((int)0x80046201); // -2147196415
        public const int NonMappableEntity = unchecked((int)0x80046200); // -2147196416
        public const int UnManagedidsCalloutException = unchecked((int)0x80045f05); // -2147197179
        public const int UnManagedidscalloutinvalidevent = unchecked((int)0x80045f04); // -2147197180
        public const int UnManagedidscalloutinvalidconfig = unchecked((int)0x80045f03); // -2147197181
        public const int UnManagedidscalloutisvstop = unchecked((int)0x80045f02); // -2147197182
        public const int UnManagedidscalloutisvabort = unchecked((int)0x80045f01); // -2147197183
        public const int UnManagedidscalloutisvexception = unchecked((int)0x80045f00); // -2147197184
        public const int UnManagedidscustomentityambiguousrelationship = unchecked((int)0x8004590d); // -2147198707
        public const int UnManagedidscustomentitynorelationship = unchecked((int)0x8004590c); // -2147198708
        public const int UnManagedidscustomentityparentchildidentical = unchecked((int)0x8004590b); // -2147198709
        public const int UnManagedidscustomentityinvalidparent = unchecked((int)0x8004590a); // -2147198710
        public const int UnManagedidscustomentityinvalidchild = unchecked((int)0x80045909); // -2147198711
        public const int UnManagedidscustomentitywouldcreateloop = unchecked((int)0x80045908); // -2147198712
        public const int UnManagedidscustomentityexistingloop = unchecked((int)0x80045907); // -2147198713
        public const int UnManagedidscustomentitystackunderflow = unchecked((int)0x80045906); // -2147198714
        public const int UnManagedidscustomentitystackoverflow = unchecked((int)0x80045905); // -2147198715
        public const int UnManagedidscustomentitytlsfailure = unchecked((int)0x80045904); // -2147198716
        public const int UnManagedidscustomentityinvalidownership = unchecked((int)0x80045903); // -2147198717
        public const int UnManagedidscustomentitynotinitialized = unchecked((int)0x80045902); // -2147198718
        public const int UnManagedidscustomentityalreadyinitialized = unchecked((int)0x80045901); // -2147198719
        public const int UnManagedidscustomentitynameviolation = unchecked((int)0x80045900); // -2147198720
        public const int UnManagedidscascadeunexpectederror = unchecked((int)0x80045603); // -2147199485
        public const int UnManagedidscascadeemptylinkerror = unchecked((int)0x80045602); // -2147199486
        public const int UnManagedidscascadeundefinedrelationerror = unchecked((int)0x80045601); // -2147199487
        public const int UnManagedidscascadeinconsistencyerror = unchecked((int)0x80045600); // -2147199488
        public const int MergeLossOfParentingWarning = unchecked((int)0x80045317); // -2147200233
        public const int MergeDifferentlyParentedWarning = unchecked((int)0x80045316); // -2147200234
        public const int MergeEntitiesIdenticalError = unchecked((int)0x80045305); // -2147200251
        public const int MergeEntityNotActiveError = unchecked((int)0x80045304); // -2147200252
        public const int UnManagedidsmergedifferentbizorgerror = unchecked((int)0x80045303); // -2147200253
        public const int MergeActiveQuoteError = unchecked((int)0x80045302); // -2147200254
        public const int MergeSecurityError = unchecked((int)0x80045301); // -2147200255
        public const int MergeCyclicalParentingError = unchecked((int)0x80045300); // -2147200256
        public const int UnManagedidscalendarruledoesnotexist = unchecked((int)0x80045100); // -2147200768
        public const int UnManagedidscalendarinvalidcalendar = unchecked((int)0x80044d00); // -2147201792
        public const int AttachmentInvalidFileName = unchecked((int)0x80044a08); // -2147202552
        public const int UnManagedidsattachmentcannottruncatetempfile = unchecked((int)0x80044a07); // -2147202553
        public const int UnManagedidsattachmentcannotunmaptempfile = unchecked((int)0x80044a06); // -2147202554
        public const int UnManagedidsattachmentcannotcreatetempfile = unchecked((int)0x80044a05); // -2147202555
        public const int UnManagedidsattachmentisempty = unchecked((int)0x80044a04); // -2147202556
        public const int UnManagedidsattachmentcannotreadtempfile = unchecked((int)0x80044a03); // -2147202557
        public const int UnManagedidsattachmentinvalidfilesize = unchecked((int)0x80044a02); // -2147202558
        public const int UnManagedidsattachmentcannotgetfilesize = unchecked((int)0x80044a01); // -2147202559
        public const int UnManagedidsattachmentcannotopentempfile = unchecked((int)0x80044a00); // -2147202560
        public const int UnManagedidscustomizationtransformationnotsupported = unchecked((int)0x80044700); // -2147203328
        public const int ContractDetailDiscountAmountAndPercent = unchecked((int)0x80044414); // -2147204076
        public const int ContractDetailDiscountAmount = unchecked((int)0x80044413); // -2147204077
        public const int ContractDetailDiscountPercent = unchecked((int)0x80044412); // -2147204078
        public const int IncidentIsAlreadyClosedOrCancelled = unchecked((int)0x80044411); // -2147204079
        public const int UnManagedidsincidentparentaccountandparentcontactnotpresent = unchecked((int)0x80044410); // -2147204080
        public const int UnManagedidsincidentparentaccountandparentcontactpresent = unchecked((int)0x8004440f); // -2147204081
        public const int IncidentCannotCancel = unchecked((int)0x8004440e); // -2147204082
        public const int IncidentInvalidContractLineStateForCreate = unchecked((int)0x8004440d); // -2147204083
        public const int IncidentNullSpentTimeOrBilled = unchecked((int)0x8004440c); // -2147204084
        public const int IncidentInvalidAllotmentType = unchecked((int)0x8004440b); // -2147204085
        public const int UnManagedidsincidentcannotclose = unchecked((int)0x8004440a); // -2147204086
        public const int IncidentMissingActivityRegardingObject = unchecked((int)0x80044409); // -2147204087
        public const int UnManagedidsincidentmissingactivityobjecttype = unchecked((int)0x80044408); // -2147204088
        public const int UnManagedidsincidentnullactivitytypecode = unchecked((int)0x80044407); // -2147204089
        public const int UnManagedidsincidentinvalidactivitytypecode = unchecked((int)0x80044406); // -2147204090
        public const int UnManagedidsincidentassociatedactivitycorrupted = unchecked((int)0x80044405); // -2147204091
        public const int UnManagedidsincidentinvalidstate = unchecked((int)0x80044404); // -2147204092
        public const int IncidentContractDoesNotHaveAllotments = unchecked((int)0x80044403); // -2147204093
        public const int UnManagedidsincidentcontractdetaildoesnotmatchcontract = unchecked((int)0x80044402); // -2147204094
        public const int IncidentMissingContractDetail = unchecked((int)0x80044401); // -2147204095
        public const int IncidentInvalidContractStateForCreate = unchecked((int)0x80044400); // -2147204096
        public const int DisabledCrmGoingOffline = unchecked((int)0x80044200); // -2147204608
        public const int DisabledCrmGoingOnline = unchecked((int)0x80044201); // -2147204607
        public const int DisabledCrmAddinLoadFailure = unchecked((int)0x80044202); // -2147204606
        public const int DisabledCrmClientVersionLower = unchecked((int)0x80044203); // -2147204605
        public const int DisabledCrmClientVersionHigher = unchecked((int)0x80044204); // -2147204604
        public const int DisabledCrmPostOfflineUpgrade = unchecked((int)0x80044205); // -2147204603
        public const int DisabledCrmOnlineCrmNotAvailable = unchecked((int)0x80044206); // -2147204602
        public const int GoOfflineMetadataVersionsMismatch = unchecked((int)0x80044220); // -2147204576
        public const int GoOfflineGetBcpFileException = unchecked((int)0x80044221); // -2147204575
        public const int GoOfflineDbSizeLimit = unchecked((int)0x80044222); // -2147204574
        public const int GoOfflineServerFailedGenerateBcpFile = unchecked((int)0x80044223); // -2147204573
        public const int GoOfflineBcpFileSize = unchecked((int)0x80044224); // -2147204572
        public const int GoOfflineFailedMoveData = unchecked((int)0x80044225); // -2147204571
        public const int GoOfflineFailedPrepareMsde = unchecked((int)0x80044226); // -2147204570
        public const int GoOfflineFailedReloadMetadataCache = unchecked((int)0x80044227); // -2147204569
        public const int DoNotTrackItem = unchecked((int)0x80044228); // -2147204568
        public const int GoOfflineFileWasDeleted = unchecked((int)0x80044229); // -2147204567
        public const int GoOfflineEmptyFileForDelete = unchecked((int)0x80044230); // -2147204560
        public const int OrganizationUiDeprecated = unchecked((int)0x80044159); // -2147204775
        public const int UnManagedidssqltimeouterror = unchecked((int)0x80044151); // -2147204783
        public const int UnManagedidssqlerror = unchecked((int)0x80044150); // -2147204784
        public const int UnManagedidsrcsyncinvalidfiltererror = unchecked((int)0x8004410d); // -2147204851
        public const int UnManagedidsrcsyncnotprimary = unchecked((int)0x80044111); // -2147204847
        public const int UnManagedidsrcsyncnoprimary = unchecked((int)0x80044112); // -2147204846
        public const int UnManagedidsrcsyncnoclient = unchecked((int)0x80044113); // -2147204845
        public const int UnManagedidsrcsyncfilternoaccess = unchecked((int)0x8004410f); // -2147204849
        public const int InvalidOfflineOperation = unchecked((int)0x8004410e); // -2147204850
        public const int UnManagedidsrcsyncsqlgenericerror = unchecked((int)0x80044110); // -2147204848
        public const int UnManagedidsrcsyncsqlpausederror = unchecked((int)0x8004410c); // -2147204852
        public const int UnManagedidsrcsyncsqlstoppederror = unchecked((int)0x8004410b); // -2147204853
        public const int UnManagedidsrcsyncsubscriptionowner = unchecked((int)0x8004410a); // -2147204854
        public const int UnManagedidsrcsyncinvalidsubscription = unchecked((int)0x80044109); // -2147204855
        public const int UnManagedidsrcsyncsoapparseerror = unchecked((int)0x80044108); // -2147204856
        public const int UnManagedidsrcsyncsoapreaderror = unchecked((int)0x80044107); // -2147204857
        public const int UnManagedidsrcsyncsoapfaulterror = unchecked((int)0x80044106); // -2147204858
        public const int UnManagedidsrcsyncsoapservererror = unchecked((int)0x80044105); // -2147204859
        public const int UnManagedidsrcsyncsoapsendfailed = unchecked((int)0x80044104); // -2147204860
        public const int UnManagedidsrcsyncsoapconnfailed = unchecked((int)0x80044103); // -2147204861
        public const int UnManagedidsrcsyncsoapgenfailed = unchecked((int)0x80044102); // -2147204862
        public const int UnManagedidsrcsyncmsxmlfailed = unchecked((int)0x80044101); // -2147204863
        public const int UnManagedidsrcsyncinvalidsynctime = unchecked((int)0x80044100); // -2147204864
        public const int AttachmentBlocked = unchecked((int)0x80043e09); // -2147205623
        public const int UnManagedidsarticletemplateisnotactive = unchecked((int)0x80043e07); // -2147205625
        public const int UnManagedidsfulltextoperationfailed = unchecked((int)0x80043e06); // -2147205626
        public const int UnManagedidsarticletemplatecontainsarticles = unchecked((int)0x80043e05); // -2147205627
        public const int UnManagedidsqueueorganizationidnotmatch = unchecked((int)0x80043e04); // -2147205628
        public const int UnManagedidsqueuemissingbusinessunitid = unchecked((int)0x80043e03); // -2147205629
        public const int SubjectDoesNotExist = unchecked((int)0x80043e02); // -2147205630
        public const int SubjectLoopBeingCreated = unchecked((int)0x80043e01); // -2147205631
        public const int SubjectLoopExists = unchecked((int)0x80043e00); // -2147205632
        public const int InvalidSubmitFromUnapprovedArticle = unchecked((int)0x80048dff); // -2147185153
        public const int InvalidUnpublishFromUnapprovedArticle = unchecked((int)0x80048dfe); // -2147185154
        public const int InvalidApproveFromDraftArticle = unchecked((int)0x80048dfd); // -2147185155
        public const int InvalidUnpublishFromDraftArticle = unchecked((int)0x80048dfc); // -2147185156
        public const int InvalidApproveFromPublishedArticle = unchecked((int)0x80048dfb); // -2147185157
        public const int InvalidSubmitFromPublishedArticle = unchecked((int)0x80048dfa); // -2147185158
        public const int QuoteReviseExistingActiveQuote = unchecked((int)0x80048d00); // -2147185408
        public const int BaseCurrencyNotDeletable = unchecked((int)0x80048cff); // -2147185409
        public const int CannotDeleteBaseMoneyCalculationAttribute = unchecked((int)0x80048cfe); // -2147185410
        public const int InvalidExchangeRate = unchecked((int)0x80048cfd); // -2147185411
        public const int InvalidCurrency = unchecked((int)0x80048cfc); // -2147185412
        public const int CurrencyCannotBeNullDueToNonNullMoneyFields = unchecked((int)0x80048cfb); // -2147185413
        public const int CannotUpdateProductCurrency = unchecked((int)0x80048cfa); // -2147185414
        public const int InvalidPriceLevelCurrencyForPricingMethod = unchecked((int)0x80048cf9); // -2147185415
        public const int DiscountTypeAndPriceLevelCurrencyNotEqual = unchecked((int)0x80048cf8); // -2147185416
        public const int CurrencyRequiredForDiscountTypeAmount = unchecked((int)0x80048cf7); // -2147185417
        public const int RecordAndPricelistCurrencyNotEqual = unchecked((int)0x80048cf6); // -2147185418
        public const int ExchangeRateOfBaseCurrencyNotUpdatable = unchecked((int)0x80048cf5); // -2147185419
        public const int BaseCurrencyCannotBeDeactivated = unchecked((int)0x80048cf4); // -2147185420
        public const int DuplicateIsoCurrencyCode = unchecked((int)0x80048cf3); // -2147185421
        public const int InvalidIsoCurrencyCode = unchecked((int)0x80048cf2); // -2147185422
        public const int PercentageDiscountCannotHaveCurrency = unchecked((int)0x80048cf1); // -2147185423
        public const int RecordAndOpportunityCurrencyNotEqual = unchecked((int)0x80048cef); // -2147185425
        public const int QuoteAndSalesOrderCurrencyNotEqual = unchecked((int)0x80048cee); // -2147185426
        public const int SalesOrderAndInvoiceCurrencyNotEqual = unchecked((int)0x80048ced); // -2147185427
        public const int BaseCurrencyOverflow = unchecked((int)0x80048cec); // -2147185428
        public const int BaseCurrencyUnderflow = unchecked((int)0x80048ceb); // -2147185429
        public const int CurrencyNotEqual = unchecked((int)0x80048cea); // -2147185430
        public const int UnitNoName = unchecked((int)0x80043b26); // -2147206362
        public const int UnManagedidsinvoicecloseapideprecated = unchecked((int)0x80043b25); // -2147206363
        public const int ProductDoesNotExist = unchecked((int)0x80043b24); // -2147206364
        public const int ProductKitLoopBeingCreated = unchecked((int)0x80043b23); // -2147206365
        public const int ProductKitLoopExists = unchecked((int)0x80043b22); // -2147206366
        public const int DiscountPercent = unchecked((int)0x80043b21); // -2147206367
        public const int DiscountAmount = unchecked((int)0x80043b20); // -2147206368
        public const int DiscountAmountAndPercent = unchecked((int)0x80043b1f); // -2147206369
        public const int EntityIsUnlocked = unchecked((int)0x80043b1e); // -2147206370
        public const int EntityIsLocked = unchecked((int)0x80043b1d); // -2147206371
        public const int BaseUnitDoesNotExist = unchecked((int)0x80043b1c); // -2147206372
        public const int UnitDoesNotExist = unchecked((int)0x80043b1b); // -2147206373
        public const int UnitLoopBeingCreated = unchecked((int)0x80043b1a); // -2147206374
        public const int UnitLoopExists = unchecked((int)0x80043b19); // -2147206375
        public const int QuantityReadonly = unchecked((int)0x80043b18); // -2147206376
        public const int BaseUnitNotNull = unchecked((int)0x80043b17); // -2147206377
        public const int UnitNotInSchedule = unchecked((int)0x80043b16); // -2147206378
        public const int MissingOpportunityId = unchecked((int)0x80043b15); // -2147206379
        public const int ProductInvalidUnit = unchecked((int)0x80043b14); // -2147206380
        public const int ProductMissingUomSheduleId = unchecked((int)0x80043b13); // -2147206381
        public const int MissingPriceLevelId = unchecked((int)0x80043b12); // -2147206382
        public const int MissingProductId = unchecked((int)0x80043b11); // -2147206383
        public const int InvalidPricePerUnit = unchecked((int)0x80043b10); // -2147206384
        public const int PriceLevelNameExists = unchecked((int)0x80043b0f); // -2147206385
        public const int PriceLevelNoName = unchecked((int)0x80043b0e); // -2147206386
        public const int MissingUomId = unchecked((int)0x80043b0d); // -2147206387
        public const int ProductInvalidPriceLevelPercentage = unchecked((int)0x80043b0c); // -2147206388
        public const int InvalidBaseUnit = unchecked((int)0x80043b0b); // -2147206389
        public const int MissingUomScheduleId = unchecked((int)0x80043b0a); // -2147206390
        public const int ParentReadOnly = unchecked((int)0x80043b09); // -2147206391
        public const int DuplicateProductPriceLevel = unchecked((int)0x80043b08); // -2147206392
        public const int ProductInvalidQuantityDecimal = unchecked((int)0x80043b07); // -2147206393
        public const int ProductProductNumberExists = unchecked((int)0x80043b06); // -2147206394
        public const int ProductNoProductNumber = unchecked((int)0x80043b05); // -2147206395
        public const int UnManagedidscannotdeactivatepricelevel = unchecked((int)0x80043b04); // -2147206396
        public const int BaseUnitNotDeletable = unchecked((int)0x80043b03); // -2147206397
        public const int DiscountRangeOverlap = unchecked((int)0x80043b02); // -2147206398
        public const int LowQuantityGreaterThanHighQuantity = unchecked((int)0x80043b01); // -2147206399
        public const int LowQuantityLessThanZero = unchecked((int)0x80043b00); // -2147206400
        public const int InvalidSubstituteProduct = unchecked((int)0x80043aff); // -2147206401
        public const int InvalidKitProduct = unchecked((int)0x80043afe); // -2147206402
        public const int InvalidKit = unchecked((int)0x80043afd); // -2147206403
        public const int InvalidQuantityDecimalCode = unchecked((int)0x80043afc); // -2147206404
        public const int CannotSpecifyBothProductAndProductDesc = unchecked((int)0x80043afb); // -2147206405
        public const int CannotSpecifyBothUomAndProductDesc = unchecked((int)0x80043afa); // -2147206406
        public const int UnManagedidsstatedoesnotexist = unchecked((int)0x80043af9); // -2147206407
        public const int FiscalSettingsAlreadyUpdated = unchecked((int)0x80043809); // -2147207159
        public const int UnManagedidssalespeopleinvalidfiscalcalendartype = unchecked((int)0x80043808); // -2147207160
        public const int UnManagedidssalespeopleinvalidfiscalperiodindex = unchecked((int)0x80043807); // -2147207161
        public const int SalesPeopleManagerNotAllowed = unchecked((int)0x80043805); // -2147207163
        public const int UnManagedidssalespeopleinvalidterritoryobjecttype = unchecked((int)0x80043804); // -2147207164
        public const int SalesPeopleDuplicateCalendarNotAllowed = unchecked((int)0x80043803); // -2147207165
        public const int UnManagedidssalespeopleduplicatecalendarfound = unchecked((int)0x80043802); // -2147207166
        public const int SalesPeopleEmptyEffectiveDate = unchecked((int)0x80043801); // -2147207167
        public const int SalesPeopleEmptySalesPerson = unchecked((int)0x80043800); // -2147207168
        public const int InvalidNumberGroupFormat = unchecked((int)0x80043700); // -2147207424
        public const int BaseUomNameNotSpecified = unchecked((int)0x80043810); // -2147207152
        public const int FaxNoSupport = unchecked((int)0x80043517); // -2147207913
        public const int FaxNoData = unchecked((int)0x80043516); // -2147207914
        public const int InvalidPartyMapping = unchecked((int)0x80043515); // -2147207915
        public const int InvalidActivityXml = unchecked((int)0x80043514); // -2147207916
        public const int ActivityInvalidObjectTypeCode = unchecked((int)0x80043513); // -2147207917
        public const int ActivityInvalidSessionToken = unchecked((int)0x80043512); // -2147207918
        public const int FaxServiceNotRunning = unchecked((int)0x80043511); // -2147207919
        public const int FaxSendBlocked = unchecked((int)0x80043510); // -2147207920
        public const int NoDialNumber = unchecked((int)0x8004350f); // -2147207921
        public const int TooManyRecipients = unchecked((int)0x8004350e); // -2147207922
        public const int MissingRecipient = unchecked((int)0x8004350d); // -2147207923
        public const int UnManagedidsactivitynotroutable = unchecked((int)0x8004350b); // -2147207925
        public const int UnManagedidsactivitydurationdoesnotmatch = unchecked((int)0x8004350a); // -2147207926
        public const int UnManagedidsactivityinvalidduration = unchecked((int)0x80043509); // -2147207927
        public const int UnManagedidsactivityinvalidtimeformat = unchecked((int)0x80043508); // -2147207928
        public const int UnManagedidsactivityinvalidregardingobject = unchecked((int)0x80043507); // -2147207929
        public const int ActivityPartyObjectTypeNotAllowed = unchecked((int)0x80043506); // -2147207930
        public const int UnManagedidsactivityinvalidpartyobjecttype = unchecked((int)0x80043505); // -2147207931
        public const int UnManagedidsactivitypartyobjectidortypemissing = unchecked((int)0x80043504); // -2147207932
        public const int UnManagedidsactivityinvalidobjecttype = unchecked((int)0x80043503); // -2147207933
        public const int UnManagedidsactivityobjectidortypemissing = unchecked((int)0x80043502); // -2147207934
        public const int UnManagedidsactivityinvalidtype = unchecked((int)0x80043501); // -2147207935
        public const int UnManagedidsactivityinvalidstate = unchecked((int)0x80043500); // -2147207936
        public const int ContractInvalidDatesForRenew = unchecked((int)0x80043218); // -2147208680
        public const int UnManagedidscontractinvalidstartdateforrenewedcontract = unchecked((int)0x80043217); // -2147208681
        public const int UnManagedidscontracttemplateabbreviationexists = unchecked((int)0x80043216); // -2147208682
        public const int ContractInvalidPrice = unchecked((int)0x80043215); // -2147208683
        public const int UnManagedidscontractinvalidtotalallotments = unchecked((int)0x80043214); // -2147208684
        public const int ContractInvalidContract = unchecked((int)0x80043213); // -2147208685
        public const int UnManagedidscontractinvalidowner = unchecked((int)0x80043212); // -2147208686
        public const int ContractInvalidContractTemplate = unchecked((int)0x80043211); // -2147208687
        public const int ContractInvalidBillToCustomer = unchecked((int)0x80043210); // -2147208688
        public const int ContractInvalidBillToAddress = unchecked((int)0x8004320f); // -2147208689
        public const int ContractInvalidServiceAddress = unchecked((int)0x8004320e); // -2147208690
        public const int ContractInvalidCustomer = unchecked((int)0x8004320d); // -2147208691
        public const int ContractNoLineItems = unchecked((int)0x8004320c); // -2147208692
        public const int ContractTemplateNoAbbreviation = unchecked((int)0x8004320b); // -2147208693
        public const int UnManagedidscontractopencasesexist = unchecked((int)0x8004320a); // -2147208694
        public const int UnManagedidscontractlineitemdoesnotexist = unchecked((int)0x80043208); // -2147208696
        public const int UnManagedidscontractdoesnotexist = unchecked((int)0x80043207); // -2147208697
        public const int ContractTemplateDoesNotExist = unchecked((int)0x80043206); // -2147208698
        public const int ContractInvalidAllotmentTypeCode = unchecked((int)0x80043205); // -2147208699
        public const int ContractLineInvalidState = unchecked((int)0x80043204); // -2147208700
        public const int ContractInvalidState = unchecked((int)0x80043203); // -2147208701
        public const int ContractInvalidStartEndDate = unchecked((int)0x80043202); // -2147208702
        public const int UnManagedidscontractaccountmissing = unchecked((int)0x80043201); // -2147208703
        public const int UnManagedidscontractunexpected = unchecked((int)0x80043200); // -2147208704
        public const int UnManagedidsevalerrorformatlookupparameter = unchecked((int)0x80042c4c); // -2147210164
        public const int UnManagedidsevalerrorformattimezonecodeparameter = unchecked((int)0x80042c4b); // -2147210165
        public const int UnManagedidsevalerrorformatdecimalparameter = unchecked((int)0x80042c4a); // -2147210166
        public const int UnManagedidsevalerrorformatintegerparameter = unchecked((int)0x80042c49); // -2147210167
        public const int UnManagedidsevalerrorobjecttype = unchecked((int)0x80042c48); // -2147210168
        public const int UnManagedidsevalerrorqueueidparameter = unchecked((int)0x80042c47); // -2147210169
        public const int UnManagedidsevalerrorformatpicklistparameter = unchecked((int)0x80042c46); // -2147210170
        public const int UnManagedidsevalerrorformatbooleanparameter = unchecked((int)0x80042c45); // -2147210171
        public const int UnManagedidsevalerrorformatdatetimeparameter = unchecked((int)0x80042c44); // -2147210172
        public const int UnManagedidsevalerrorisnulllistparameter = unchecked((int)0x80042c43); // -2147210173
        public const int UnManagedidsevalerrorinlistparameter = unchecked((int)0x80042c42); // -2147210174
        public const int UnManagedidsevalerrorsetactivityparty = unchecked((int)0x80042c41); // -2147210175
        public const int UnManagedidsevalerrorremovefromactivityparty = unchecked((int)0x80042c40); // -2147210176
        public const int UnManagedidsevalerrorappendtoactivityparty = unchecked((int)0x80042c3f); // -2147210177
        public const int UnManagedidsevaltimererrorcalculatescheduletime = unchecked((int)0x80042c3e); // -2147210178
        public const int UnManagedidsevaltimerinvalidparameternumber = unchecked((int)0x80042c3d); // -2147210179
        public const int UnManagedidsevalcreateshouldhave2Parameters = unchecked((int)0x80042c3c); // -2147210180
        public const int UnManagedidsevalerrorcreate = unchecked((int)0x80042c3b); // -2147210181
        public const int UnManagedidsevalerrorcontainparameter = unchecked((int)0x80042c3a); // -2147210182
        public const int UnManagedidsevalerrorendwithparameter = unchecked((int)0x80042c39); // -2147210183
        public const int UnManagedidsevalerrorbeginwithparameter = unchecked((int)0x80042c38); // -2147210184
        public const int UnManagedidsevalerrorstrlenparameter = unchecked((int)0x80042c37); // -2147210185
        public const int UnManagedidsevalerrorsubstrparameter = unchecked((int)0x80042c36); // -2147210186
        public const int UnManagedidsevalerrorinvalidrecipient = unchecked((int)0x80042c35); // -2147210187
        public const int UnManagedidsevalerrorinparameter = unchecked((int)0x80042c34); // -2147210188
        public const int UnManagedidsevalerrorbetweenparameter = unchecked((int)0x80042c33); // -2147210189
        public const int UnManagedidsevalerrorneqparameter = unchecked((int)0x80042c32); // -2147210190
        public const int UnManagedidsevalerroreqparameter = unchecked((int)0x80042c31); // -2147210191
        public const int UnManagedidsevalerrorleqparameter = unchecked((int)0x80042c30); // -2147210192
        public const int UnManagedidsevalerrorltparameter = unchecked((int)0x80042c2f); // -2147210193
        public const int UnManagedidsevalerrorgeqparameter = unchecked((int)0x80042c2e); // -2147210194
        public const int UnManagedidsevalerrorgtparameter = unchecked((int)0x80042c2d); // -2147210195
        public const int UnManagedidsevalerrorabsparameter = unchecked((int)0x80042c2c); // -2147210196
        public const int UnManagedidsevalerrorinvalidparameter = unchecked((int)0x80042c2b); // -2147210197
        public const int UnManagedidsevalgenericerror = unchecked((int)0x80042c2a); // -2147210198
        public const int UnManagedidsevalerrorincidentqueue = unchecked((int)0x80042c29); // -2147210199
        public const int UnManagedidsevalerrorhalt = unchecked((int)0x80042c28); // -2147210200
        public const int UnManagedidsevalerrorexec = unchecked((int)0x80042c27); // -2147210201
        public const int UnManagedidsevalerrorposturl = unchecked((int)0x80042c26); // -2147210202
        public const int UnManagedidsevalerrorsetstate = unchecked((int)0x80042c25); // -2147210203
        public const int UnManagedidsevalerrorroute = unchecked((int)0x80042c24); // -2147210204
        public const int UnManagedidsevalerrorupdate = unchecked((int)0x80042c23); // -2147210205
        public const int UnManagedidsevalerrorassign = unchecked((int)0x80042c22); // -2147210206
        public const int UnManagedidsevalerroremailtemplate = unchecked((int)0x80042c21); // -2147210207
        public const int UnManagedidsevalerrorsendemail = unchecked((int)0x80042c20); // -2147210208
        public const int UnManagedidsevalerrorunhandleincident = unchecked((int)0x80042c1f); // -2147210209
        public const int UnManagedidsevalerrorhandleincident = unchecked((int)0x80042c1e); // -2147210210
        public const int UnManagedidsevalerrorcreateincident = unchecked((int)0x80042c1d); // -2147210211
        public const int UnManagedidsevalerrornoteattachment = unchecked((int)0x80042c1c); // -2147210212
        public const int UnManagedidsevalerrorcreatenote = unchecked((int)0x80042c1b); // -2147210213
        public const int UnManagedidsevalerrorunhandleactivity = unchecked((int)0x80042c1a); // -2147210214
        public const int UnManagedidsevalerrorhandleactivity = unchecked((int)0x80042c19); // -2147210215
        public const int UnManagedidsevalerroractivityattachment = unchecked((int)0x80042c18); // -2147210216
        public const int UnManagedidsevalerrorcreateactivity = unchecked((int)0x80042c17); // -2147210217
        public const int UnManagedidsevalerrordividedbyzero = unchecked((int)0x80042c16); // -2147210218
        public const int UnManagedidsevalerrormodulusparameter = unchecked((int)0x80042c15); // -2147210219
        public const int UnManagedidsevalerrormodulusparameters = unchecked((int)0x80042c14); // -2147210220
        public const int UnManagedidsevalerrordivisionparameter = unchecked((int)0x80042c13); // -2147210221
        public const int UnManagedidsevalerrordivisionparameters = unchecked((int)0x80042c12); // -2147210222
        public const int UnManagedidsevalerrormultiplicationparameter = unchecked((int)0x80042c11); // -2147210223
        public const int UnManagedidsevalerrorsubtractionparameter = unchecked((int)0x80042c10); // -2147210224
        public const int UnManagedidsevalerroraddparameter = unchecked((int)0x80042c0f); // -2147210225
        public const int UnManagedidsevalmissselectquery = unchecked((int)0x80042c0e); // -2147210226
        public const int UnManagedidsevalchangetypeerror = unchecked((int)0x80042c0d); // -2147210227
        public const int UnManagedidsevalallcompleted = unchecked((int)0x80042c0c); // -2147210228
        public const int UnManagedidsevalmetabaseattributenotmatchquery = unchecked((int)0x80042c0b); // -2147210229
        public const int UnManagedidsevalmetabaseentitynotmatchquery = unchecked((int)0x80042c0a); // -2147210230
        public const int UnManagedidsevalpropertyisnull = unchecked((int)0x80042c09); // -2147210231
        public const int UnManagedidsevalmetabaseattributenotfound = unchecked((int)0x80042c08); // -2147210232
        public const int UnManagedidsevalmetabaseentitycompoundkeys = unchecked((int)0x80042c07); // -2147210233
        public const int UnManagedidsevalpropertynotfound = unchecked((int)0x80042c06); // -2147210234
        public const int UnManagedidsevalobjectnotfound = unchecked((int)0x80042c05); // -2147210235
        public const int UnManagedidsevalcompleted = unchecked((int)0x80042c04); // -2147210236
        public const int UnManagedidsevalaborted = unchecked((int)0x80042c03); // -2147210237
        public const int UnManagedidsevalallaborted = unchecked((int)0x80042c02); // -2147210238
        public const int UnManagedidsevalassignshouldhave4Parameters = unchecked((int)0x80042c01); // -2147210239
        public const int UnManagedidsevalupdateshouldhave3Parameters = unchecked((int)0x80042c00); // -2147210240
        public const int UnManagedidscpdecryptfailed = unchecked((int)0x80042903); // -2147211005
        public const int UnManagedidscpencryptfailed = unchecked((int)0x80042902); // -2147211006
        public const int UnManagedidscpbadpassword = unchecked((int)0x80042901); // -2147211007
        public const int UnManagedidscpuserdoesnotexist = unchecked((int)0x80042900); // -2147211008
        public const int UnManagedidsdataaccessunexpected = unchecked((int)0x80042300); // -2147212544
        public const int UnManagedidspropbagattributealreadyset = unchecked((int)0x8004203f); // -2147213249
        public const int UnManagedidspropbagattributenotnullable = unchecked((int)0x8004203e); // -2147213250
        public const int UnManagedidsrspropbagdbinfoalreadyset = unchecked((int)0x8004203d); // -2147213251
        public const int UnManagedidsrspropbagdbinfonotset = unchecked((int)0x8004203c); // -2147213252
        public const int UnManagedidspropbagcolloutofrange = unchecked((int)0x8004201e); // -2147213282
        public const int UnManagedidspropbagnullproperty = unchecked((int)0x80042002); // -2147213310
        public const int UnManagedidspropbagnointerface = unchecked((int)0x80042001); // -2147213311
        public const int UnManagedMissingObjectType = unchecked((int)0x80042003); // -2147213309
        public const int UnManagedObjectTypeUnexpected = unchecked((int)0x80042004); // -2147213308
        public const int BusinessUnitCannotBeDisabled = unchecked((int)0x80041d59); // -2147213991
        public const int BusinessUnitIsNotDisabledAndCannotBeDeleted = unchecked((int)0x80041d60); // -2147213984
        public const int BusinessUnitHasChildAndCannotBeDeleted = unchecked((int)0x80041d61); // -2147213983
        public const int BusinessUnitDefaultTeamOwnsRecords = unchecked((int)0x80041d62); // -2147213982
        public const int RootBusinessUnitCannotBeDisabled = unchecked((int)0x80041d63); // -2147213981
        public const int UnManagedidspropbagpropertynotfound = unchecked((int)0x80042000); // -2147213312
        public const int ReadOnlyUserNotSupported = unchecked((int)0x80041d40); // -2147214016
        public const int SupportUserCannotBeCreateNorUpdated = unchecked((int)0x80041d41); // -2147214015
        public const int CannotAssignRolesToSupportUser = unchecked((int)0x80041d51); // -2147213999
        public const int CannotMakeSelfReadOnlyUser = unchecked((int)0x80041d39); // -2147214023
        public const int CannotMakeReadOnlyUser = unchecked((int)0x80041d38); // -2147214024
        public const int UnManagedidsbizmgmtcantchangeorgname = unchecked((int)0x80041d36); // -2147214026
        public const int MultipleOrganizationsNotAllowed = unchecked((int)0x80041d35); // -2147214027
        public const int UserSettingsInvalidAdvancedFindStartupMode = unchecked((int)0x80041d34); // -2147214028
        public const int CannotModifySpecialUser = unchecked((int)0x80041d33); // -2147214029
        public const int UnManagedidsbizmgmtcannotaddlocaluser = unchecked((int)0x80041d32); // -2147214030
        public const int CannotModifySysAdmin = unchecked((int)0x80041d31); // -2147214031
        public const int CannotModifySupportUser = unchecked((int)0x80041d43); // -2147214013
        public const int CannotAssignSupportUser = unchecked((int)0x80041d44); // -2147214012
        public const int CannotRemoveFromSupportUser = unchecked((int)0x80041d45); // -2147214011
        public const int CannotCreateFromSupportUser = unchecked((int)0x80041d46); // -2147214010
        public const int CannotUpdateSupportUser = unchecked((int)0x80041d47); // -2147214009
        public const int CannotRemoveFromSysAdmin = unchecked((int)0x80041d30); // -2147214032
        public const int CannotDisableSysAdmin = unchecked((int)0x80041d2f); // -2147214033
        public const int CannotDeleteSysAdmin = unchecked((int)0x80041d2e); // -2147214034
        public const int CannotDeleteSupportUser = unchecked((int)0x80041d42); // -2147214014
        public const int CannotDeleteSystemCustomizer = unchecked((int)0x80041d4a); // -2147214006
        public const int UnManagedidsbizmgmtcannotreadaccountcontrol = unchecked((int)0x80041d2d); // -2147214035
        public const int UserAlreadyExists = unchecked((int)0x80041d2c); // -2147214036
        public const int UnManagedidsbizmgmtusersettingsnotcreated = unchecked((int)0x80041d2b); // -2147214037
        public const int ObjectNotFoundInAd = unchecked((int)0x80041d2a); // -2147214038
        public const int GenericActiveDirectoryError = unchecked((int)0x80041d37); // -2147214025
        public const int UnManagedidsbizmgmtnoparentbusiness = unchecked((int)0x80041d29); // -2147214039
        public const int ParentUserDoesNotExist = unchecked((int)0x80041d27); // -2147214041
        public const int ChildUserDoesNotExist = unchecked((int)0x80041d26); // -2147214042
        public const int UserLoopBeingCreated = unchecked((int)0x80041d25); // -2147214043
        public const int UserLoopExists = unchecked((int)0x80041d24); // -2147214044
        public const int ParentBusinessDoesNotExist = unchecked((int)0x80041d23); // -2147214045
        public const int ChildBusinessDoesNotExist = unchecked((int)0x80041d22); // -2147214046
        public const int BusinessManagementLoopBeingCreated = unchecked((int)0x80041d21); // -2147214047
        public const int BusinessManagementLoopExists = unchecked((int)0x80041d20); // -2147214048
        public const int BusinessManagementInvalidUserId = unchecked((int)0x80041d1f); // -2147214049
        public const int UnManagedidsbizmgmtuserdoesnothaveparent = unchecked((int)0x80041d1e); // -2147214050
        public const int UnManagedidsbizmgmtcannotenableprovision = unchecked((int)0x80041d1d); // -2147214051
        public const int UnManagedidsbizmgmtcannotenablebusiness = unchecked((int)0x80041d1c); // -2147214052
        public const int UnManagedidsbizmgmtcannotdisableprovision = unchecked((int)0x80041d1b); // -2147214053
        public const int UnManagedidsbizmgmtcannotdisablebusiness = unchecked((int)0x80041d1a); // -2147214054
        public const int UnManagedidsbizmgmtcannotdeleteprovision = unchecked((int)0x80041d19); // -2147214055
        public const int UnManagedidsbizmgmtcannotdeletebusiness = unchecked((int)0x80041d18); // -2147214056
        public const int UnManagedidsbizmgmtcannotremovepartnershipdefaultuser = unchecked((int)0x80041d17); // -2147214057
        public const int UnManagedidsbizmgmtpartnershipnotinpendingstatus = unchecked((int)0x80041d16); // -2147214058
        public const int UnManagedidsbizmgmtdefaultusernotinpartnerbusiness = unchecked((int)0x80041d15); // -2147214059
        public const int UnManagedidsbizmgmtcallernotinpartnerbusiness = unchecked((int)0x80041d14); // -2147214060
        public const int UnManagedidsbizmgmtdefaultusernotinprimarybusiness = unchecked((int)0x80041d13); // -2147214061
        public const int UnManagedidsbizmgmtcallernotinprimarybusiness = unchecked((int)0x80041d12); // -2147214062
        public const int UnManagedidsbizmgmtpartnershipalreadyexists = unchecked((int)0x80041d11); // -2147214063
        public const int UnManagedidsbizmgmtprimarysameaspartner = unchecked((int)0x80041d10); // -2147214064
        public const int UnManagedidsbizmgmtmisspartnerbusiness = unchecked((int)0x80041d0f); // -2147214065
        public const int UnManagedidsbizmgmtmissprimarybusiness = unchecked((int)0x80041d0e); // -2147214066
        public const int MissingTeamName = unchecked((int)0x80041d0b); // -2147214069
        public const int TeamAdministratorMissedPrivilege = unchecked((int)0x80041d0a); // -2147214070
        public const int UserNotInParentHierarchy = unchecked((int)0x80041d07); // -2147214073
        public const int UnManagedidsbizmgmtusercannotbeownparent = unchecked((int)0x80041d06); // -2147214074
        public const int UnManagedidsbizmgmtcannotmovedefaultuser = unchecked((int)0x80041d05); // -2147214075
        public const int UnManagedidsbizmgmtbusinessparentdiffmerchant = unchecked((int)0x80041d04); // -2147214076
        public const int UnManagedidsbizmgmtdefaultusernotinbusiness = unchecked((int)0x80041d03); // -2147214077
        public const int UnManagedidsbizmgmtmissparentbusiness = unchecked((int)0x80041d02); // -2147214078
        public const int UnManagedidsbizmgmtmissuserdomainname = unchecked((int)0x80041d01); // -2147214079
        public const int UnManagedidsbizmgmtmissbusinessname = unchecked((int)0x80041d00); // -2147214080
        public const int UnManagedidsxmlinvalidread = unchecked((int)0x80041a08); // -2147214840
        public const int UnManagedidsxmlinvalidfield = unchecked((int)0x80041a07); // -2147214841
        public const int UnManagedidsxmlinvalidentityattributes = unchecked((int)0x80041a06); // -2147214842
        public const int UnManagedidsxmlunexpected = unchecked((int)0x80041a05); // -2147214843
        public const int UnManagedidsxmlparseerror = unchecked((int)0x80041a04); // -2147214844
        public const int UnManagedidsxmlinvalidcollectionname = unchecked((int)0x80041a03); // -2147214845
        public const int UnManagedidsxmlinvalidupdate = unchecked((int)0x80041a02); // -2147214846
        public const int UnManagedidsxmlinvalidcreate = unchecked((int)0x80041a01); // -2147214847
        public const int UnManagedidsxmlinvalidentityname = unchecked((int)0x80041a00); // -2147214848
        public const int UnManagedidsnotesnoattachment = unchecked((int)0x80041704); // -2147215612
        public const int UnManagedidsnotesloopbeingcreated = unchecked((int)0x80041703); // -2147215613
        public const int UnManagedidsnotesloopexists = unchecked((int)0x80041702); // -2147215614
        public const int UnManagedidsnotesalreadyattached = unchecked((int)0x80041701); // -2147215615
        public const int UnManagedidsnotesnotedoesnotexist = unchecked((int)0x80041700); // -2147215616
        public const int DuplicatedPrivilege = unchecked((int)0x8004140f); // -2147216369
        public const int MemberHasAlreadyBeenContacted = unchecked((int)0x8004140e); // -2147216370
        public const int TeamInWrongBusiness = unchecked((int)0x8004140d); // -2147216371
        public const int UnManagedidsrolesdeletenonparentrole = unchecked((int)0x8004140c); // -2147216372
        public const int InvalidPrivilegeDepth = unchecked((int)0x8004140b); // -2147216373
        public const int UnManagedidsrolesinvalidrolename = unchecked((int)0x8004140a); // -2147216374
        public const int UserInWrongBusiness = unchecked((int)0x80041409); // -2147216375
        public const int UnManagedidsrolesmissprivid = unchecked((int)0x80041408); // -2147216376
        public const int UnManagedidsrolesmissrolename = unchecked((int)0x80041407); // -2147216377
        public const int UnManagedidsrolesmissbusinessid = unchecked((int)0x80041406); // -2147216378
        public const int UnManagedidsrolesmissroleid = unchecked((int)0x80041405); // -2147216379
        public const int UnManagedidsrolesinvalidtemplateid = unchecked((int)0x80041404); // -2147216380
        public const int RoleAlreadyExists = unchecked((int)0x80041403); // -2147216381
        public const int UnManagedidsrolesroledoesnotexist = unchecked((int)0x80041402); // -2147216382
        public const int UnManagedidsrolesinvalidroleid = unchecked((int)0x80041401); // -2147216383
        public const int UnManagedidsrolesinvalidroledata = unchecked((int)0x80041400); // -2147216384
        public const int QueryBuilderAttributeCannotBeGroupByAndAggregate = unchecked((int)0x80041137); // -2147217097
        public const int SqlArithmeticOverflowError = unchecked((int)0x80041136); // -2147217098
        public const int QueryBuilderInvalidDateGrouping = unchecked((int)0x80041135); // -2147217099
        public const int QueryBuilderAliasRequiredForAggregateOrderBy = unchecked((int)0x80041134); // -2147217100
        public const int QueryBuilderAttributeRequiredForNonAggregateOrderBy = unchecked((int)0x80041133); // -2147217101
        public const int QueryBuilderAliasNotAllowedForNonAggregateOrderBy = unchecked((int)0x80041132); // -2147217102
        public const int QueryBuilderAttributeNotAllowedForAggregateOrderBy = unchecked((int)0x80041131); // -2147217103
        public const int QueryBuilderDuplicateAlias = unchecked((int)0x80041130); // -2147217104
        public const int QueryBuilderInvalidAggregateAttribute = unchecked((int)0x8004112f); // -2147217105
        public const int QueryBuilderDeserializeInvalidGroupBy = unchecked((int)0x8004112e); // -2147217106
        public const int QueryBuilderNoAttrsDistinctConflict = unchecked((int)0x8004112c); // -2147217108
        public const int QueryBuilderInvalidPagingCookie = unchecked((int)0x8004112a); // -2147217110
        public const int QueryBuilderPagingOrderBy = unchecked((int)0x80041129); // -2147217111
        public const int QueryBuilderEntitiesDontMatch = unchecked((int)0x80041128); // -2147217112
        public const int QueryBuilderTopCountGreaterThanZero = unchecked((int)0x80041127); // -2147217113
        public const int QueryBuilderLinkNodeForOrderNotFound = unchecked((int)0x80041126); // -2147217114
        public const int QueryBuilderDeserializeNoDocElemXml = unchecked((int)0x80041125); // -2147217115
        public const int QueryBuilderDeserializeEmptyXml = unchecked((int)0x80041124); // -2147217116
        public const int QueryBuilderElementNotFound = unchecked((int)0x80041123); // -2147217117
        public const int QueryBuilderInvalidFilterType = unchecked((int)0x80041122); // -2147217118
        public const int QueryBuilderInvalidJoinOperator = unchecked((int)0x80041121); // -2147217119
        public const int QueryBuilderInvalidConditionOperator = unchecked((int)0x80041120); // -2147217120
        public const int QueryBuilderInvalidOrderType = unchecked((int)0x8004111f); // -2147217121
        public const int QueryBuilderAttributeNotFound = unchecked((int)0x8004111e); // -2147217122
        public const int QueryBuilderDeserializeInvalidUtcOffset = unchecked((int)0x8004111d); // -2147217123
        public const int QueryBuilderDeserializeInvalidNode = unchecked((int)0x8004111c); // -2147217124
        public const int QueryBuilderDeserializeInvalidGetMinActiveRowVersion = unchecked((int)0x8004111b); // -2147217125
        public const int QueryBuilderDeserializeInvalidAggregate = unchecked((int)0x8004111a); // -2147217126
        public const int QueryBuilderDeserializeInvalidDescending = unchecked((int)0x80041119); // -2147217127
        public const int QueryBuilderDeserializeInvalidNoLock = unchecked((int)0x80041118); // -2147217128
        public const int QueryBuilderDeserializeInvalidLinkType = unchecked((int)0x80041117); // -2147217129
        public const int QueryBuilderDeserializeInvalidMapping = unchecked((int)0x80041116); // -2147217130
        public const int QueryBuilderDeserializeInvalidDistinct = unchecked((int)0x80041115); // -2147217131
        public const int QueryBuilderSerialzeLinkTopCriteria = unchecked((int)0x80041114); // -2147217132
        public const int QueryBuilderColumnSetVersionMissing = unchecked((int)0x80041113); // -2147217133
        public const int QueryBuilderInvalidColumnSetVersion = unchecked((int)0x80041112); // -2147217134
        public const int QueryBuilderAttributePairMismatch = unchecked((int)0x80041111); // -2147217135
        public const int QueryBuilderByAttributeNonEmpty = unchecked((int)0x80041110); // -2147217136
        public const int QueryBuilderByAttributeMismatch = unchecked((int)0x8004110f); // -2147217137
        public const int QueryBuilderMultipleIntersectEntities = unchecked((int)0x8004110e); // -2147217138
        public const int QueryBuilderReportViewDoesNotExist = unchecked((int)0x8004110d); // -2147217139
        public const int QueryBuilderValueGreaterThanZero = unchecked((int)0x8004110c); // -2147217140
        public const int QueryBuilderNoAlias = unchecked((int)0x8004110b); // -2147217141
        public const int QueryBuilderAliasDoesNotExist = unchecked((int)0x8004110a); // -2147217142
        public const int QueryBuilderInvalidAlias = unchecked((int)0x80041109); // -2147217143
        public const int QueryBuilderInvalidValue = unchecked((int)0x80041108); // -2147217144
        public const int QueryBuilderAttributeWithAggregate = unchecked((int)0x80041107); // -2147217145
        public const int QueryBuilderBadCondition = unchecked((int)0x80041106); // -2147217146
        public const int QueryBuilderNoAttribute = unchecked((int)0x80041103); // -2147217149
        public const int QueryBuilderNoEntity = unchecked((int)0x80041102); // -2147217150
        public const int QueryBuilderUnexpected = unchecked((int)0x80041101); // -2147217151
        public const int QueryBuilderInvalidUpdate = unchecked((int)0x80041100); // -2147217152
        public const int QueryBuilderInvalidLogicalOperator = unchecked((int)0x800410fe); // -2147217154
        public const int UnManagedidsmetadatanorelationship = unchecked((int)0x80040e02); // -2147217918
        public const int MetadataNoMapping = unchecked((int)0x80040e01); // -2147217919
        public const int MetadataNotSerializable = unchecked((int)0x80040e03); // -2147217917
        public const int UnManagedidsmetadatanoentity = unchecked((int)0x80040e00); // -2147217920
        public const int UnManagedidscommunicationsnosenderaddress = unchecked((int)0x80040b08); // -2147218680
        public const int UnManagedidscommunicationstemplateinvalidtemplate = unchecked((int)0x80040b07); // -2147218681
        public const int UnManagedidscommunicationsnoparticipationmask = unchecked((int)0x80040b06); // -2147218682
        public const int UnManagedidscommunicationsnorecipients = unchecked((int)0x80040b05); // -2147218683
        public const int EmailRecipientNotSpecified = unchecked((int)0x80040b04); // -2147218684
        public const int UnManagedidscommunicationsnosender = unchecked((int)0x80040b02); // -2147218686
        public const int UnManagedidscommunicationsbadsender = unchecked((int)0x80040b01); // -2147218687
        public const int UnManagedidscommunicationsnopartyaddress = unchecked((int)0x80040b00); // -2147218688
        public const int UnManagedidsjournalingmissingincidentid = unchecked((int)0x80040809); // -2147219447
        public const int UnManagedidsjournalingmissingcontactid = unchecked((int)0x80040808); // -2147219448
        public const int UnManagedidsjournalingmissingopportunityid = unchecked((int)0x80040807); // -2147219449
        public const int UnManagedidsjournalingmissingaccountid = unchecked((int)0x80040806); // -2147219450
        public const int UnManagedidsjournalingmissingleadid = unchecked((int)0x80040805); // -2147219451
        public const int UnManagedidsjournalingmissingeventtype = unchecked((int)0x80040804); // -2147219452
        public const int UnManagedidsjournalinginvalideventtype = unchecked((int)0x80040803); // -2147219453
        public const int UnManagedidsjournalingmissingeventdirection = unchecked((int)0x80040802); // -2147219454
        public const int UnManagedidsjournalingunsupportedobjecttype = unchecked((int)0x80040801); // -2147219455
        public const int SdkEntityDoesNotSupportMessage = unchecked((int)0x80040800); // -2147219456
        public const int OpportunityAlreadyInOpenState = unchecked((int)0x8004051a); // -2147220198
        public const int LeadAlreadyInClosedState = unchecked((int)0x80040519); // -2147220199
        public const int LeadAlreadyInOpenState = unchecked((int)0x80040518); // -2147220200
        public const int CustomerIsInactive = unchecked((int)0x80040517); // -2147220201
        public const int OpportunityCannotBeClosed = unchecked((int)0x80040516); // -2147220202
        public const int OpportunityIsAlreadyClosed = unchecked((int)0x80040515); // -2147220203
        public const int UnManagedidscustomeraddresstypeinvalid = unchecked((int)0x80040514); // -2147220204
        public const int UnManagedidsleadnotassignedtocaller = unchecked((int)0x80040513); // -2147220205
        public const int UnManagedidscontacthaschildopportunities = unchecked((int)0x80040512); // -2147220206
        public const int UnManagedidsaccounthaschildopportunities = unchecked((int)0x80040511); // -2147220207
        public const int UnManagedidsleadoneaccount = unchecked((int)0x80040510); // -2147220208
        public const int UnManagedidsopportunityorphan = unchecked((int)0x8004050f); // -2147220209
        public const int UnManagedidsopportunityoneaccount = unchecked((int)0x8004050e); // -2147220210
        public const int UnManagedidsleadusercannotreject = unchecked((int)0x8004050d); // -2147220211
        public const int UnManagedidsleadnotassigned = unchecked((int)0x8004050c); // -2147220212
        public const int UnManagedidsleadnoparent = unchecked((int)0x8004050b); // -2147220213
        public const int ContactLoopBeingCreated = unchecked((int)0x8004050a); // -2147220214
        public const int ContactLoopExists = unchecked((int)0x80040509); // -2147220215
        public const int PresentParentAccountAndParentContact = unchecked((int)0x80040508); // -2147220216
        public const int AccountLoopBeingCreated = unchecked((int)0x80040507); // -2147220217
        public const int AccountLoopExists = unchecked((int)0x80040506); // -2147220218
        public const int UnManagedidsopportunitymissingparent = unchecked((int)0x80040505); // -2147220219
        public const int UnManagedidsopportunityinvalidparent = unchecked((int)0x80040504); // -2147220220
        public const int ContactDoesNotExist = unchecked((int)0x80040503); // -2147220221
        public const int AccountDoesNotExist = unchecked((int)0x80040502); // -2147220222
        public const int UnManagedidsleaddoesnotexist = unchecked((int)0x80040501); // -2147220223
        public const int UnManagedidsopportunitydoesnotexist = unchecked((int)0x80040500); // -2147220224
        public const int ReportDoesNotExist = unchecked((int)0x80040499); // -2147220327
        public const int ReportLoopBeingCreated = unchecked((int)0x80040498); // -2147220328
        public const int ReportLoopExists = unchecked((int)0x80040497); // -2147220329
        public const int ParentReportLinksToSameNameChild = unchecked((int)0x80040496); // -2147220330
        public const int DuplicateReportVisibility = unchecked((int)0x80040495); // -2147220331
        public const int ReportRenderError = unchecked((int)0x80040494); // -2147220332
        public const int SubReportDoesNotExist = unchecked((int)0x80040493); // -2147220333
        public const int SrsDataConnectorNotInstalled = unchecked((int)0x80040492); // -2147220334
        public const int InvalidCustomReportingWizardXml = unchecked((int)0x80040491); // -2147220335
        public const int UpdateNonCustomReportFromTemplate = unchecked((int)0x80040490); // -2147220336
        public const int SnapshotReportNotReady = unchecked((int)0x80040489); // -2147220343
        public const int ExistingExternalReport = unchecked((int)0x80040488); // -2147220344
        public const int ParentReportNotSupported = unchecked((int)0x80040487); // -2147220345
        public const int ParentReportDoesNotReferenceChild = unchecked((int)0x80040486); // -2147220346
        public const int MultipleParentReportsFound = unchecked((int)0x80040485); // -2147220347
        public const int ReportingServicesReportExpected = unchecked((int)0x80040484); // -2147220348
        public const int InvalidTransformationParameter = unchecked((int)0x80040389); // -2147220599
        public const int ReflexiveEntityParentOrChildDoesNotExist = unchecked((int)0x80040388); // -2147220600
        public const int EntityLoopBeingCreated = unchecked((int)0x80040387); // -2147220601
        public const int EntityLoopExists = unchecked((int)0x80040386); // -2147220602
        public const int UnsupportedProcessCode = unchecked((int)0x80040385); // -2147220603
        public const int NoOutputTransformationParameterMappingFound = unchecked((int)0x80040384); // -2147220604
        public const int RequiredColumnsNotFoundInImportFile = unchecked((int)0x80040383); // -2147220605
        public const int InvalidTransformationParameterMapping = unchecked((int)0x80040382); // -2147220606
        public const int UnmappedTransformationOutputDataFound = unchecked((int)0x80040381); // -2147220607
        public const int InvalidTransformationParameterDataType = unchecked((int)0x80040380); // -2147220608
        public const int ArrayMappingFoundForSingletonParameter = unchecked((int)0x8004037f); // -2147220609
        public const int SingletonMappingFoundForArrayParameter = unchecked((int)0x8004037e); // -2147220610
        public const int IncompleteTransformationParameterMappingsFound = unchecked((int)0x8004037d); // -2147220611
        public const int InvalidTransformationParameterMappings = unchecked((int)0x8004037c); // -2147220612
        public const int GenericTransformationInvocationError = unchecked((int)0x8004037b); // -2147220613
        public const int InvalidTransformationType = unchecked((int)0x8004037a); // -2147220614
        public const int UnableToLoadTransformationType = unchecked((int)0x80040379); // -2147220615
        public const int UnableToLoadTransformationAssembly = unchecked((int)0x80040378); // -2147220616
        public const int InvalidColumnMapping = unchecked((int)0x80040377); // -2147220617
        public const int CannotModifyOldDataFromImport = unchecked((int)0x80040376); // -2147220618
        public const int ImportFileTooLargeToUpload = unchecked((int)0x80040375); // -2147220619
        public const int InvalidImportFileContent = unchecked((int)0x80040374); // -2147220620
        public const int EmptyRecord = unchecked((int)0x80040373); // -2147220621
        public const int LongParseRow = unchecked((int)0x80040372); // -2147220622
        public const int ParseMustBeCalledBeforeTransform = unchecked((int)0x80040371); // -2147220623
        public const int HeaderValueDoesNotMatchAttributeDisplayLabel = unchecked((int)0x80040370); // -2147220624
        public const int InvalidTargetEntity = unchecked((int)0x80040369); // -2147220631
        public const int NoHeaderColumnFound = unchecked((int)0x80040368); // -2147220632
        public const int ParsingMetadataNotFound = unchecked((int)0x80040367); // -2147220633
        public const int EmptyHeaderRow = unchecked((int)0x80040366); // -2147220634
        public const int EmptyContent = unchecked((int)0x80040365); // -2147220635
        public const int InvalidIsFirstRowHeaderForUseSystemMap = unchecked((int)0x80040364); // -2147220636
        public const int InvalidGuid = unchecked((int)0x80040363); // -2147220637
        public const int GuidNotPresent = unchecked((int)0x80040362); // -2147220638
        public const int OwnerValueNotMapped = unchecked((int)0x80040361); // -2147220639
        public const int PicklistValueNotMapped = unchecked((int)0x80040360); // -2147220640
        public const int ErrorInDelete = unchecked((int)0x8004035a); // -2147220646
        public const int ErrorIncreate = unchecked((int)0x80040359); // -2147220647
        public const int ErrorInUpdate = unchecked((int)0x80040358); // -2147220648
        public const int ErrorInSetState = unchecked((int)0x80040357); // -2147220649
        public const int InvalidDataFormat = unchecked((int)0x80040356); // -2147220650
        public const int InvalidFormatForDataDelimiter = unchecked((int)0x80040355); // -2147220651
        public const int CrmUserDoesNotExist = unchecked((int)0x80040354); // -2147220652
        public const int LookupNotFound = unchecked((int)0x80040353); // -2147220653
        public const int DuplicateLookupFound = unchecked((int)0x80040352); // -2147220654
        public const int InvalidImportFileData = unchecked((int)0x80040351); // -2147220655
        public const int InvalidXmlSsContent = unchecked((int)0x80040350); // -2147220656
        public const int InvalidImportFileParseData = unchecked((int)0x80040349); // -2147220663
        public const int InvalidValueForFileType = unchecked((int)0x80040348); // -2147220664
        public const int EmptyImportFileRow = unchecked((int)0x80040347); // -2147220665
        public const int ErrorInParseRow = unchecked((int)0x80040346); // -2147220666
        public const int DataColumnsNumberMismatch = unchecked((int)0x80040345); // -2147220667
        public const int InvalidHeaderColumn = unchecked((int)0x80040344); // -2147220668
        public const int OwnerMappingExistsWithSourceSystemUserName = unchecked((int)0x80040343); // -2147220669
        public const int PickListMappingExistsWithSourceValue = unchecked((int)0x80040342); // -2147220670
        public const int InvalidValueForDataDelimiter = unchecked((int)0x80040341); // -2147220671
        public const int InvalidValueForFieldDelimiter = unchecked((int)0x80040340); // -2147220672
        public const int PickListMappingExistsForTargetValue = unchecked((int)0x8004033f); // -2147220673
        public const int MappingExistsForTargetAttribute = unchecked((int)0x8004033e); // -2147220674
        public const int SourceEntityMappedToMultipleTargets = unchecked((int)0x8004033d); // -2147220675
        public const int AttributeNotOfTypePicklist = unchecked((int)0x8004033c); // -2147220676
        public const int AttributeNotOfTypeReference = unchecked((int)0x80040390); // -2147220592
        public const int TargetEntityNotFound = unchecked((int)0x80040391); // -2147220591
        public const int TargetAttributeNotFound = unchecked((int)0x80040392); // -2147220590
        public const int PicklistValueNotFound = unchecked((int)0x80040393); // -2147220589
        public const int TargetAttributeInvalidForMap = unchecked((int)0x80040394); // -2147220588
        public const int TargetEntityInvalidForMap = unchecked((int)0x80040395); // -2147220587
        public const int InvalidFileBadCharacters = unchecked((int)0x80040396); // -2147220586
        public const int ErrorsInImportFiles = unchecked((int)0x8004034a); // -2147220662
        public const int InvalidOperationWhenListIsNotActive = unchecked((int)0x8004033a); // -2147220678
        public const int InvalidOperationWhenPartyIsNotActive = unchecked((int)0x8004033b); // -2147220677
        public const int AsyncOperationSuspendedOrLocked = unchecked((int)0x80040339); // -2147220679
        public const int DuplicateHeaderColumn = unchecked((int)0x80040338); // -2147220680
        public const int EmptyHeaderColumn = unchecked((int)0x80040337); // -2147220681
        public const int InvalidColumnNumber = unchecked((int)0x80040336); // -2147220682
        public const int TransformMustBeCalledBeforeImport = unchecked((int)0x80040335); // -2147220683
        public const int OperationCanBeCalledOnlyOnce = unchecked((int)0x80040334); // -2147220684
        public const int DuplicateRecordsFound = unchecked((int)0x80040333); // -2147220685
        public const int CampaignActivityClosed = unchecked((int)0x80040331); // -2147220687
        public const int UnexpectedErrorInMailMerge = unchecked((int)0x80040330); // -2147220688
        public const int UserCancelledMailMerge = unchecked((int)0x8004032f); // -2147220689
        public const int FilteredDuetoMissingEmailAddress = unchecked((int)0x8004032e); // -2147220690
        public const int CannotDeleteAsBackgroundOperationInProgress = unchecked((int)0x8004032b); // -2147220693
        public const int FilteredDuetoInactiveState = unchecked((int)0x8004032a); // -2147220694
        public const int MissingBowfRules = unchecked((int)0x80040329); // -2147220695
        public const int CannotSpecifyOwnerForActivityPropagation = unchecked((int)0x80040327); // -2147220697
        public const int CampaignActivityAlreadyPropagated = unchecked((int)0x80040326); // -2147220698
        public const int FilteredDuetoAntiSpam = unchecked((int)0x80040325); // -2147220699
        public const int TemplateTypeNotSupportedForUnsubscribeAcknowledgement = unchecked((int)0x80040324); // -2147220700
        public const int ErrorInImportConfig = unchecked((int)0x80040323); // -2147220701
        public const int ImportConfigNotSpecified = unchecked((int)0x80040322); // -2147220702
        public const int InvalidActivityType = unchecked((int)0x80040321); // -2147220703
        public const int UnsupportedParameter = unchecked((int)0x80040320); // -2147220704
        public const int MissingParameter = unchecked((int)0x8004031f); // -2147220705
        public const int CannotSpecifyCommunicationAttributeOnActivityForPropagation = unchecked((int)0x8004031e); // -2147220706
        public const int CannotSpecifyRecipientForActivityPropagation = unchecked((int)0x8004031d); // -2147220707
        public const int CannotSpecifyAttendeeForAppointmentPropagation = unchecked((int)0x8004031c); // -2147220708
        public const int CannotSpecifySenderForActivityPropagation = unchecked((int)0x8004031b); // -2147220709
        public const int CannotSpecifyOrganizerForAppointmentPropagation = unchecked((int)0x8004031a); // -2147220710
        public const int InvalidRegardingObjectTypeCode = unchecked((int)0x80040319); // -2147220711
        public const int UnspecifiedActivityXmlForCampaignActivityPropagate = unchecked((int)0x80040318); // -2147220712
        public const int MoneySizeExceeded = unchecked((int)0x80040317); // -2147220713
        public const int ExtraPartyInformation = unchecked((int)0x80040316); // -2147220714
        public const int NotSupported = unchecked((int)0x80040315); // -2147220715
        public const int InvalidOperationForClosedOrCancelledCampaignActivity = unchecked((int)0x80040314); // -2147220716
        public const int InvalidEmailTemplate = unchecked((int)0x80040313); // -2147220717
        public const int CannotCreateResponseForTemplate = unchecked((int)0x80040312); // -2147220718
        public const int CannotPropagateCamapaignActivityForTemplate = unchecked((int)0x80040311); // -2147220719
        public const int InvalidChannelForCampaignActivityPropagate = unchecked((int)0x80040310); // -2147220720
        public const int InvalidActivityTypeForCampaignActivityPropagate = unchecked((int)0x8004030f); // -2147220721
        public const int ObjectNotRelatedToCampaign = unchecked((int)0x8004030e); // -2147220722
        public const int CannotRelateObjectTypeToCampaignActivity = unchecked((int)0x8004030d); // -2147220723
        public const int CannotUpdateCampaignForCampaignResponse = unchecked((int)0x8004030c); // -2147220724
        public const int CannotUpdateCampaignForCampaignActivity = unchecked((int)0x8004030b); // -2147220725
        public const int CampaignNotSpecifiedForCampaignResponse = unchecked((int)0x8004030a); // -2147220726
        public const int CampaignNotSpecifiedForCampaignActivity = unchecked((int)0x80040309); // -2147220727
        public const int CannotRelateObjectTypeToCampaign = unchecked((int)0x80040307); // -2147220729
        public const int CannotCopyIncompatibleListType = unchecked((int)0x80040306); // -2147220730
        public const int InvalidActivityTypeForList = unchecked((int)0x80040305); // -2147220731
        public const int CannotAssociateInactiveItemToCampaign = unchecked((int)0x80040304); // -2147220732
        public const int InvalidFetchXml = unchecked((int)0x80040303); // -2147220733
        public const int InvalidOperationWhenListLocked = unchecked((int)0x80040302); // -2147220734
        public const int UnsupportedListMemberType = unchecked((int)0x80040301); // -2147220735
        public const int CannotMoveDisabledUser = unchecked((int)0x80040267); // -2147220889
        public const int InvalidPrimaryKey = unchecked((int)0x80040266); // -2147220890
        public const int IsvAborted = unchecked((int)0x80040265); // -2147220891
        public const int CannotAssignOutlookFilters = unchecked((int)0x80040264); // -2147220892
        public const int CannotCreateOutlookFilters = unchecked((int)0x80040263); // -2147220893
        public const int CannotGrantAccessToOutlookFilters = unchecked((int)0x80040268); // -2147220888
        public const int CannotModifyAccessToOutlookFilters = unchecked((int)0x80040269); // -2147220887
        public const int CannotRevokeAccessToOutlookFilters = unchecked((int)0x80040270); // -2147220880
        public const int CannotGrantAccessToOfflineFilters = unchecked((int)0x80040271); // -2147220879
        public const int CannotModifyAccessToOfflineFilters = unchecked((int)0x80040272); // -2147220878
        public const int CannotRevokeAccessToOfflineFilters = unchecked((int)0x80040273); // -2147220877
        public const int DuplicateOutlookAppointment = unchecked((int)0x80040274); // -2147220876
        public const int AppointmentScheduleNotSet = unchecked((int)0x80040275); // -2147220875
        public const int PrivilegeCreateIsDisabledForOrganization = unchecked((int)0x80040276); // -2147220874
        public const int UnauthorizedAccess = unchecked((int)0x80040277); // -2147220873
        public const int InvalidCharactersInField = unchecked((int)0x80040278); // -2147220872
        public const int CannotChangeStateOfNonpublicView = unchecked((int)0x80040279); // -2147220871
        public const int CannotDeactivateDefaultView = unchecked((int)0x8004027a); // -2147220870
        public const int CannotSetInactiveViewAsDefault = unchecked((int)0x8004027b); // -2147220869
        public const int CannotExceedFilterLimit = unchecked((int)0x8004027c); // -2147220868
        public const int CannotHaveMultipleDefaultFilterTemplates = unchecked((int)0x8004027d); // -2147220867
        public const int CrmConstraintParsingError = unchecked((int)0x80040262); // -2147220894
        public const int CrmConstraintEvaluationError = unchecked((int)0x80040261); // -2147220895
        public const int CrmExpressionEvaluationError = unchecked((int)0x80040260); // -2147220896
        public const int CrmExpressionParametersParsingError = unchecked((int)0x8004025f); // -2147220897
        public const int CrmExpressionBodyParsingError = unchecked((int)0x8004025e); // -2147220898
        public const int CrmExpressionParsingError = unchecked((int)0x8004025d); // -2147220899
        public const int CrmMalformedExpressionError = unchecked((int)0x8004025c); // -2147220900
        public const int CalloutException = unchecked((int)0x8004025b); // -2147220901
        public const int DateTimeFormatFailed = unchecked((int)0x8004025a); // -2147220902
        public const int NumberFormatFailed = unchecked((int)0x80040259); // -2147220903
        public const int InvalidRestore = unchecked((int)0x80040258); // -2147220904
        public const int InvalidCaller = unchecked((int)0x80040257); // -2147220905
        public const int CrmSecurityError = unchecked((int)0x80040256); // -2147220906
        public const int TransactionAborted = unchecked((int)0x80040255); // -2147220907
        public const int CannotBindToSession = unchecked((int)0x80040254); // -2147220908
        public const int SessionTokenUnavailable = unchecked((int)0x80040253); // -2147220909
        public const int TransactionNotCommited = unchecked((int)0x80040252); // -2147220910
        public const int TransactionNotStarted = unchecked((int)0x80040251); // -2147220911
        public const int MultipleChildPicklist = unchecked((int)0x80040250); // -2147220912
        public const int InvalidSingletonResults = unchecked((int)0x8004024f); // -2147220913
        public const int FailedToLoadAssembly = unchecked((int)0x8004024e); // -2147220914
        public const int CrmQueryExpressionNotInitialized = unchecked((int)0x8004024d); // -2147220915
        public const int InvalidRegistryKey = unchecked((int)0x8004024c); // -2147220916
        public const int InvalidPriv = unchecked((int)0x8004024b); // -2147220917
        public const int MetadataNotFound = unchecked((int)0x8004024a); // -2147220918
        public const int InvalidEntityClassException = unchecked((int)0x80040249); // -2147220919
        public const int InvalidXmlEntityNameException = unchecked((int)0x80040248); // -2147220920
        public const int InvalidXmlCollectionNameException = unchecked((int)0x80040247); // -2147220921
        public const int InvalidRecurrenceRule = unchecked((int)0x80040246); // -2147220922
        public const int CrmImpersonationError = unchecked((int)0x80040245); // -2147220923
        public const int ServiceInstantiationFailed = unchecked((int)0x80040244); // -2147220924
        public const int EntityInstantiationFailed = unchecked((int)0x80040243); // -2147220925
        public const int FormTransitionError = unchecked((int)0x80040242); // -2147220926
        public const int UserTimeConvertException = unchecked((int)0x80040241); // -2147220927
        public const int UserTimeZoneException = unchecked((int)0x80040240); // -2147220928
        public const int InvalidConnectionString = unchecked((int)0x8004023f); // -2147220929
        public const int OpenCrmDbConnection = unchecked((int)0x8004023e); // -2147220930
        public const int UnpopulatedPrimaryKey = unchecked((int)0x8004023d); // -2147220931
        public const int InvalidVersion = unchecked((int)0x8004023c); // -2147220932
        public const int InvalidOperation = unchecked((int)0x8004023b); // -2147220933
        public const int InvalidMetadata = unchecked((int)0x8004023a); // -2147220934
        public const int InvalidDateTime = unchecked((int)0x80040239); // -2147220935
        public const int UnManagedidscannotdefaultprivateview = unchecked((int)0x80040238); // -2147220936
        public const int DuplicateRecord = unchecked((int)0x80040237); // -2147220937
        public const int UnManagedidsnorelationship = unchecked((int)0x80040236); // -2147220938
        public const int MissingQueryType = unchecked((int)0x80040235); // -2147220939
        public const int InvalidRollupType = unchecked((int)0x80040234); // -2147220940
        public const int InvalidState = unchecked((int)0x80040233); // -2147220941
        public const int UnManagedidsviewisnotsharable = unchecked((int)0x80040232); // -2147220942
        public const int PrincipalPrivilegeDenied = unchecked((int)0x80040231); // -2147220943
        public const int CannotUpdateObjectBecauseItIsInactive = unchecked((int)0x80040230); // -2147220944
        public const int CannotDeleteCannedView = unchecked((int)0x8004022f); // -2147220945
        public const int CannotUpdateBecauseItIsReadOnly = unchecked((int)0x8004022e); // -2147220946
        public const int InvalidCustomer = unchecked((int)0x8004022d); // -2147220947
        public const int UnManagedidsdataoutofrange = unchecked((int)0x8004022c); // -2147220948
        public const int UnManagedidsownernotenabled = unchecked((int)0x8004022b); // -2147220949
        public const int BusinessManagementObjectAlreadyExists = unchecked((int)0x8004022a); // -2147220950
        public const int InvalidOwnerId = unchecked((int)0x80040229); // -2147220951
        public const int CannotDeleteAsItIsReadOnly = unchecked((int)0x80040228); // -2147220952
        public const int CannotDeleteDueToAssociation = unchecked((int)0x80040227); // -2147220953
        public const int UnManagedidsanonymousenabled = unchecked((int)0x80040226); // -2147220954
        public const int UnManagedidsusernotenabled = unchecked((int)0x80040225); // -2147220955
        public const int BusinessNotEnabled = unchecked((int)0x8004032c); // -2147220692
        public const int CannotAssignToDisabledBusiness = unchecked((int)0x8004032d); // -2147220691
        public const int IsvUnExpected = unchecked((int)0x80040224); // -2147220956
        public const int OnlyOwnerCanRevoke = unchecked((int)0x80040223); // -2147220957
        public const int UnManagedidsoutofmemory = unchecked((int)0x80040222); // -2147220958
        public const int UnManagedidscannotassigntobusiness = unchecked((int)0x80040221); // -2147220959
        public const int PrivilegeDenied = unchecked((int)0x80040220); // -2147220960
        public const int InvalidObjectTypes = unchecked((int)0x8004021f); // -2147220961
        public const int UnManagedidscannotgrantorrevokeaccesstobusiness = unchecked((int)0x8004021e); // -2147220962
        public const int UnManagedidsinvaliduseridorbusinessidorusersbusinessinvalid = unchecked((int)0x8004021d); // -2147220963
        public const int UnManagedidspresentuseridandteamid = unchecked((int)0x8004021c); // -2147220964
        public const int MissingUserId = unchecked((int)0x8004021b); // -2147220965
        public const int MissingBusinessId = unchecked((int)0x8004021a); // -2147220966
        public const int NotImplemented = unchecked((int)0x80040219); // -2147220967
        public const int InvalidPointer = unchecked((int)0x80040218); // -2147220968
        public const int ObjectDoesNotExist = unchecked((int)0x80040217); // -2147220969
        public const int UnExpected = unchecked((int)0x80040216); // -2147220970
        public const int MissingOwner = unchecked((int)0x80040215); // -2147220971
        public const int CannotShareWithOwner = unchecked((int)0x80040214); // -2147220972
        public const int UnManagedidsinvalidvisibilitymodificationaccess = unchecked((int)0x80040213); // -2147220973
        public const int UnManagedidsinvalidowninguser = unchecked((int)0x80040212); // -2147220974
        public const int UnManagedidsinvalidassociation = unchecked((int)0x80040211); // -2147220975
        public const int InvalidAssigneeId = unchecked((int)0x80040210); // -2147220976
        public const int UnManagedidsfailureinittoken = unchecked((int)0x8004020f); // -2147220977
        public const int UnManagedidsinvalidvisibility = unchecked((int)0x8004020e); // -2147220978
        public const int InvalidAccessRights = unchecked((int)0x8004020d); // -2147220979
        public const int InvalidSharee = unchecked((int)0x8004020c); // -2147220980
        public const int UnManagedidsinvaliditemid = unchecked((int)0x8004020b); // -2147220981
        public const int UnManagedidsinvalidorgid = unchecked((int)0x8004020a); // -2147220982
        public const int UnManagedidsinvalidbusinessid = unchecked((int)0x80040209); // -2147220983
        public const int UnManagedidsinvalidteamid = unchecked((int)0x80040208); // -2147220984
        public const int UnManagedidsinvaliduserid = unchecked((int)0x80040207); // -2147220985
        public const int InvalidParentId = unchecked((int)0x80040206); // -2147220986
        public const int InvalidParent = unchecked((int)0x80040205); // -2147220987
        public const int InvalidUserAuth = unchecked((int)0x80040204); // -2147220988
        public const int InvalidArgument = unchecked((int)0x80040203); // -2147220989
        public const int EmptyXml = unchecked((int)0x80040202); // -2147220990
        public const int InvalidXml = unchecked((int)0x80040201); // -2147220991
        public const int RequiredFieldMissing = unchecked((int)0x80040200); // -2147220992
        public const int SearchTextLenExceeded = unchecked((int)0x800401ff); // -2147220993
        public const int CannotAssignOfflineFilters = unchecked((int)0x800404ff); // -2147220225
        public const int ArticleIsPublished = unchecked((int)0x800404fe); // -2147220226
        public const int InvalidArticleTemplateState = unchecked((int)0x800404fd); // -2147220227
        public const int InvalidArticleStateTransition = unchecked((int)0x800404fc); // -2147220228
        public const int InvalidArticleState = unchecked((int)0x800404fb); // -2147220229
        public const int NullKbArticleTemplateId = unchecked((int)0x800404fa); // -2147220230
        public const int NullArticleTemplateStructureXml = unchecked((int)0x800404f9); // -2147220231
        public const int NullArticleTemplateFormatXml = unchecked((int)0x800404f8); // -2147220232
        public const int NullArticleXml = unchecked((int)0x800404f7); // -2147220233
        public const int InvalidContractDetailId = unchecked((int)0x800404f6); // -2147220234
        public const int InvalidTotalPrice = unchecked((int)0x800404f5); // -2147220235
        public const int InvalidTotalDiscount = unchecked((int)0x800404f4); // -2147220236
        public const int InvalidNetPrice = unchecked((int)0x800404f3); // -2147220237
        public const int InvalidAllotmentsRemaining = unchecked((int)0x800404f2); // -2147220238
        public const int InvalidAllotmentsUsed = unchecked((int)0x800404f1); // -2147220239
        public const int InvalidAllotmentsTotal = unchecked((int)0x800404f0); // -2147220240
        public const int InvalidAllotmentsCalc = unchecked((int)0x800404ef); // -2147220241
        public const int CannotRouteToSameQueue = unchecked((int)0x8004051b); // -2147220197
        public const int CannotAddSingleQueueEnabledEntityToQueue = unchecked((int)0x8004051c); // -2147220196
        public const int CannotUpdateDeactivatedQueueItem = unchecked((int)0x8004051d); // -2147220195
        public const int CannotCreateQueueItemInactiveObject = unchecked((int)0x8004051e); // -2147220194
        public const int InsufficientPrivilegeToQueueOwner = unchecked((int)0x80040520); // -2147220192
        public const int NoPrivilegeToWorker = unchecked((int)0x80040521); // -2147220191
        public const int CannotAddQueueItemsToInactiveQueue = unchecked((int)0x80040522); // -2147220190
        public const int EmailAlreadyExistsInDestinationQueue = unchecked((int)0x80040523); // -2147220189
        public const int CouldNotFindQueueItemInQueue = unchecked((int)0x80040524); // -2147220188
        public const int MultipleQueueItemsFound = unchecked((int)0x80040525); // -2147220187
        public const int ActiveQueueItemAlreadyExists = unchecked((int)0x80040526); // -2147220186
        public const int CannotRouteInactiveQueueItem = unchecked((int)0x80040527); // -2147220185
        public const int QueueIdNotPresent = unchecked((int)0x80040528); // -2147220184
        public const int QueueItemNotPresent = unchecked((int)0x80040529); // -2147220183
        public const int CannotUpdatePrivateOrWipQueue = unchecked((int)0x800404ee); // -2147220242
        public const int CannotFindUserQueue = unchecked((int)0x800404ec); // -2147220244
        public const int CannotFindObjectInQueue = unchecked((int)0x800404eb); // -2147220245
        public const int CannotRouteToQueue = unchecked((int)0x800404ea); // -2147220246
        public const int RouteTypeUnsupported = unchecked((int)0x800404e9); // -2147220247
        public const int UserIdOrQueueNotSet = unchecked((int)0x800404e8); // -2147220248
        public const int RoutingNotAllowed = unchecked((int)0x800404e7); // -2147220249
        public const int CannotUpdateMetricOnChildGoal = unchecked((int)0x80044900); // -2147202816
        public const int CannotUpdateGoalPeriodInfoChildGoal = unchecked((int)0x80044901); // -2147202815
        public const int CannotUpdateMetricOnGoalWithChildren = unchecked((int)0x80044902); // -2147202814
        public const int FiscalPeriodGoalMissingInfo = unchecked((int)0x80044903); // -2147202813
        public const int CustomPeriodGoalHavingExtraInfo = unchecked((int)0x80044904); // -2147202812
        public const int ParentChildMetricIdDiffers = unchecked((int)0x80044905); // -2147202811
        public const int ParentChildPeriodAttributesDiffer = unchecked((int)0x80044906); // -2147202810
        public const int CustomPeriodGoalMissingInfo = unchecked((int)0x80044907); // -2147202809
        public const int GoalMissingPeriodTypeInfo = unchecked((int)0x80044908); // -2147202808
        public const int ParticipatingQueryEntityMismatch = unchecked((int)0x80044909); // -2147202807
        public const int CannotUpdateGoalPeriodInfoClosedGoal = unchecked((int)0x80044910); // -2147202800
        public const int CannotUpdateRollupFields = unchecked((int)0x80044911); // -2147202799
        public const int CannotDeleteMetricWithGoals = unchecked((int)0x80044800); // -2147203072
        public const int CannotUpdateRollupAttributeWithClosedGoals = unchecked((int)0x80044801); // -2147203071
        public const int MetricNameAlreadyExists = unchecked((int)0x80044802); // -2147203070
        public const int CannotUpdateMetricWithGoals = unchecked((int)0x80044803); // -2147203069
        public const int CannotCreateUpdateSourceAttribute = unchecked((int)0x80044804); // -2147203068
        public const int InvalidDateAttribute = unchecked((int)0x80044805); // -2147203067
        public const int InvalidSourceEntityAttribute = unchecked((int)0x80044806); // -2147203066
        public const int GoalAttributeAlreadyMapped = unchecked((int)0x80044807); // -2147203065
        public const int InvalidSourceAttributeType = unchecked((int)0x80044808); // -2147203064
        public const int MaxLimitForRollupAttribute = unchecked((int)0x8004480a); // -2147203062
        public const int InvalidGoalAttribute = unchecked((int)0x8004480b); // -2147203061
        public const int CannotUpdateParentAndDependents = unchecked((int)0x8004480c); // -2147203060
        public const int UserDoesNotHaveSendAsAllowed = unchecked((int)0x8004480d); // -2147203059
        public const int CannotUpdateQuoteCurrency = unchecked((int)0x8004480e); // -2147203058
        public const int UserDoesNotHaveSendAsForQueue = unchecked((int)0x8004480f); // -2147203057
        public const int InvalidSourceStateValue = unchecked((int)0x80044810); // -2147203056
        public const int InvalidSourceStatusValue = unchecked((int)0x80044811); // -2147203055
        public const int InvalidEntityForDateAttribute = unchecked((int)0x80044812); // -2147203054
        public const int InvalidEntityForRollup = unchecked((int)0x80044813); // -2147203053
        public const int InvalidFiscalPeriod = unchecked((int)0x80044814); // -2147203052
        public const int UnManagedchildentityisnotchild = unchecked((int)0x800404e6); // -2147220250
        public const int UnManagedmissingparententity = unchecked((int)0x800404e5); // -2147220251
        public const int UnManagedunablegetexecutioncontext = unchecked((int)0x800404e4); // -2147220252
        public const int UnManagedpendingtrxexists = unchecked((int)0x800404e3); // -2147220253
        public const int UnManagedinvalidtrxcountforcommit = unchecked((int)0x800404e2); // -2147220254
        public const int UnManagedinvalidtrxcountforrollback = unchecked((int)0x800404e1); // -2147220255
        public const int UnManagedunableswitchusercontext = unchecked((int)0x800404e0); // -2147220256
        public const int UnManagedmissingdataaccess = unchecked((int)0x800404df); // -2147220257
        public const int UnManagedinvalidcharacterdataforaggregate = unchecked((int)0x800404de); // -2147220258
        public const int UnManagedtrxinterophandlerset = unchecked((int)0x800404dd); // -2147220259
        public const int UnManagedinvalidbinaryfield = unchecked((int)0x800404dc); // -2147220260
        public const int UnManagedinvaludidispatchfield = unchecked((int)0x800404db); // -2147220261
        public const int UnManagedinvaliddbdatefield = unchecked((int)0x800404da); // -2147220262
        public const int UnManagedinvalddbtimefield = unchecked((int)0x800404d9); // -2147220263
        public const int UnManagedinvalidfieldtype = unchecked((int)0x800404d8); // -2147220264
        public const int UnManagedinvalidstreamfield = unchecked((int)0x800404d7); // -2147220265
        public const int UnManagedinvalidparametertypeforparameterizedquery = unchecked((int)0x800404d6); // -2147220266
        public const int UnManagedinvaliddynamicparameteraccessor = unchecked((int)0x800404d5); // -2147220267
        public const int UnManagedunablegetsessiontokennotrx = unchecked((int)0x800404d4); // -2147220268
        public const int UnManagedunablegetsessiontoken = unchecked((int)0x800404d3); // -2147220269
        public const int UnManagedinvalidsecurityprincipal = unchecked((int)0x800404d2); // -2147220270
        public const int UnManagedmissingpreviousownertype = unchecked((int)0x800404d0); // -2147220272
        public const int UnManagedinvalidprivilegeid = unchecked((int)0x800404ce); // -2147220274
        public const int UnManagedinvalidprivilegeusergroup = unchecked((int)0x800404cd); // -2147220275
        public const int UnManagedunexpectedpropertytype = unchecked((int)0x800404cc); // -2147220276
        public const int UnManagedmissingaddressentity = unchecked((int)0x800404cb); // -2147220277
        public const int UnManagederroraddingfiltertoqueryplan = unchecked((int)0x800404ca); // -2147220278
        public const int UnManagedmissingreferencesfromrelationship = unchecked((int)0x800404c9); // -2147220279
        public const int UnManagedmissingreferencingattribute = unchecked((int)0x800404c8); // -2147220280
        public const int UnManagedinvalidoperator = unchecked((int)0x800404c7); // -2147220281
        public const int UnManagedunabletoaccessqueryplanfilter = unchecked((int)0x800404c6); // -2147220282
        public const int UnManagedmissingattributefortag = unchecked((int)0x800404c5); // -2147220283
        public const int UnManagederrorprocessingfilternodes = unchecked((int)0x800404c4); // -2147220284
        public const int UnManagedunabletolocateconditionfilter = unchecked((int)0x800404c3); // -2147220285
        public const int UnManagedinvalidpagevalue = unchecked((int)0x800404c2); // -2147220286
        public const int UnManagedinvalidcountvalue = unchecked((int)0x800404c1); // -2147220287
        public const int UnManagedinvalidversionvalue = unchecked((int)0x800404c0); // -2147220288
        public const int UnManagedinvalidvaluettagoutsideconditiontag = unchecked((int)0x800404bf); // -2147220289
        public const int UnManagedinvalidorganizationid = unchecked((int)0x800404be); // -2147220290
        public const int UnManagedinvalidowninguser = unchecked((int)0x800404bd); // -2147220291
        public const int UnManagedinvalidowningbusinessunitorbusinessunitid = unchecked((int)0x800404bc); // -2147220292
        public const int UnManagedinvalidprivilegeedepth = unchecked((int)0x800404bb); // -2147220293
        public const int UnManagedinvalidlinkobjects = unchecked((int)0x800404ba); // -2147220294
        public const int UnManagedpartylistattributenotsupported = unchecked((int)0x800404b8); // -2147220296
        public const int UnManagedinvalidargumentsforcondition = unchecked((int)0x800404b7); // -2147220297
        public const int UnManagedunknownaggregateoperation = unchecked((int)0x800404b6); // -2147220298
        public const int UnManagedmissingparentattributeonentity = unchecked((int)0x800404b5); // -2147220299
        public const int UnManagedinvalidprocesschildofcondition = unchecked((int)0x800404b4); // -2147220300
        public const int UnManagedunexpectedrimarykey = unchecked((int)0x800404b3); // -2147220301
        public const int UnManagedmissinglinkentity = unchecked((int)0x800404b2); // -2147220302
        public const int UnManagedinvalidprocessliternalcondition = unchecked((int)0x800404b1); // -2147220303
        public const int UnManagedemptyprocessliteralcondition = unchecked((int)0x800404b0); // -2147220304
        public const int UnManagedunusablevariantdata = unchecked((int)0x800404af); // -2147220305
        public const int UnManagedfieldnotvalidatedbyplatform = unchecked((int)0x800404ae); // -2147220306
        public const int UnManagedmissingfilterattribute = unchecked((int)0x800404ad); // -2147220307
        public const int UnManagedinvalidequalityoperand = unchecked((int)0x800404ac); // -2147220308
        public const int UnManagedfilterindexoutofrange = unchecked((int)0x800404ab); // -2147220309
        public const int UnManagedentityisnotintersect = unchecked((int)0x800404aa); // -2147220310
        public const int UnManagedcihldofconditionforoffilefilters = unchecked((int)0x800404a9); // -2147220311
        public const int UnManagedinvalidowningbusinessunit = unchecked((int)0x800404a8); // -2147220312
        public const int UnManagedinvalidbusinessunitid = unchecked((int)0x800404a7); // -2147220313
        public const int UnManagedmorethanonesortattribute = unchecked((int)0x800404a6); // -2147220314
        public const int UnManagedunabletoaccessqueryplan = unchecked((int)0x800404a5); // -2147220315
        public const int UnManagedparentattributenotfound = unchecked((int)0x800404a4); // -2147220316
        public const int UnManagedinvalidtlsmananger = unchecked((int)0x800404a2); // -2147220318
        public const int UnManagedinvalidescapedxml = unchecked((int)0x800404a1); // -2147220319
        public const int UnManagedunabletoretrieveprivileges = unchecked((int)0x800404a0); // -2147220320
        public const int UnManagedproxycreationfailed = unchecked((int)0x8004049f); // -2147220321
        public const int UnManagedinvalidprincipal = unchecked((int)0x8004049e); // -2147220322
        public const int RestrictInheritedRole = unchecked((int)0x80044152); // -2147204782
        public const int UnManagedidsfetchbetweentext = unchecked((int)0x80044153); // -2147204781
        public const int UnManagedidscantdisable = unchecked((int)0x80044154); // -2147204780
        public const int CascadeInvalidLinkTypeTransition = unchecked((int)0x80044155); // -2147204779
        public const int InvalidOrgOwnedCascadeLinkType = unchecked((int)0x80044156); // -2147204778
        public const int CallerCannotChangeOwnDomainName = unchecked((int)0x80044161); // -2147204767
        public const int AsyncOperationInvalidStateChange = unchecked((int)0x80044162); // -2147204766
        public const int AsyncOperationInvalidStateChangeUnexpected = unchecked((int)0x80044163); // -2147204765
        public const int AsyncOperationMissingId = unchecked((int)0x80044164); // -2147204764
        public const int AsyncOperationInvalidStateChangeToComplete = unchecked((int)0x80044165); // -2147204763
        public const int AsyncOperationInvalidStateChangeToReady = unchecked((int)0x80044166); // -2147204762
        public const int AsyncOperationInvalidStateChangeToSuspended = unchecked((int)0x80044167); // -2147204761
        public const int AsyncOperationCannotUpdateNonrecurring = unchecked((int)0x80044168); // -2147204760
        public const int AsyncOperationCannotUpdateRecurring = unchecked((int)0x80044169); // -2147204759
        public const int AsyncOperationCannotDeleteUnlessCompleted = unchecked((int)0x8004416a); // -2147204758
        public const int SdkInvalidMessagePropertyName = unchecked((int)0x8004416b); // -2147204757
        public const int PluginAssemblyMustHavePublicKeyToken = unchecked((int)0x8004416c); // -2147204756
        public const int SdkMessageInvalidImageTypeRegistration = unchecked((int)0x8004416d); // -2147204755
        public const int SdkMessageDoesNotSupportPostImageRegistration = unchecked((int)0x8004416e); // -2147204754
        public const int CannotDeserializeRequest = unchecked((int)0x8004416f); // -2147204753
        public const int InvalidPluginRegistrationConfiguration = unchecked((int)0x80044170); // -2147204752
        public const int SandboxClientPluginTimeout = unchecked((int)0x80044171); // -2147204751
        public const int SandboxHostPluginTimeout = unchecked((int)0x80044172); // -2147204750
        public const int SandboxWorkerPluginTimeout = unchecked((int)0x80044173); // -2147204749
        public const int SandboxSdkListenerStartFailed = unchecked((int)0x80044174); // -2147204748
        public const int ServiceBusPostFailed = unchecked((int)0x80044175); // -2147204747
        public const int ServiceBusIssuerNotFound = unchecked((int)0x80044176); // -2147204746
        public const int ServiceBusIssuerCertificateError = unchecked((int)0x80044177); // -2147204745
        public const int ServiceBusExtendedTokenFailed = unchecked((int)0x80044178); // -2147204744
        public const int ServiceBusPostPostponed = unchecked((int)0x80044179); // -2147204743
        public const int ServiceBusPostDisabled = unchecked((int)0x8004417a); // -2147204742
        public const int SdkMessageNotSupportedOnServer = unchecked((int)0x80044180); // -2147204736
        public const int SdkMessageNotSupportedOnClient = unchecked((int)0x80044181); // -2147204735
        public const int SdkCorrelationTokenDepthTooHigh = unchecked((int)0x80044182); // -2147204734
        public const int OnlyStepInPredefinedStagesCanBeModified = unchecked((int)0x80044184); // -2147204732
        public const int OnlyStepInServerOnlyCanHaveSecureConfiguration = unchecked((int)0x80044185); // -2147204731
        public const int OnlyStepOutsideTransactionCanCreateCrmService = unchecked((int)0x80044186); // -2147204730
        public const int SdkCustomProcessingStepIsNotAllowed = unchecked((int)0x80044187); // -2147204729
        public const int SdkEntityOfflineQueuePlaybackIsNotAllowed = unchecked((int)0x80044188); // -2147204728
        public const int SdkMessageDoesNotSupportImageRegistration = unchecked((int)0x80044189); // -2147204727
        public const int RequestLengthTooLarge = unchecked((int)0x8004418a); // -2147204726
        public const int SandboxWorkerNotAvailable = unchecked((int)0x8004418d); // -2147204723
        public const int SandboxHostNotAvailable = unchecked((int)0x8004418e); // -2147204722
        public const int PluginAssemblyContentSizeExceeded = unchecked((int)0x8004418f); // -2147204721
        public const int UnableToLoadPluginType = unchecked((int)0x80044190); // -2147204720
        public const int UnableToLoadPluginAssembly = unchecked((int)0x80044191); // -2147204719
        public const int InvalidPluginAssemblyContent = unchecked((int)0x8004418b); // -2147204725
        public const int InvalidPluginTypeImplementation = unchecked((int)0x8004418c); // -2147204724
        public const int InvalidPluginAssemblyVersion = unchecked((int)0x8004417b); // -2147204741
        public const int PluginTypeMustBeUnique = unchecked((int)0x8004417c); // -2147204740
        public const int InvalidAssemblySourceType = unchecked((int)0x8004417d); // -2147204739
        public const int InvalidAssemblyProcessorArchitecture = unchecked((int)0x8004417e); // -2147204738
        public const int CyclicReferencesNotSupported = unchecked((int)0x8004417f); // -2147204737
        public const int InvalidEmailAddressFormat = unchecked((int)0x80044192); // -2147204718
        public const int ContractInvalidDiscount = unchecked((int)0x80044193); // -2147204717
        public const int InvalidLanguageCode = unchecked((int)0x80044195); // -2147204715
        public const int ConfigNullPrimaryKey = unchecked((int)0x80044196); // -2147204714
        public const int ConfigMissingDescription = unchecked((int)0x80044197); // -2147204713
        public const int AttributeDoesNotSupportLocalizedLabels = unchecked((int)0x80044198); // -2147204712
        public const int NoLanguageProvisioned = unchecked((int)0x80044199); // -2147204711
        public const int CannotImportNullStringsForBaseLanguage = unchecked((int)0x80044246); // -2147204538
        public const int CannotUpdateNonCustomizableString = unchecked((int)0x80044247); // -2147204537
        public const int InvalidOrganizationId = unchecked((int)0x80044248); // -2147204536
        public const int InvalidTranslationsFile = unchecked((int)0x80044249); // -2147204535
        public const int MetadataRecordNotDeletable = unchecked((int)0x80044250); // -2147204528
        public const int InvalidImportJobTemplateFile = unchecked((int)0x80044251); // -2147204527
        public const int InvalidImportJobId = unchecked((int)0x80044252); // -2147204526
        public const int MissingCrmAuthenticationToken = unchecked((int)0x80044300); // -2147204352
        public const int IntegratedAuthenticationIsNotAllowed = unchecked((int)0x80044301); // -2147204351
        public const int RequestIsNotAuthenticated = unchecked((int)0x80044302); // -2147204350
        public const int AsyncOperationTypeIsNotRecognized = unchecked((int)0x80044303); // -2147204349
        public const int FailedToDeserializeAsyncOperationData = unchecked((int)0x80044304); // -2147204348
        public const int UserSettingsOverMaxPagingLimit = unchecked((int)0x80044305); // -2147204347
        public const int AsyncNetworkError = unchecked((int)0x80044306); // -2147204346
        public const int AsyncCommunicationError = unchecked((int)0x80044307); // -2147204345
        public const int MissingCrmAuthenticationTokenOrganizationName = unchecked((int)0x80044308); // -2147204344
        public const int SdkNotEnoughPrivilegeToSetCallerOriginToken = unchecked((int)0x80044309); // -2147204343
        public const int OverRetrievalUpperLimitWithoutPagingCookie = unchecked((int)0x8004430a); // -2147204342
        public const int InvalidAllotmentsOverage = unchecked((int)0x8004430b); // -2147204341
        public const int TooManyConditionsInQuery = unchecked((int)0x8004430c); // -2147204340
        public const int TooManyLinkEntitiesInQuery = unchecked((int)0x8004430d); // -2147204339
        public const int TooManyConditionParametersInQuery = unchecked((int)0x8004430e); // -2147204338
        public const int InvalidOneToManyRelationshipForRelatedEntitiesQuery = unchecked((int)0x8004430f); // -2147204337
        public const int PicklistValueNotUnique = unchecked((int)0x80044310); // -2147204336
        public const int UnableToLogOnUserFromUserNameAndPassword = unchecked((int)0x80044311); // -2147204335
        public const int PicklistValueOutOfRange = unchecked((int)0x8004431a); // -2147204326
        public const int WrongNumberOfBooleanOptions = unchecked((int)0x8004431b); // -2147204325
        public const int BooleanOptionOutOfRange = unchecked((int)0x8004431c); // -2147204324
        public const int CannotAddNewBooleanValue = unchecked((int)0x8004431d); // -2147204323
        public const int CannotAddNewStateValue = unchecked((int)0x8004431e); // -2147204322
        public const int NoMoreCustomOptionValuesExist = unchecked((int)0x8004431f); // -2147204321
        public const int InsertOptionValueInvalidType = unchecked((int)0x80044320); // -2147204320
        public const int NewStatusRequiresAssociatedState = unchecked((int)0x80044321); // -2147204319
        public const int NewStatusHasInvalidState = unchecked((int)0x80044322); // -2147204318
        public const int CannotDeleteEnumOptionsFromAttributeType = unchecked((int)0x80044323); // -2147204317
        public const int OptionReorderArrayIncorrectLength = unchecked((int)0x80044324); // -2147204316
        public const int ValueMissingInOptionOrderArray = unchecked((int)0x80044325); // -2147204315
        public const int NavPaneOrderValueNotAllowed = unchecked((int)0x80044327); // -2147204313
        public const int EntityRelationshipRoleCustomLabelsMissing = unchecked((int)0x80044328); // -2147204312
        public const int NavPaneNotCustomizable = unchecked((int)0x80044329); // -2147204311
        public const int EntityRelationshipSchemaNameRequired = unchecked((int)0x8004432a); // -2147204310
        public const int EntityRelationshipSchemaNameNotUnique = unchecked((int)0x8004432b); // -2147204309
        public const int CustomReflexiveRelationshipNotAllowedForEntity = unchecked((int)0x8004432c); // -2147204308
        public const int EntityCannotBeChildInCustomRelationship = unchecked((int)0x8004432d); // -2147204307
        public const int ReferencedEntityHasLogicalPrimaryNameField = unchecked((int)0x8004432e); // -2147204306
        public const int IntegerValueOutOfRange = unchecked((int)0x8004432f); // -2147204305
        public const int DecimalValueOutOfRange = unchecked((int)0x80044330); // -2147204304
        public const int StringLengthTooLong = unchecked((int)0x80044331); // -2147204303
        public const int EntityCannotParticipateInEntityAssociation = unchecked((int)0x80044332); // -2147204302
        public const int DataMigrationManagerUnknownProblem = unchecked((int)0x80044333); // -2147204301
        public const int ImportOperationChildFailure = unchecked((int)0x80044334); // -2147204300
        public const int AttributeDeprecated = unchecked((int)0x80044335); // -2147204299
        public const int DataMigrationManagerMandatoryUpdatesNotInstalled = unchecked((int)0x80044336); // -2147204298
        public const int ReferencedEntityMustHaveLookupView = unchecked((int)0x80044337); // -2147204297
        public const int ReferencingEntityMustHaveAssociationView = unchecked((int)0x80044338); // -2147204296
        public const int CouldNotObtainLockOnResource = unchecked((int)0x80044339); // -2147204295
        public const int SourceAttributeHeaderTooBig = unchecked((int)0x80044340); // -2147204288
        public const int CannotDeleteDefaultStatusOption = unchecked((int)0x80044341); // -2147204287
        public const int CannotFindDomainAccount = unchecked((int)0x80044342); // -2147204286
        public const int CannotUpdateAppDefaultValueForStateAttribute = unchecked((int)0x80044343); // -2147204285
        public const int CannotUpdateAppDefaultValueForStatusAttribute = unchecked((int)0x80044344); // -2147204284
        public const int InvalidOptionSetSchemaName = unchecked((int)0x80044345); // -2147204283
        public const int ReferencingEntityCannotBeSolutionAware = unchecked((int)0x80044350); // -2147204272
        public const int ErrorInFieldWidthIncrease = unchecked((int)0x80044351); // -2147204271
        public const int AsyncOperationCannotCancel = unchecked((int)0x80044f00); // -2147201280
        public const int AsyncOperationCannotPause = unchecked((int)0x80044f01); // -2147201279
        public const int WorkflowCompileFailure = unchecked((int)0x80045001); // -2147201023
        public const int UpdatePublishedWorkflowDefinition = unchecked((int)0x80045002); // -2147201022
        public const int UpdateWorkflowActivation = unchecked((int)0x80045003); // -2147201021
        public const int DeleteWorkflowActivation = unchecked((int)0x80045004); // -2147201020
        public const int DeleteWorkflowActivationWorkflowDependency = unchecked((int)0x80045005); // -2147201019
        public const int DeletePublishedWorkflowDefinitionWorkflowDependency = unchecked((int)0x80045006); // -2147201018
        public const int UpdateWorkflowActivationWorkflowDependency = unchecked((int)0x80045007); // -2147201017
        public const int UpdatePublishedWorkflowDefinitionWorkflowDependency = unchecked((int)0x80045008); // -2147201016
        public const int CreateWorkflowActivationWorkflowDependency = unchecked((int)0x80045009); // -2147201015
        public const int CreatePublishedWorkflowDefinitionWorkflowDependency = unchecked((int)0x8004500a); // -2147201014
        public const int WorkflowPublishedByNonOwner = unchecked((int)0x8004500b); // -2147201013
        public const int PublishedWorkflowOwnershipChange = unchecked((int)0x8004500c); // -2147201012
        public const int OnlyWorkflowDefinitionOrTemplateCanBePublished = unchecked((int)0x8004500d); // -2147201011
        public const int OnlyWorkflowDefinitionOrTemplateCanBeUnpublished = unchecked((int)0x8004500e); // -2147201010
        public const int DeleteWorkflowActiveDefinition = unchecked((int)0x8004500f); // -2147201009
        public const int WorkflowConditionIncorrectUnaryOperatorFormation = unchecked((int)0x80045010); // -2147201008
        public const int WorkflowConditionIncorrectBinaryOperatorFormation = unchecked((int)0x80045011); // -2147201007
        public const int WorkflowConditionOperatorNotSupported = unchecked((int)0x80045012); // -2147201006
        public const int WorkflowConditionTypeNotSupport = unchecked((int)0x80045013); // -2147201005
        public const int WorkflowValidationFailure = unchecked((int)0x80045014); // -2147201004
        public const int PublishedWorkflowLimitForSkuReached = unchecked((int)0x80045015); // -2147201003
        public const int NoPrivilegeToPublishWorkflow = unchecked((int)0x80045016); // -2147201002
        public const int WorkflowSystemPaused = unchecked((int)0x80045017); // -2147201001
        public const int WorkflowPublishNoActivationParameters = unchecked((int)0x80045018); // -2147201000
        public const int CreateWorkflowDependencyForPublishedTemplate = unchecked((int)0x80045019); // -2147200999
        public const int DeleteActiveWorkflowTemplateDependency = unchecked((int)0x8004501a); // -2147200998
        public const int UpdatePublishedWorkflowTemplate = unchecked((int)0x8004501b); // -2147200997
        public const int DeleteWorkflowActiveTemplate = unchecked((int)0x8004501c); // -2147200996
        public const int CustomActivityInvalid = unchecked((int)0x8004501d); // -2147200995
        public const int PrimaryEntityInvalid = unchecked((int)0x8004501e); // -2147200994
        public const int CannotDeserializeWorkflowInstance = unchecked((int)0x8004501f); // -2147200993
        public const int CannotDeserializeXamlWorkflow = unchecked((int)0x80045020); // -2147200992
        public const int CannotDeleteCustomEntityUsedInWorkflow = unchecked((int)0x8004502c); // -2147200980
        public const int BulkMailOperationFailed = unchecked((int)0x8004502d); // -2147200979
        public const int WorkflowExpressionOperatorNotSupported = unchecked((int)0x8004502e); // -2147200978
        public const int ChildWorkflowNotFound = unchecked((int)0x8004502f); // -2147200977
        public const int CannotDeleteAttributeUsedInWorkflow = unchecked((int)0x80045030); // -2147200976
        public const int CannotLocateRecordForWorkflowActivity = unchecked((int)0x80045031); // -2147200975
        public const int PublishWorkflowWhileActingOnBehalfOfAnotherUserError = unchecked((int)0x80045032); // -2147200974
        public const int CannotDisableInternetMarketingUser = unchecked((int)0x80045033); // -2147200973
        public const int CannotSetWindowsLiveIdForInternetMarketingUser = unchecked((int)0x80045034); // -2147200972
        public const int CannotChangeAccessModeForInternetMarketingUser = unchecked((int)0x80045035); // -2147200971
        public const int CannotChangeInvitationStatusForInternetMarketingUser = unchecked((int)0x80045036); // -2147200970
        public const int UiDataGenerationFailed = unchecked((int)0x80045037); // -2147200969
        public const int WorkflowReferencesInvalidActivity = unchecked((int)0x80045038); // -2147200968
        public const int PublishWorkflowWhileImpersonatingError = unchecked((int)0x80045039); // -2147200967
        public const int ExchangeAutodiscoverError = unchecked((int)0x8004503a); // -2147200966
        public const int NonCrmUiWorkflowsNotSupported = unchecked((int)0x80045040); // -2147200960
        public const int NotEnoughPrivilegesForXamlWorkflows = unchecked((int)0x80045041); // -2147200959
        public const int WorkflowAutomaticallyDeactivated = unchecked((int)0x80045042); // -2147200958
        public const int StepAutomaticallyDisabled = unchecked((int)0x80045043); // -2147200957
        public const int NonCrmUiInteractiveWorkflowNotSupported = unchecked((int)0x80045044); // -2147200956
        public const int WorkflowActivityNotSupported = unchecked((int)0x80045045); // -2147200955
        public const int ExecuteNotOnDemandWorkflow = unchecked((int)0x80045046); // -2147200954
        public const int ExecuteUnpublishedWorkflow = unchecked((int)0x80045047); // -2147200953
        public const int ChildWorkflowParameterMismatch = unchecked((int)0x80045048); // -2147200952
        public const int InvalidProcessStateData = unchecked((int)0x80045049); // -2147200951
        public const int OutOfScopeSlug = unchecked((int)0x80045050); // -2147200944
        public const int CrmSqlGovernorDatabaseRequestDenied = unchecked((int)0x8004a001); // -2147180543
        public const int InvalidAuthTicket = unchecked((int)0x8004a100); // -2147180288
        public const int ExpiredAuthTicket = unchecked((int)0x8004a101); // -2147180287
        public const int BadAuthTicket = unchecked((int)0x8004a102); // -2147180286
        public const int InsufficientAuthTicket = unchecked((int)0x8004a103); // -2147180285
        public const int OrganizationDisabled = unchecked((int)0x8004a104); // -2147180284
        public const int TamperedAuthTicket = unchecked((int)0x8004a105); // -2147180283
        public const int ExpiredKey = unchecked((int)0x8004a106); // -2147180282
        public const int ScaleGroupDisabled = unchecked((int)0x8004a107); // -2147180281
        public const int SupportLogOnExpired = unchecked((int)0x8004a108); // -2147180280
        public const int InvalidPartnerSolutionCustomizationProvider = unchecked((int)0x8004a109); // -2147180279
        public const int MultiplePartnerSecurityRoleWithSameInformation = unchecked((int)0x8004a10a); // -2147180278
        public const int MultiplePartnerUserWithSameInformation = unchecked((int)0x8004a10b); // -2147180277
        public const int MultipleRootBusinessUnit = unchecked((int)0x8004a10c); // -2147180276
        public const int CannotDeletePartnerWithPartnerSolutions = unchecked((int)0x8004a10d); // -2147180275
        public const int CannotDeletePartnerSolutionWithOrganizations = unchecked((int)0x8004a10e); // -2147180274
        public const int CannotProvisionPartnerSolution = unchecked((int)0x8004a10f); // -2147180273
        public const int CannotActOnBehalfOfAnotherUser = unchecked((int)0x8004a110); // -2147180272
        public const int SystemUserDisabled = unchecked((int)0x8004a112); // -2147180270
        public const int PluginDoesNotImplementCorrectInterface = unchecked((int)0x8004a200); // -2147180032
        public const int CannotCreatePluginInstance = unchecked((int)0x8004a201); // -2147180031
        public const int CrmLiveGenericError = unchecked((int)0x8004b000); // -2147176448
        public const int CrmLiveOrganizationProvisioningFailed = unchecked((int)0x8004b001); // -2147176447
        public const int CrmLiveMissingActiveDirectoryGroup = unchecked((int)0x8004b002); // -2147176446
        public const int CrmLiveInternalProvisioningError = unchecked((int)0x8004b003); // -2147176445
        public const int CrmLiveQueueItemDoesNotExist = unchecked((int)0x8004b004); // -2147176444
        public const int CrmLiveInvalidSetupParameter = unchecked((int)0x8004b005); // -2147176443
        public const int CrmLiveMultipleWitnessServersInScaleGroup = unchecked((int)0x8004b006); // -2147176442
        public const int CrmLiveMissingServerRolesInScaleGroup = unchecked((int)0x8004b007); // -2147176441
        public const int CrmLiveServerCannotHaveWitnessAndDataServerRoles = unchecked((int)0x8004b008); // -2147176440
        public const int IsNotLiveToSendInvitation = unchecked((int)0x8004b009); // -2147176439
        public const int MissingOrganizationFriendlyName = unchecked((int)0x8004b00a); // -2147176438
        public const int MissingOrganizationUniqueName = unchecked((int)0x8004b00b); // -2147176437
        public const int OfferingCategoryAndTokenNull = unchecked((int)0x8004b00c); // -2147176436
        public const int OfferingIdNotSupported = unchecked((int)0x8004b00d); // -2147176435
        public const int OrganizationTakenByYou = unchecked((int)0x8004b00e); // -2147176434
        public const int OrganizationTakenBySomeoneElse = unchecked((int)0x8004b00f); // -2147176433
        public const int InvalidTemplate = unchecked((int)0x8004b010); // -2147176432
        public const int InvalidUserQuota = unchecked((int)0x8004b011); // -2147176431
        public const int InvalidRole = unchecked((int)0x8004b012); // -2147176430
        public const int ErrorGeneratingInvitation = unchecked((int)0x8004b013); // -2147176429
        public const int CrmLiveOrganizationUpgradeFailed = unchecked((int)0x8004b014); // -2147176428
        public const int UnableToSendEmail = unchecked((int)0x8004b015); // -2147176427
        public const int InvalidEmail = unchecked((int)0x8004b016); // -2147176426
        public const int VersionMismatch = unchecked((int)0x8004b020); // -2147176416
        public const int MissingParameterToMethod = unchecked((int)0x8004b021); // -2147176415
        public const int InvalidValueForCountryCode = unchecked((int)0x8004b022); // -2147176414
        public const int InvalidValueForCurrency = unchecked((int)0x8004b023); // -2147176413
        public const int InvalidValueForLocale = unchecked((int)0x8004b024); // -2147176412
        public const int CrmLiveSupportOrganizationExistsInScaleGroup = unchecked((int)0x8004b025); // -2147176411
        public const int CrmLiveMonitoringOrganizationExistsInScaleGroup = unchecked((int)0x8004b026); // -2147176410
        public const int InvalidUserLicenseCount = unchecked((int)0x8004b027); // -2147176409
        public const int MissingColumn = unchecked((int)0x8004b028); // -2147176408
        public const int InvalidResourceType = unchecked((int)0x8004b029); // -2147176407
        public const int InvalidMinimumResourceLimit = unchecked((int)0x8004b02a); // -2147176406
        public const int InvalidMaximumResourceLimit = unchecked((int)0x8004b02b); // -2147176405
        public const int ConflictingProvisionTypes = unchecked((int)0x8004b02c); // -2147176404
        public const int InvalidAmountProvided = unchecked((int)0x8004b02d); // -2147176403
        public const int CrmLiveOrganizationDeleteFailed = unchecked((int)0x8004b02e); // -2147176402
        public const int OnlyDisabledOrganizationCanBeDeleted = unchecked((int)0x8004b02f); // -2147176401
        public const int CrmLiveOrganizationDetailsNotFound = unchecked((int)0x8004b030); // -2147176400
        public const int CrmLiveOrganizationFriendlyNameTooShort = unchecked((int)0x8004b031); // -2147176399
        public const int CrmLiveOrganizationFriendlyNameTooLong = unchecked((int)0x8004b032); // -2147176398
        public const int CrmLiveOrganizationUniqueNameTooShort = unchecked((int)0x8004b033); // -2147176397
        public const int CrmLiveOrganizationUniqueNameTooLong = unchecked((int)0x8004b034); // -2147176396
        public const int CrmLiveOrganizationUniqueNameInvalid = unchecked((int)0x8004b035); // -2147176395
        public const int CrmLiveOrganizationUniqueNameReserved = unchecked((int)0x8004b036); // -2147176394
        public const int ValueParsingError = unchecked((int)0x8004b037); // -2147176393
        public const int InvalidGranularityValue = unchecked((int)0x8004b038); // -2147176392
        public const int CrmLiveInvalidQueueItemSchedule = unchecked((int)0x8004b039); // -2147176391
        public const int CrmLiveQueueItemTimeInPast = unchecked((int)0x8004b040); // -2147176384
        public const int CrmLiveUnknownSku = unchecked((int)0x8004b041); // -2147176383
        public const int ExceedCustomEntityQuota = unchecked((int)0x8004b042); // -2147176382
        public const int ImportWillExceedCustomEntityQuota = unchecked((int)0x8004b043); // -2147176381
        public const int OrganizationMigrationUnderway = unchecked((int)0x8004b044); // -2147176380
        public const int CrmLiveInvoicingAccountIdMissing = unchecked((int)0x8004b045); // -2147176379
        public const int CrmLiveDuplicateWindowsLiveId = unchecked((int)0x8004b046); // -2147176378
        public const int CrmLiveDnsDomainNotFound = unchecked((int)0x8004b047); // -2147176377
        public const int CrmLiveDnsDomainAlreadyExists = unchecked((int)0x8004b048); // -2147176376
        public const int InvalidInteractiveUserQuota = unchecked((int)0x8004b049); // -2147176375
        public const int InvalidNonInteractiveUserQuota = unchecked((int)0x8004b050); // -2147176368
        public const int CrmLiveCannotFindExternalMessageProvider = unchecked((int)0x8004b051); // -2147176367
        public const int CrmLiveInvalidExternalMessageData = unchecked((int)0x8004b052); // -2147176366
        public const int CrmLiveOrganizationEnableFailed = unchecked((int)0x8004b053); // -2147176365
        public const int CrmLiveOrganizationDisableFailed = unchecked((int)0x8004b054); // -2147176364
        public const int CrmLiveAddOnUnexpectedError = unchecked((int)0x8004b055); // -2147176363
        public const int CrmLiveAddOnAddLicenseLimitReached = unchecked((int)0x8004b056); // -2147176362
        public const int CrmLiveAddOnAddStorageLimitReached = unchecked((int)0x8004b057); // -2147176361
        public const int CrmLiveAddOnRemoveStorageLimitReached = unchecked((int)0x8004b058); // -2147176360
        public const int CrmLiveAddOnOrgInNoUpdateMode = unchecked((int)0x8004b059); // -2147176359
        public const int CrmLiveUnknownCategory = unchecked((int)0x8004b05a); // -2147176358
        public const int CrmLiveInvalidInvoicingAccountNumber = unchecked((int)0x8004b05b); // -2147176357
        public const int CrmLiveAddOnDataChanged = unchecked((int)0x8004b05c); // -2147176356
        public const int CrmLiveInvalidEmail = unchecked((int)0x8004b05d); // -2147176355
        public const int CrmLiveInvalidPhone = unchecked((int)0x8004b05e); // -2147176354
        public const int CrmLiveInvalidZipCode = unchecked((int)0x8004b05f); // -2147176353
        public const int InvalidAmountFreeResourceLimit = unchecked((int)0x8004b060); // -2147176352
        public const int InvalidToken = unchecked((int)0x8004b061); // -2147176351
        public const int CrmLiveRegisterCustomCodeDisabled = unchecked((int)0x8004b062); // -2147176350
        public const int CrmLiveExecuteCustomCodeDisabled = unchecked((int)0x8004b063); // -2147176349
        public const int CrmLiveInvalidTaxId = unchecked((int)0x8004b064); // -2147176348
        public const int LivePlatformGeneralEmailError = unchecked((int)0x8005b520); // -2147109600
        public const int LivePlatformEmailInvalidTo = unchecked((int)0x8004b521); // -2147175135
        public const int LivePlatformEmailInvalidFrom = unchecked((int)0x8004b522); // -2147175134
        public const int LivePlatformEmailInvalidSubject = unchecked((int)0x8004b523); // -2147175133
        public const int LivePlatformEmailInvalidBody = unchecked((int)0x8004b524); // -2147175132
        public const int BillingPartnerCertificate = unchecked((int)0x8004b530); // -2147175120
        public const int BillingNoSettingError = unchecked((int)0x8004b531); // -2147175119
        public const int BillingTestConnectionError = unchecked((int)0x8004b532); // -2147175118
        public const int BillingTestConnectionException = unchecked((int)0x8004b533); // -2147175117
        public const int BillingUserPuidNullError = unchecked((int)0x8004b534); // -2147175116
        public const int BillingUnmappedErrorCode = unchecked((int)0x8004b535); // -2147175115
        public const int BillingUnknownErrorCode = unchecked((int)0x8004b536); // -2147175114
        public const int BillingUnknownException = unchecked((int)0x8004b537); // -2147175113
        public const int BillingRetrieveKeyError = unchecked((int)0x8004b538); // -2147175112
        public const int BdkEAddressValidationFailure = unchecked((int)0x8004b540); // -2147175104
        public const int BdkEAgreementAlreadySigned = unchecked((int)0x8004b541); // -2147175103
        public const int BdkEAuthorizationFailed = unchecked((int)0x8004b542); // -2147175102
        public const int BdkEAvsFailed = unchecked((int)0x8004b543); // -2147175101
        public const int BdkEBadCitynameLength = unchecked((int)0x8004b544); // -2147175100
        public const int BdkEBadStatecodeLength = unchecked((int)0x8004b545); // -2147175099
        public const int BdkEBadZipcodeLength = unchecked((int)0x8004b546); // -2147175098
        public const int BdkEBadxml = unchecked((int)0x8004b547); // -2147175097
        public const int BdkEBannedPaymentInstrument = unchecked((int)0x8004b548); // -2147175096
        public const int BdkEBannedperson = unchecked((int)0x8004b549); // -2147175095
        public const int BdkECannotExceedMaxOwnership = unchecked((int)0x8004b54a); // -2147175094
        public const int BdkECountryCurrencyPiMismatch = unchecked((int)0x8004b54b); // -2147175093
        public const int BdkECreditCardExpired = unchecked((int)0x8004b54c); // -2147175092
        public const int BdkEDateExpired = unchecked((int)0x8004b54d); // -2147175091
        public const int BdkEErrorCountrycodeMismatch = unchecked((int)0x8004b54e); // -2147175090
        public const int BdkEErrorCountrycodeRequired = unchecked((int)0x8004b54f); // -2147175089
        public const int BdkEExtraReferralData = unchecked((int)0x8004b550); // -2147175088
        public const int BdkEGuidExists = unchecked((int)0x8004b551); // -2147175087
        public const int BdkEInvalidAddressId = unchecked((int)0x8004b552); // -2147175086
        public const int BdkEInvalidBillableAccountId = unchecked((int)0x8004b553); // -2147175085
        public const int BdkEInvalidBufSize = unchecked((int)0x8004b554); // -2147175084
        public const int BdkEInvalidCategoryName = unchecked((int)0x8004b555); // -2147175083
        public const int BdkEInvalidCountryCode = unchecked((int)0x8004b556); // -2147175082
        public const int BdkEInvalidCurrency = unchecked((int)0x8004b557); // -2147175081
        public const int BdkEInvalidCustomerType = unchecked((int)0x8004b558); // -2147175080
        public const int BdkEInvalidDate = unchecked((int)0x8004b559); // -2147175079
        public const int BdkEInvalidEmailAddress = unchecked((int)0x8004b55a); // -2147175078
        public const int BdkEInvalidFilter = unchecked((int)0x8004b55b); // -2147175077
        public const int BdkEInvalidGuid = unchecked((int)0x8004b55c); // -2147175076
        public const int BdkEInvalidInputToTaxwareOrVerazip = unchecked((int)0x8004b55d); // -2147175075
        public const int BdkEInvalidLocale = unchecked((int)0x8004b55e); // -2147175074
        public const int BdkEInvalidObjectId = unchecked((int)0x8004b55f); // -2147175073
        public const int BdkEInvalidOfferingGuid = unchecked((int)0x8004b560); // -2147175072
        public const int BdkEInvalidPaymentInstrumentStatus = unchecked((int)0x8004b561); // -2147175071
        public const int BdkEInvalidPaymentMethodId = unchecked((int)0x8004b562); // -2147175070
        public const int BdkEInvalidPhoneType = unchecked((int)0x8004b563); // -2147175069
        public const int BdkEInvalidPolicyId = unchecked((int)0x8004b564); // -2147175068
        public const int BdkEInvalidReferraldataXml = unchecked((int)0x8004b565); // -2147175067
        public const int BdkEInvalidStateForCountry = unchecked((int)0x8004b566); // -2147175066
        public const int BdkEInvalidSubscriptionId = unchecked((int)0x8004b567); // -2147175065
        public const int BdkEInvalidTaxExemptType = unchecked((int)0x8004b568); // -2147175064
        public const int BdkEMegConflict = unchecked((int)0x8004b569); // -2147175063
        public const int BdkEMultipleCitiesFound = unchecked((int)0x8004b56a); // -2147175062
        public const int BdkEMultipleCountiesFound = unchecked((int)0x8004b56b); // -2147175061
        public const int BdkENonActiveAccount = unchecked((int)0x8004b56c); // -2147175060
        public const int BdkENopermission = unchecked((int)0x8004b56d); // -2147175059
        public const int BdkEObjectRoleLimitExceeded = unchecked((int)0x8004b56e); // -2147175058
        public const int BdkEOfferingAccountCurrencyMismatch = unchecked((int)0x8004b56f); // -2147175057
        public const int BdkEOfferingCountryAccountMismatch = unchecked((int)0x8004b570); // -2147175056
        public const int BdkEOfferingNotPurchaseable = unchecked((int)0x8004b571); // -2147175055
        public const int BdkEOfferingPaymentInstrumentMismatch = unchecked((int)0x8004b572); // -2147175054
        public const int BdkEOfferingRequiresPi = unchecked((int)0x8004b573); // -2147175053
        public const int BdkEPartnernotinbilling = unchecked((int)0x8004b574); // -2147175052
        public const int BdkEPaymentProviderConnectionFailed = unchecked((int)0x8004b575); // -2147175051
        public const int BdkEPrimaryPhoneRequired = unchecked((int)0x8004b576); // -2147175050
        public const int BdkEPolicyDealCountryMismatch = unchecked((int)0x8004b577); // -2147175049
        public const int BdkEPuidRoleLimitExceeded = unchecked((int)0x8004b578); // -2147175048
        public const int BdkERatingFailure = unchecked((int)0x8004b579); // -2147175047
        public const int BdkERequiredFieldMissing = unchecked((int)0x8004b57a); // -2147175046
        public const int BdkEStateCityInvalid = unchecked((int)0x8004b57b); // -2147175045
        public const int BdkEStateInvalid = unchecked((int)0x8004b57c); // -2147175044
        public const int BdkEStateZipCityInvalid = unchecked((int)0x8004b57d); // -2147175043
        public const int BdkEStateZipCityInvalid2 = unchecked((int)0x8004b57e); // -2147175042
        public const int BdkEStateZipCityInvalid3 = unchecked((int)0x8004b57f); // -2147175041
        public const int BdkEStateZipCityInvalid4 = unchecked((int)0x8004b580); // -2147175040
        public const int BdkEStateZipCoversMultipleCities = unchecked((int)0x8004b581); // -2147175039
        public const int BdkEStateZipInvalid = unchecked((int)0x8004b582); // -2147175038
        public const int BdkETaxidExpdate = unchecked((int)0x8004b583); // -2147175037
        public const int BdkETokenBlacklisted = unchecked((int)0x8004b584); // -2147175036
        public const int BdkETokenExpired = unchecked((int)0x8004b585); // -2147175035
        public const int BdkETokenNotValidForOffering = unchecked((int)0x8004b586); // -2147175034
        public const int BdkETokenRangeBlacklisted = unchecked((int)0x8004b587); // -2147175033
        public const int BdkETransBalanceToPiInvalid = unchecked((int)0x8004b588); // -2147175032
        public const int BdkEUnknownServerFailure = unchecked((int)0x8004b589); // -2147175031
        public const int BdkEUnsupportedCharExist = unchecked((int)0x8004b58a); // -2147175030
        public const int BdkEVatidDoesnothaveexpdate = unchecked((int)0x8004b58b); // -2147175029
        public const int BdkEZipCityMissing = unchecked((int)0x8004b58c); // -2147175028
        public const int BdkEZipInvalid = unchecked((int)0x8004b58d); // -2147175027
        public const int BdkEZipInvalidForEnteredState = unchecked((int)0x8004b58e); // -2147175026
        public const int BdkEUsageCountForTokenExceeded = unchecked((int)0x8004b58f); // -2147175025
        public const int MissingParameterToStoredProcedure = unchecked((int)0x8004c000); // -2147172352
        public const int SqlErrorInStoredProcedure = unchecked((int)0x8004c001); // -2147172351
        public const int StoredProcedureContext = unchecked((int)0x8004c002); // -2147172350
        public const int InvitingOrganizationNotFound = unchecked((int)0x8004d200); // -2147167744
        public const int InvitingUserNotInOrganization = unchecked((int)0x8004d201); // -2147167743
        public const int InvitedUserAlreadyExists = unchecked((int)0x8004d202); // -2147167742
        public const int InvitedUserIsOrganization = unchecked((int)0x8004d203); // -2147167741
        public const int InvitationNotFound = unchecked((int)0x8004d204); // -2147167740
        public const int InvitedUserAlreadyAdded = unchecked((int)0x8004d205); // -2147167739
        public const int InvitationWrongUserOrgRelation = unchecked((int)0x8004d206); // -2147167738
        public const int InvitationIsExpired = unchecked((int)0x8004d207); // -2147167737
        public const int InvitationIsAccepted = unchecked((int)0x8004d208); // -2147167736
        public const int InvitationIsRejected = unchecked((int)0x8004d209); // -2147167735
        public const int InvitationIsRevoked = unchecked((int)0x8004d20a); // -2147167734
        public const int InvitedUserMultipleTimes = unchecked((int)0x8004d20b); // -2147167733
        public const int InvitationStatusError = unchecked((int)0x8004d20c); // -2147167732
        public const int InvalidInvitationToken = unchecked((int)0x8004d20d); // -2147167731
        public const int InvalidInvitationLiveId = unchecked((int)0x8004d20e); // -2147167730
        public const int InvitationSendToSelf = unchecked((int)0x8004d20f); // -2147167729
        public const int InvitationCannotBeReset = unchecked((int)0x8004d210); // -2147167728
        public const int UserDataNotFound = unchecked((int)0x8004d211); // -2147167727
        public const int CannotInviteDisabledUser = unchecked((int)0x8004d212); // -2147167726
        public const int InvitationBillingAdminUnknown = unchecked((int)0x8004d213); // -2147167725
        public const int CannotResetSysAdminInvite = unchecked((int)0x8004d214); // -2147167724
        public const int CannotSendInviteToDuplicateWindowsLiveId = unchecked((int)0x8004d215); // -2147167723
        public const int UserInviteDisabled = unchecked((int)0x8004d216); // -2147167722
        public const int InvitationOrganizationNotEnabled = unchecked((int)0x8004d217); // -2147167721
        public const int ClientAuthSignedOut = unchecked((int)0x8004d221); // -2147167711
        public const int ClientAuthSyncIssue = unchecked((int)0x8004d223); // -2147167709
        public const int ClientAuthCanceled = unchecked((int)0x8004d224); // -2147167708
        public const int ClientAuthNoConnectivityOffline = unchecked((int)0x8004d225); // -2147167707
        public const int ClientAuthNoConnectivity = unchecked((int)0x8004d226); // -2147167706
        public const int ClientAuthOfflineInvalidCallerId = unchecked((int)0x8004d227); // -2147167705
        public const int ConfigDbObjectDoesNotExist = unchecked((int)0x8004d230); // -2147167696
        public const int ConfigDbDuplicateRecord = unchecked((int)0x8004d231); // -2147167695
        public const int ConfigDbCannotDeleteObjectDueState = unchecked((int)0x8004d232); // -2147167694
        public const int ConfigDbCascadeDeleteNotAllowDelete = unchecked((int)0x8004d233); // -2147167693
        public const int MoveBothWebStoreToPrimary = unchecked((int)0x8004d234); // -2147167692
        public const int MoveBothWebStoreToSecondary = unchecked((int)0x8004d235); // -2147167691
        public const int MoveOrganizationFailedNotDisabled = unchecked((int)0x8004d236); // -2147167690
        public const int ConfigDbCannotUpdateObjectDueState = unchecked((int)0x8004d237); // -2147167689
        public const int LiveAdminUnknownObject = unchecked((int)0x8004d238); // -2147167688
        public const int LiveAdminUnknownCommand = unchecked((int)0x8004d239); // -2147167687
        public const int OperationOrganizationNotFullyDisabled = unchecked((int)0x8004d23a); // -2147167686
        public const int ConfigDbCannotDeleteDefaultOrganization = unchecked((int)0x8004d23b); // -2147167685
        public const int LicenseNotEnoughToActivate = unchecked((int)0x80042f14); // -2147209452
        public const int UserNotAssignedRoles = unchecked((int)0x80042f09); // -2147209463
        public const int TeamNotAssignedRoles = unchecked((int)0x80042f0a); // -2147209462
        public const int InvalidLicenseKey = unchecked((int)0x8004d240); // -2147167680
        public const int NoLicenseInConfigDb = unchecked((int)0x8004d241); // -2147167679
        public const int InvalidLicensePid = unchecked((int)0x8004d242); // -2147167678
        public const int InvalidLicensePidGenCannotLoad = unchecked((int)0x8004d243); // -2147167677
        public const int InvalidLicensePidGenOtherError = unchecked((int)0x8004d244); // -2147167676
        public const int InvalidLicenseCannotReadMpcFile = unchecked((int)0x8004d245); // -2147167675
        public const int InvalidLicenseMpcCode = unchecked((int)0x8004d246); // -2147167674
        public const int LicenseUpgradePathNotAllowed = unchecked((int)0x8004d247); // -2147167673
        public const int OrgsInaccessible = unchecked((int)0x8004d24a); // -2147167670
        public const int LicenseConfigFileInvalid = unchecked((int)0x8004d250); // -2147167664
        public const int LicenseTrialExpired = unchecked((int)0x8004415c); // -2147204772
        public const int LicenseRegistrationExpired = unchecked((int)0x8004415d); // -2147204771
        public const int LicenseTampered = unchecked((int)0x8004415f); // -2147204769
        public const int NonInteractiveUserCannotAccessUi = unchecked((int)0x80044160); // -2147204768
        public const int InvalidOrganizationUniqueName = unchecked((int)0x8004d251); // -2147167663
        public const int InvalidOrganizationFriendlyName = unchecked((int)0x8004d252); // -2147167662
        public const int DeploymentServiceNotAllowSetToThisState = unchecked((int)0x8004d260); // -2147167648
        public const int DeploymentServiceNotAllowOperation = unchecked((int)0x8004d261); // -2147167647
        public const int DeploymentServiceCannotChangeStateForDeploymentService = unchecked((int)0x8004d262); // -2147167646
        public const int DeploymentServiceRequestValidationFailure = unchecked((int)0x8004d263); // -2147167645
        public const int DeploymentServiceOperationIdentifierNotFound = unchecked((int)0x8004d264); // -2147167644
        public const int DeploymentServiceCannotDeleteOperationInProgress = unchecked((int)0x8004d265); // -2147167643
        public const int ConfigureClaimsBeforeIfd = unchecked((int)0x8004d266); // -2147167642
        public const int EndUserNotificationTypeNotValidForEmail = unchecked((int)0x8004d291); // -2147167599
        public const int InvalidRecurrenceRuleForBulkDeleteAndDuplicateDetection = unchecked((int)0x8004d2a0); // -2147167584
        public const int InvalidRecurrenceInterval = unchecked((int)0x8004d2a1); // -2147167583
        public const int QueriesForDifferentEntities = unchecked((int)0x8004d2b0); // -2147167568
        public const int AggregateInnerQuery = unchecked((int)0x8004d2b1); // -2147167567
        public const int InvalidDataDescription = unchecked((int)0x8004e000); // -2147164160
        public const int NonPrimaryEntityDataDescriptionFound = unchecked((int)0x8004e001); // -2147164159
        public const int InvalidPresentationDescription = unchecked((int)0x8004e002); // -2147164158
        public const int SeriesMeasureCollectionMismatch = unchecked((int)0x8004e003); // -2147164157
        public const int YValuesPerPointMeasureMismatch = unchecked((int)0x8004e004); // -2147164156
        public const int ChartAreaCategoryMismatch = unchecked((int)0x8004e005); // -2147164155
        public const int MultipleSubcategoriesFound = unchecked((int)0x8004e006); // -2147164154
        public const int MultipleMeasuresFound = unchecked((int)0x8004e007); // -2147164153
        public const int MultipleChartAreasFound = unchecked((int)0x8004e008); // -2147164152
        public const int InvalidCategory = unchecked((int)0x8004e009); // -2147164151
        public const int InvalidMeasureCollection = unchecked((int)0x8004e00a); // -2147164150
        public const int DuplicateAliasFound = unchecked((int)0x8004e00b); // -2147164149
        public const int EntityNotEnabledForCharts = unchecked((int)0x8004e00c); // -2147164148
        public const int InvalidPageResponse = unchecked((int)0x8004e00d); // -2147164147
        public const int VisualizationRenderingError = unchecked((int)0x8004e00e); // -2147164146
        public const int InvalidGroupByAlias = unchecked((int)0x8004e00f); // -2147164145
        public const int MeasureDataTypeInvalid = unchecked((int)0x8004e010); // -2147164144
        public const int NoDataForVisualization = unchecked((int)0x8004e011); // -2147164143
        public const int VisualizationModuleNotFound = unchecked((int)0x8004e012); // -2147164142
        public const int ImportVisualizationDeletedError = unchecked((int)0x8004e013); // -2147164141
        public const int ImportVisualizationExistingError = unchecked((int)0x8004e014); // -2147164140
        public const int VisualizationOtcNotFoundError = unchecked((int)0x8004e015); // -2147164139
        public const int InvalidDundasPresentationDescription = unchecked((int)0x8004e016); // -2147164138
        public const int InvalidWebResourceForVisualization = unchecked((int)0x8004e017); // -2147164137
        public const int ChartTypeNotSupportedForComparisonChart = unchecked((int)0x8004e018); // -2147164136
        public const int InvalidFetchCollection = unchecked((int)0x8004e019); // -2147164135
        public const int CategoryDataTypeInvalid = unchecked((int)0x8004e01a); // -2147164134
        public const int DuplicateGroupByFound = unchecked((int)0x8004e01b); // -2147164133
        public const int MultipleMeasureCollectionsFound = unchecked((int)0x8004e01c); // -2147164132
        public const int InvalidGroupByColumn = unchecked((int)0x8004e01d); // -2147164131
        public const int InvalidFilterCriteriaForVisualization = unchecked((int)0x8004e01e); // -2147164130
        public const int CountSpecifiedWithoutOrder = unchecked((int)0x8004e01f); // -2147164129
        public const int NoPreviewForCustomWebResource = unchecked((int)0x8004e020); // -2147164128
        public const int ChartTypeNotSupportedForMultipleSeriesChart = unchecked((int)0x8004e021); // -2147164127
        public const int InsufficientColumnsInSubQuery = unchecked((int)0x8004e022); // -2147164126
        public const int AggregateQueryRecordLimitExceeded = unchecked((int)0x8004e023); // -2147164125
        public const int CannotAddOrActonBehalfAnotherUserPrivilege = unchecked((int)0x8004ed43); // -2147160765
        public const int HipNoSettingError = unchecked((int)0x8004ed44); // -2147160764
        public const int HipInvalidCertificate = unchecked((int)0x8004ed45); // -2147160763
        public const int NoSettingError = unchecked((int)0x8004ed46); // -2147160762
        public const int InvalidRecurrencePattern = unchecked((int)0x8004e100); // -2147163904
        public const int CreateRecurrenceRuleFailed = unchecked((int)0x8004e101); // -2147163903
        public const int PartialExpansionSettingLoadError = unchecked((int)0x8004e102); // -2147163902
        public const int InvalidCrmDateTime = unchecked((int)0x8004e103); // -2147163901
        public const int InvalidAppointmentInstance = unchecked((int)0x8004e104); // -2147163900
        public const int InvalidSeriesId = unchecked((int)0x8004e105); // -2147163899
        public const int AppointmentDeleted = unchecked((int)0x8004e106); // -2147163898
        public const int InvalidInstanceTypeCode = unchecked((int)0x8004e107); // -2147163897
        public const int OverlappingInstances = unchecked((int)0x8004e108); // -2147163896
        public const int InvalidSeriesIdOriginalStart = unchecked((int)0x8004e109); // -2147163895
        public const int ValidateNotSupported = unchecked((int)0x8004e10a); // -2147163894
        public const int RecurringSeriesCompleted = unchecked((int)0x8004e10b); // -2147163893
        public const int ExpansionRequestIsOutsideExpansionWindow = unchecked((int)0x8004e10c); // -2147163892
        public const int InvalidInstanceEntityName = unchecked((int)0x8004e10d); // -2147163891
        public const int BookFirstInstanceFailed = unchecked((int)0x8004e10e); // -2147163890
        public const int InvalidSeriesStatus = unchecked((int)0x8004e10f); // -2147163889
        public const int RecurrenceRuleUpdateFailure = unchecked((int)0x8004e110); // -2147163888
        public const int RecurrenceRuleDeleteFailure = unchecked((int)0x8004e111); // -2147163887
        public const int EntityNotRule = unchecked((int)0x8004e112); // -2147163886
        public const int RecurringSeriesMasterIsLocked = unchecked((int)0x8004e113); // -2147163885
        public const int UpdateRecurrenceRuleFailed = unchecked((int)0x8004e114); // -2147163884
        public const int InstanceOutsideEffectiveRange = unchecked((int)0x8004e115); // -2147163883
        public const int RecurrenceCalendarTypeNotSupported = unchecked((int)0x8004e116); // -2147163882
        public const int RecurrenceHasNoOccurrence = unchecked((int)0x8004e117); // -2147163881
        public const int RecurrenceStartDateTooSmall = unchecked((int)0x8004e118); // -2147163880
        public const int RecurrenceEndDateTooBig = unchecked((int)0x8004e119); // -2147163879
        public const int OccurrenceCrossingBoundary = unchecked((int)0x8004e120); // -2147163872
        public const int OccurrenceTimeSpanTooBig = unchecked((int)0x8004e121); // -2147163871
        public const int OccurrenceSkipsOverForward = unchecked((int)0x8004e122); // -2147163870
        public const int OccurrenceSkipsOverBackward = unchecked((int)0x8004e123); // -2147163869
        public const int InvalidDaysInFebruary = unchecked((int)0x8004e124); // -2147163868
        public const int InvalidOccurrenceNumber = unchecked((int)0x8004e125); // -2147163867
        public const int InvalidNumberOfPartitions = unchecked((int)0x8004e200); // -2147163648
        public const int InvalidElementFound = unchecked((int)0x8004e300); // -2147163392
        public const int MaximumControlsLimitExceeded = unchecked((int)0x8004e301); // -2147163391
        public const int UserViewsOrVisualizationsFound = unchecked((int)0x8004e302); // -2147163390
        public const int InvalidAttributeFound = unchecked((int)0x8004e303); // -2147163389
        public const int MultipleFormElementsFound = unchecked((int)0x8004e304); // -2147163388
        public const int NullDashboardName = unchecked((int)0x8004e305); // -2147163387
        public const int InvalidFormType = unchecked((int)0x8004e306); // -2147163386
        public const int InvalidControlClass = unchecked((int)0x8004e307); // -2147163385
        public const int ImportDashboardDeletedError = unchecked((int)0x8004e308); // -2147163384
        public const int PersonalReportFound = unchecked((int)0x8004e309); // -2147163383
        public const int ObjectAlreadyExists = unchecked((int)0x8004e30a); // -2147163382
        public const int EntityTypeSpecifiedForDashboard = unchecked((int)0x8004e30b); // -2147163381
        public const int UnrestrictedIFrameInUserDashboard = unchecked((int)0x8004e30c); // -2147163380
        public const int MultipleLabelsInUserDashboard = unchecked((int)0x8004e30d); // -2147163379
        public const int UnsupportedDashboardInEditor = unchecked((int)0x8004e30e); // -2147163378
        public const int CannotRemoveComponentFromDefaultSolution = unchecked((int)0x8004f000); // -2147160064
        public const int InvalidSolutionUniqueName = unchecked((int)0x8004f002); // -2147160062
        public const int CannotUndeleteLabel = unchecked((int)0x8004f003); // -2147160061
        public const int ErrorReactivatingComponentInstance = unchecked((int)0x8004f004); // -2147160060
        public const int CannotDeleteRestrictedSolution = unchecked((int)0x8004f005); // -2147160059
        public const int CannotDeleteRestrictedPublisher = unchecked((int)0x8004f006); // -2147160058
        public const int ImportRestrictedSolutionError = unchecked((int)0x8004f007); // -2147160057
        public const int CannotSetSolutionSystemAttributes = unchecked((int)0x8004f008); // -2147160056
        public const int CannotUpdateDefaultSolution = unchecked((int)0x8004f009); // -2147160055
        public const int CannotUpdateRestrictedSolution = unchecked((int)0x8004f00a); // -2147160054
        public const int CannotAddWorkflowActivationToSolution = unchecked((int)0x8004f00c); // -2147160052
        public const int CannotQueryBaseTableWithAggregates = unchecked((int)0x8004f00d); // -2147160051
        public const int InvalidStateTransition = unchecked((int)0x8004f00e); // -2147160050
        public const int CannotUpdateUnpublishedDeleteInstance = unchecked((int)0x8004f00f); // -2147160049
        public const int UnsupportedComponentOperation = unchecked((int)0x8004f010); // -2147160048
        public const int InvalidCreateOnProtectedComponent = unchecked((int)0x8004f011); // -2147160047
        public const int InvalidUpdateOnProtectedComponent = unchecked((int)0x8004f012); // -2147160046
        public const int InvalidDeleteOnProtectedComponent = unchecked((int)0x8004f013); // -2147160045
        public const int InvalidPublishOnProtectedComponent = unchecked((int)0x8004f014); // -2147160044
        public const int CannotAddNonCustomizableComponent = unchecked((int)0x8004f015); // -2147160043
        public const int CannotOverwriteActiveComponent = unchecked((int)0x8004f016); // -2147160042
        public const int CannotUpdateRestrictedPublisher = unchecked((int)0x8004f017); // -2147160041
        public const int CannotAddSolutionComponentWithoutRoots = unchecked((int)0x8004f018); // -2147160040
        public const int ComponentDefinitionDoesNotExists = unchecked((int)0x8004f019); // -2147160039
        public const int DependencyAlreadyExists = unchecked((int)0x8004f01a); // -2147160038
        public const int DependencyTableNotEmpty = unchecked((int)0x8004f01b); // -2147160037
        public const int InvalidPublisherUniqueName = unchecked((int)0x8004f01c); // -2147160036
        public const int CannotUninstallWithDependencies = unchecked((int)0x8004f01d); // -2147160035
        public const int InvalidSolutionVersion = unchecked((int)0x8004f01e); // -2147160034
        public const int CannotDeleteInUseComponent = unchecked((int)0x8004f01f); // -2147160033
        public const int CannotUninstallReferencedProtectedSolution = unchecked((int)0x8004f020); // -2147160032
        public const int CannotRemoveComponentFromSolution = unchecked((int)0x8004f021); // -2147160031
        public const int RestrictedSolutionName = unchecked((int)0x8004f022); // -2147160030
        public const int SolutionUniqueNameViolation = unchecked((int)0x8004f023); // -2147160029
        public const int CannotUpdateManagedSolution = unchecked((int)0x8004f024); // -2147160028
        public const int DependencyTrackingClosed = unchecked((int)0x8004f025); // -2147160027
        public const int GenericManagedPropertyFailure = unchecked((int)0x8004f026); // -2147160026
        public const int CombinedManagedPropertyFailure = unchecked((int)0x8004f027); // -2147160025
        public const int ReportImportCategoryOptionNotFound = unchecked((int)0x8004f028); // -2147160024
        public const int RequiredChildReportHasOtherParent = unchecked((int)0x8004f029); // -2147160023
        public const int InvalidManagedPropertyException = unchecked((int)0x8004f030); // -2147160016
        public const int OnlyOwnerCanSetManagedProperties = unchecked((int)0x8004f031); // -2147160015
        public const int CannotDeleteMetadata = unchecked((int)0x8004f032); // -2147160014
        public const int CannotUpdateReadOnlyPublisher = unchecked((int)0x8004f033); // -2147160013
        public const int CannotSelectReadOnlyPublisher = unchecked((int)0x8004f034); // -2147160012
        public const int CannotRemoveComponentFromSystemSolution = unchecked((int)0x8004f035); // -2147160011
        public const int InvalidDependency = unchecked((int)0x8004f036); // -2147160010
        public const int InvalidDependencyFetchXml = unchecked((int)0x8004f037); // -2147160009
        public const int CannotModifyReportOutsideSolutionIfManaged = unchecked((int)0x8004f038); // -2147160008
        public const int SharePointUnableToAddUserToGroup = unchecked((int)0x8004f0f1); // -2147159823
        public const int SharePointUnableToRemoveUserFromGroup = unchecked((int)0x8004f0f2); // -2147159822
        public const int SharePointSiteNotPresentInSharePoint = unchecked((int)0x8004f0f3); // -2147159821
        public const int SharePointUnableToRetrieveGroup = unchecked((int)0x8004f0f4); // -2147159820
        public const int SharePointUnableToAclSiteWithPrivilege = unchecked((int)0x8004f0f5); // -2147159819
        public const int SharePointUnableToAclSite = unchecked((int)0x8004f0f6); // -2147159818
        public const int SharePointUnableToCreateSiteGroup = unchecked((int)0x8004f0f7); // -2147159817
        public const int SharePointSiteCreationFailure = unchecked((int)0x8004f0f8); // -2147159816
        public const int SharePointTeamProvisionJobAlreadyExists = unchecked((int)0x8004f0f9); // -2147159815
        public const int SharePointRoleProvisionJobAlreadyExists = unchecked((int)0x8004f0fa); // -2147159814
        public const int SharePointSiteWideProvisioningJobFailed = unchecked((int)0x8004f0fb); // -2147159813
        public const int DataTypeMismatchForLinkedAttribute = unchecked((int)0x8004f0fc); // -2147159812
        public const int InvalidEntityForLinkedAttribute = unchecked((int)0x8004f0fd); // -2147159811
        public const int AlreadyLinkedToAnotherAttribute = unchecked((int)0x8004f0fe); // -2147159810
        public const int DocumentManagementDisabled = unchecked((int)0x8004f0ff); // -2147159809
        public const int DefaultSiteCollectionUrlChanged = unchecked((int)0x8004f100); // -2147159808
        public const int RibbonImportHidingBasicHomeTab = unchecked((int)0x8004f101); // -2147159807
        public const int RibbonImportInvalidPrivilegeName = unchecked((int)0x8004f102); // -2147159806
        public const int RibbonImportEntityNotSupported = unchecked((int)0x8004f103); // -2147159805
        public const int RibbonImportDependencyMissingEntity = unchecked((int)0x8004f104); // -2147159804
        public const int RibbonImportDependencyMissingRibbonElement = unchecked((int)0x8004f105); // -2147159803
        public const int RibbonImportDependencyMissingWebResource = unchecked((int)0x8004f106); // -2147159802
        public const int RibbonImportDependencyMissingRibbonControl = unchecked((int)0x8004f107); // -2147159801
        public const int RibbonImportModifyingTopLevelNode = unchecked((int)0x8004f108); // -2147159800
        public const int RibbonImportLocationAndIdDoNotMatch = unchecked((int)0x8004f109); // -2147159799
        public const int RibbonImportHidingJewel = unchecked((int)0x8004f10a); // -2147159798
        public const int RibbonImportDuplicateElementId = unchecked((int)0x8004f10b); // -2147159797
        public const int WebResourceInvalidType = unchecked((int)0x8004f111); // -2147159791
        public const int WebResourceEmptySilverlightVersion = unchecked((int)0x8004f112); // -2147159790
        public const int WebResourceInvalidSilverlightVersion = unchecked((int)0x8004f113); // -2147159789
        public const int WebResourceContentSizeExceeded = unchecked((int)0x8004f114); // -2147159788
        public const int WebResourceDuplicateName = unchecked((int)0x8004f115); // -2147159787
        public const int WebResourceEmptyName = unchecked((int)0x8004f116); // -2147159786
        public const int WebResourceNameInvalidCharacters = unchecked((int)0x8004f117); // -2147159785
        public const int WebResourceNameInvalidPrefix = unchecked((int)0x8004f118); // -2147159784
        public const int WebResourceNameInvalidFileExtension = unchecked((int)0x8004f119); // -2147159783
        public const int WebResourceImportMissingFile = unchecked((int)0x8004f11a); // -2147159782
        public const int WebResourceImportError = unchecked((int)0x8004f11b); // -2147159781
        public const int InvalidActivityOwnershipTypeMask = unchecked((int)0x8004f120); // -2147159776
        public const int ActivityCannotHaveRelatedActivities = unchecked((int)0x8004f121); // -2147159775
        public const int CustomActivityMustHaveOfflineAvailability = unchecked((int)0x8004f122); // -2147159774
        public const int ActivityMustHaveRelatedNotes = unchecked((int)0x8004f123); // -2147159773
        public const int CustomActivityCannotBeMailMergeEnabled = unchecked((int)0x8004f124); // -2147159772
        public const int InvalidCustomActivityType = unchecked((int)0x8004f125); // -2147159771
        public const int ActivityMetadataUpdate = unchecked((int)0x8004f126); // -2147159770
        public const int InvalidPrimaryFieldForActivity = unchecked((int)0x8004f127); // -2147159769
        public const int CannotDeleteNonLeafNode = unchecked((int)0x8004f200); // -2147159552
        public const int DuplicateUiStatementRootsFound = unchecked((int)0x8004f201); // -2147159551
        public const int ErrorUpdateStatementTextIsReferenced = unchecked((int)0x8004f202); // -2147159550
        public const int ErrorDeleteStatementTextIsReferenced = unchecked((int)0x8004f203); // -2147159549
        public const int ErrorScriptSessionCannotCreateForDraftScript = unchecked((int)0x8004f204); // -2147159548
        public const int ErrorScriptSessionCannotUpdateForDraftScript = unchecked((int)0x8004f205); // -2147159547
        public const int ErrorScriptLanguageNotInstalled = unchecked((int)0x8004f206); // -2147159546
        public const int ErrorScriptInitialStatementNotInScript = unchecked((int)0x8004f207); // -2147159545
        public const int ErrorScriptInitialStatementNotRoot = unchecked((int)0x8004f208); // -2147159544
        public const int ErrorScriptCannotDeletePublishedScript = unchecked((int)0x8004f209); // -2147159543
        public const int ErrorScriptPublishMissingInitialStatement = unchecked((int)0x8004f20a); // -2147159542
        public const int ErrorScriptPublishMalformedScript = unchecked((int)0x8004f20b); // -2147159541
        public const int ErrorScriptUnpublishActiveScript = unchecked((int)0x8004f20c); // -2147159540
        public const int ErrorScriptSessionCannotSetStateForDraftScript = unchecked((int)0x8004f20d); // -2147159539
        public const int ErrorScriptStatementResponseTypeOnlyForPrompt = unchecked((int)0x8004f20e); // -2147159538
        public const int ErrorStatementOnlyForDraftScript = unchecked((int)0x8004f20f); // -2147159537
        public const int ErrorStatementDeleteOnlyForDraftScript = unchecked((int)0x8004f210); // -2147159536
        public const int ErrorInvalidUiScriptImportFile = unchecked((int)0x8004f211); // -2147159535
        public const int ErrorScriptFileParse = unchecked((int)0x8004f212); // -2147159534
        public const int ErrorScriptCannotUpdatePublishedScript = unchecked((int)0x8004f213); // -2147159533
        public const int ErrorInvalidFileNameChars = unchecked((int)0x8004f214); // -2147159532
        public const int ErrorMimeTypeNullOrEmpty = unchecked((int)0x8004f215); // -2147159531
        public const int ErrorImportInvalidForPublishedScript = unchecked((int)0x8004f216); // -2147159530
        public const int UiScriptIdentifierDuplicate = unchecked((int)0x8004f217); // -2147159529
        public const int UiScriptIdentifierInvalid = unchecked((int)0x8004f218); // -2147159528
        public const int UiScriptIdentifierInvalidLength = unchecked((int)0x8004f219); // -2147159527
        public const int ErrorNoQueryData = unchecked((int)0x8004f220); // -2147159520
        public const int ErrorUiScriptPromptMissing = unchecked((int)0x8004f221); // -2147159519
        public const int SharePointUrlHostValidator = unchecked((int)0x8004f301); // -2147159295
        public const int SharePointCrmDomainValidator = unchecked((int)0x8004f302); // -2147159294
        public const int SharePointServerDiscoveryValidator = unchecked((int)0x8004f303); // -2147159293
        public const int SharePointServerVersionValidator = unchecked((int)0x8004f304); // -2147159292
        public const int SharePointSiteCollectionIsAccessibleValidator = unchecked((int)0x8004f305); // -2147159291
        public const int SharePointUrlIsRootWebValidator = unchecked((int)0x8004f306); // -2147159290
        public const int SharePointSitePermissionsValidator = unchecked((int)0x8004f307); // -2147159289
        public const int SharePointServerLanguageValidator = unchecked((int)0x8004f308); // -2147159288
        public const int SharePointCrmGridIsInstalledValidator = unchecked((int)0x8004f309); // -2147159287
        public const int SharePointErrorRetrieveAbsoluteUrl = unchecked((int)0x8004f310); // -2147159280
        public const int SharePointInvalidEntityForValidation = unchecked((int)0x8004f311); // -2147159279
        public const int DocumentManagementIsDisabled = unchecked((int)0x8004f312); // -2147159278
        public const int DocumentManagementNotEnabledNoPrimaryField = unchecked((int)0x8004f313); // -2147159277
        public const int SharePointErrorAbsoluteUrlClipped = unchecked((int)0x8004f314); // -2147159276
        public const int SiteMapXsdValidationError = unchecked((int)0x8004f401); // -2147159039
        public const int LinkedAttributeCannotBeSecured = unchecked((int)0x8004f500); // -2147158784
        public const int CannotSecureAttribute = unchecked((int)0x8004f501); // -2147158783
        public const int AttributePrivilegeCreateIsMissing = unchecked((int)0x8004f502); // -2147158782
        public const int AttributePermissionUpdateIsMissingDuringShare = unchecked((int)0x8004f503); // -2147158781
        public const int AttributePermissionReadIsMissing = unchecked((int)0x8004f504); // -2147158780
        public const int CannotRemoveSysAdminProfileFromSysAdminUser = unchecked((int)0x8004f505); // -2147158779
        public const int QueryContainedSecuredAttributeWithoutAccess = unchecked((int)0x8004f506); // -2147158778
        public const int AttributePermissionUpdateIsMissingDuringUpdate = unchecked((int)0x8004f507); // -2147158777
        public const int AttributeNotSecured = unchecked((int)0x8004f508); // -2147158776
        public const int AttributeSharingCreateShouldSetReadOrAndUpdateAccess = unchecked((int)0x8004f509); // -2147158775
        public const int AttributeSharingUpdateInvalid = unchecked((int)0x8004f50a); // -2147158774
        public const int AttributeSharingCreateDuplicate = unchecked((int)0x8004f50b); // -2147158773
        public const int AdminProfileCannotBeEditedOrDeleted = unchecked((int)0x8004f50c); // -2147158772
        public const int AttributePrivilegeInvalidToUnsecure = unchecked((int)0x8004f50d); // -2147158771
        public const int RequireValidImportMapForUpdate = unchecked((int)0x8004f600); // -2147158528
        public const int InvalidFormatForUpdateMode = unchecked((int)0x8004f601); // -2147158527
        public const int MaximumCountForUpdateModeExceeded = unchecked((int)0x8004f602); // -2147158526
        public const int RecordResolutionFailed = unchecked((int)0x8004f603); // -2147158525
        public const int InvalidOperationForDynamicList = unchecked((int)0x8004f701); // -2147158271
        public const int QueryNotValidForStaticList = unchecked((int)0x8004f702); // -2147158270
        public const int LockStatusNotValidForDynamicList = unchecked((int)0x8004f703); // -2147158269
        public const int CannotCopyStaticList = unchecked((int)0x8004f704); // -2147158268
        public const int CannotDeleteSystemForm = unchecked((int)0x8004f652); // -2147158446
        public const int CannotUpdateSystemEntityIcons = unchecked((int)0x8004f653); // -2147158445
        public const int FallbackFormDeletion = unchecked((int)0x8004f654); // -2147158444
        public const int SystemFormImportMissingRoles = unchecked((int)0x8004f655); // -2147158443
        public const int SystemFormCopyUnmatchedEntity = unchecked((int)0x8004f656); // -2147158442
        public const int SystemFormCopyUnmatchedFormType = unchecked((int)0x8004f657); // -2147158441
        public const int SystemFormCreateWithExistingLabel = unchecked((int)0x8004f658); // -2147158440
        public const int RuntimeRibbonXmlValidation = unchecked((int)0x8004f671); // -2147158415
        public const int InitializeErrorNoReadOnSource = unchecked((int)0x8004f800); // -2147158016
        public const int NoRollupAttributesDefined = unchecked((int)0x8004f681); // -2147158399
        public const int GoalPercentageAchievedValueOutOfRange = unchecked((int)0x8004f682); // -2147158398
        public const int InvalidRollupQueryAttributeSet = unchecked((int)0x8004f683); // -2147158397
        public const int InvalidGoalManager = unchecked((int)0x8004f684); // -2147158396
        public const int InactiveRollupQuerySetOnGoal = unchecked((int)0x8004f685); // -2147158395
        public const int InactiveMetricSetOnGoal = unchecked((int)0x8004f686); // -2147158394
        public const int MetricEntityOrFieldDeleted = unchecked((int)0x8004f687); // -2147158393
        public const int LanguageProvisioningSrsDataConnectorNotInstalled = unchecked((int)0x8004f710); // -2147158256
        public const int BidsInvalidConnectionString = unchecked((int)0x8005e000); // -2147098624
        public const int BidsInvalidUrl = unchecked((int)0x8005e001); // -2147098623
        public const int BidsServerConnectionFailed = unchecked((int)0x8005e002); // -2147098622
        public const int BidsAuthenticationError = unchecked((int)0x8005e003); // -2147098621
        public const int BidsNoOrganizationsFound = unchecked((int)0x8005e004); // -2147098620
        public const int BidsOrganizationNotFound = unchecked((int)0x8005e005); // -2147098619
        public const int BidsAuthenticationFailed = unchecked((int)0x8005e006); // -2147098618
        public const int TransactionNotSupported = unchecked((int)0x8005e007); // -2147098617
        public const int IndexOutOfRange = unchecked((int)0x8005e008); // -2147098616
        public const int InvalidAttribute = unchecked((int)0x8005e009); // -2147098615
        public const int MultiValueParameterFound = unchecked((int)0x8005e00a); // -2147098614
        public const int QueryParameterNotUnique = unchecked((int)0x8005e00b); // -2147098613
        public const int InvalidEntity = unchecked((int)0x8005e00c); // -2147098612
        public const int UnsupportedAttributeType = unchecked((int)0x8005e00d); // -2147098611
        public const int FetchDataSetQueryTimeout = unchecked((int)0x8005e00e); // -2147098610

        private static readonly Hashtable ErrorMessages = new Hashtable();

        static XrmErrorCodes()
        {
            ErrorMessages.Add(CannotUpdateOrgDbOrgSettingWhenOffline, "Organization Settings stored in Organization Database cannot be set when offline.");
            ErrorMessages.Add(InvalidOrgDbOrgSetting, "Invalid Organization Setting passed in. Please check the datatype and pass in an appropriate value.");
            ErrorMessages.Add(UnknownInvalidTransformationParameterGeneric, "One or more input transformation parameter values are invalid: {0}.");
            ErrorMessages.Add(InvalidTransformationParameterOutsideRangeGeneric, "One or more input transformation parameter values are outside the permissible range: {0}.");
            ErrorMessages.Add(InvalidTransformationParameterEmptyCollection, "The transformation parameter: {0} has an invalid input value length: {1}. The parameter length cannot be an empty collection.");
            ErrorMessages.Add(InvalidTransformationParameterOutsideRange, "The transformation parameter: {0} has an invalid input value: {1}. The parameter is out of the permissible range: {2}. ");
            ErrorMessages.Add(InvalidTransformationParameterZeroToRange, "The transformation parameter: {0} has an invalid input value: {1}. The parameter value must be greater than 0 and less than the length of the parameter 1.");
            ErrorMessages.Add(InvalidTransformationParameterString, "The transformation parameter: {0} has an invalid input value: {1}. The parameter must be a string that is not empty.");
            ErrorMessages.Add(InvalidTransformationParametersGeneric, "The transformation parameter: {0} has an invalid input value: {1}. The parameter must be of type: {2}.");
            ErrorMessages.Add(InsufficientTransformationParameters, "Insufficient parameters to execute transformation mapping.");
            ErrorMessages.Add(MaximumNumberHandlersExceeded, "This solution adds form event handlers so the number of event handlers for a form event exceeds the maximum number.");
            ErrorMessages.Add(ErrorInUnzipAlternate, "An error occurred while the uploaded .zip file was being extracted. Try to upload the file again. If the problem persists, contact your system administrator.");
            ErrorMessages.Add(IncorrectSingleFileMultipleEntityMap, "There should be two or more Entity Mappings defined when EntitiesPerFile in ImportMap is set to Multiple");
            ErrorMessages.Add(ActivityEntityCannotBeActivityParty, "An activity entity cannot be also an activity party");
            ErrorMessages.Add(TargetAttributeInvalidForIgnore, "Target attribute name should be empty when the processcode is ignore.");
            ErrorMessages.Add(MaxUnzipFolderSizeExceeded, "File cannot be unzipped because it exceeded the maximum server storage size limit. Please try again.");
            ErrorMessages.Add(InvalidMultipleMapping, "A source field is mapped to more than one CRM fields of lookup/picklist type.");
            ErrorMessages.Add(ErrorInStoringImportFile, "An error occurred while storing the import file in database.");
            ErrorMessages.Add(UnzipTimeout, "Timeout happened in unzipping the zip file uploaded for import.");
            ErrorMessages.Add(UnsupportedZipFileForImport, "The structure of the zip file is not support for import.");
            ErrorMessages.Add(UnzipProcessCountLimitReached, "Cannot start a new process to unzip.");
            ErrorMessages.Add(AttachmentNotFound, "The reference to the attachment could not be found.");
            ErrorMessages.Add(TooManyPicklistValues, "Number of distinct picklist values exceed the limit.");
            ErrorMessages.Add(VeryLargeFileInZipImport, "One of the files in the .zip file that you are trying to import exceeds the size limit.");
            ErrorMessages.Add(InvalidAttachmentsFolder, "The .zip file cannot be uploaded because the folder \"Attachments\" contains one or more subfolders. Remove the subfolders and try again.");
            ErrorMessages.Add(ZipInsideZip, "The zip file that you are trying to upload contains another zip file within it.");
            ErrorMessages.Add(InvalidZipFileFormat, "The file that you are trying to upload is not a valid file. Check the file and try again.");
            ErrorMessages.Add(EmptyFileForImport, "The selected file contains no data.");
            ErrorMessages.Add(EmptyFilesInZip, "One or more files in the .zip file do not contain data. Check the files and try again.");
            ErrorMessages.Add(ZipFileHasMixOfCsvAndXmlFiles, "The zip file that you are trying to upload contains both CSV and XML Spreadsheet 2003 format. The zip file can contain either CSV files or XML Spreadsheet 2003 files, but not both.");
            ErrorMessages.Add(DuplicateFileNamesInZip, "Two or more files have the same name. File names must be unique.");
            ErrorMessages.Add(ErrorInUnzip, "An error occurred while unzipping the selected file.Try importing file again.If this problem persists, contact your system administrator.");
            ErrorMessages.Add(InvalidZipFileForImport, "Unzip file has invalid files for import.Zip file should contain either csv or xml files.");
            ErrorMessages.Add(InvalidLookupMapNode, "The lookup entity provided is not valid for the given target attribute.");
            ErrorMessages.Add(ImportMailMergeTemplateEntityMissingError, "The {0} mail merge template was not imported because the {1} entity associated with this template is not in the target system.");
            ErrorMessages.Add(CannotUpdateOpportunityCurrency, "The currency cannot be changed because this opportunity has Products Quotes, and/ or Orders associated with it.  If you want to change the currency please delete all of the Products/quotes/orders and then change the currency or create a new opportunity with the appropriate currency.");
            ErrorMessages.Add(ParentRecordAlreadyExists, "This record cannot be added because it already has a parent record.");
            ErrorMessages.Add(MissingWebToLeadRedirect, "The redirectto is missing for web2lead redirect.");
            ErrorMessages.Add(InvalidWebToLeadRedirect, "The redirectto is invalid for web2lead redirect.");
            ErrorMessages.Add(TemplateNotAllowedForInternetMarketing, "Creating Templates with Internet Marketing Campaign Activities is not allowed");
            ErrorMessages.Add(CopyNotAllowedForInternetMarketing, "Duplicating campaigns that have Internet Marketing Campaign Activities is not allowed");
            ErrorMessages.Add(MissingOrInvalidRedirectId, "The RedirId parameter is missing for the partner redirect.");
            ErrorMessages.Add(ImportNotComplete, "One or more imports are not in completed state. Imported records can only be deleted from completed jobs. Wait until job completes, and then try again.");
            ErrorMessages.Add(UiDataMissingInWorkflow, "The workflow does not contain UIData.");
            ErrorMessages.Add(RefEntityRelationshipRoleRequired, "The entity relationship role of the referencing entity is required when creating a new one-to-many entity relationship.");
            ErrorMessages.Add(ImportTemplateLanguageIgnored, "You cannot import this template because its language is not enabled in your Microsoft Dynamics CRM organization.");
            ErrorMessages.Add(ImportTemplatePersonalIgnored, "You cannot import this template because it is set as \"personal\" in your Microsoft Dynamics CRM organization.");
            ErrorMessages.Add(ImportComponentDeletedIgnored, "You cannot update this component because it does not exist in this Microsoft Dynamics CRM organization.");
            ErrorMessages.Add(RelationshipRoleNodeNumberInvalid, "There must be two entity relationship role nodes when creating a new many-to-many entity relationship.");
            ErrorMessages.Add(AssociationRoleOrdinalInvalid, "The association role ordinal is not valid - it must be 1 or 2.");
            ErrorMessages.Add(RelationshipRoleMismatch, "The relationship role name {0} does not match either expected entity name of {1} or {2}.");
            ErrorMessages.Add(ImportMapInUse, "One or more of the selected data maps cannot be deleted because it is currently used in a data import.");
            ErrorMessages.Add(PreviousOperationNotComplete, "An operation on which this operation depends did not complete successfully.");
            ErrorMessages.Add(TransformationResumeNotSupported, "The resume/retry of Transformation job of Import is not supported.");
            ErrorMessages.Add(CannotDisableDuplicateDetection, "Duplicate detection cannot be disabled because a duplicate detection job is currently in progress. Try again later.");
            ErrorMessages.Add(TargetEntityNotMapped, "Target Entity Name not defined for source:{0} file.");
            ErrorMessages.Add(BulkDeleteChildFailure, "One of the Bulk Delete Child Jobs Failed");
            ErrorMessages.Add(CannotRemoveNonListMember, "Specified Item not a member of the specified List.");
            ErrorMessages.Add(JobNameIsEmptyOrNull, "Job Name can not be null or empty.");
            ErrorMessages.Add(ImportMailMergeTemplateError, "There was an error in parsing the mail merge templates in Import Xml");
            ErrorMessages.Add(ErrorsInWorkflowDefinition, "The selected workflow has errors and cannot be published. Please open the workflow, remove the errors and try again.");
            ErrorMessages.Add(DistributeNoListAssociated, "This campaign activity cannot be distributed. No marketing lists are associated with it. Add at least one marketing list and try again.");
            ErrorMessages.Add(DistributeListAssociatedVary, "This campaign activity cannot be distributed. Mail merge activities can be done only on marketing lists that are all the same record type. For this campaign activity, remove marketing lists so that the remaining ones are the same record type, and then try again.");
            ErrorMessages.Add(OfflineFilterParentDownloaded, "You cannot use the Parent Downloaded condition in a local data group.");
            ErrorMessages.Add(OfflineFilterNestedDateTimeOr, "You cannot use nested date time conditions within an OR clause in a local data group.");
            ErrorMessages.Add(DuplicateOfflineFilter, "You can create only one local data group for each record type.");
            ErrorMessages.Add(CannotAssignAddressBookFilters, "Cannot assign address book filters");
            ErrorMessages.Add(CannotCreateAddressBookFilters, "Cannot create address book filters");
            ErrorMessages.Add(CannotGrantAccessToAddressBookFilters, "Cannot grant access to address book filters");
            ErrorMessages.Add(CannotModifyAccessToAddressBookFilters, "Cannot modify access for address book filters");
            ErrorMessages.Add(CannotRevokeAccessToAddressBookFilters, "Cannot revoke access for address book filters");
            ErrorMessages.Add(DuplicateMapName, "A data map with the specified name already exists.");
            ErrorMessages.Add(InvalidWordXmlFile, "Only Microsoft Word xml format files can be uploaded.");
            ErrorMessages.Add(FileNotFound, "The attachment file was not found.");
            ErrorMessages.Add(MultipleFilesFound, "The attachment file name is not unique.");
            ErrorMessages.Add(InvalidAttributeMapping, "One or more attribute mappings is invalid.");
            ErrorMessages.Add(FileReadError, "There was an error reading the file from the file system. Make sure you have read permission for this file, and then try migrating the file again.");
            ErrorMessages.Add(ViewForDuplicateDetectionNotDefined, "Required view for viewing duplicates of an entity not defined.");
            ErrorMessages.Add(FileInUse, "Could not read the file because another application is using the file.");
            ErrorMessages.Add(NoPublishedDuplicateDetectionRules, "There are no published duplicate detection rules in the system. To run duplicate detection, you must create and publish one or more rules.");
            ErrorMessages.Add(NoEntitiesForBulkDelete, "The Bulk Delete Wizard cannot be opened because there are no valid entities for deletion.");
            ErrorMessages.Add(BulkDeleteRecordDeletionFailure, "The record cannot be deleted.");
            ErrorMessages.Add(RuleAlreadyPublishing, "The selected duplicate detection rule is already being published.");
            ErrorMessages.Add(RuleNotFound, "No rules were found that match the criteria.");
            ErrorMessages.Add(CannotDeleteSystemEmailTemplate, "System e-mail templates cannot be deleted.");
            ErrorMessages.Add(EntityDupCheckNotSupportedSystemWide, "Duplicate detection is not enabled for one or more of the selected entities. The duplicate detection job cannot be started.");
            ErrorMessages.Add(DuplicateDetectionNotSupportedOnAttributeType, "The rule condition cannot be created or updated because duplicate detection is not supported on the data type of the selected attribute.");
            ErrorMessages.Add(MaxMatchCodeLengthExceeded, "The rule condition cannot be created or updated because it would cause the matchcode length to exceed the maximum limit.");
            ErrorMessages.Add(CannotDeleteUpdateInUseRule, "The duplicate detection rule is currently in use and cannot be updated or deleted. Please try again later.");
            ErrorMessages.Add(ImportMappingsInvalidIdSpecified, "The XML file has one or more invalid IDs. The specified ID cannot be used as a unique identifier.");
            ErrorMessages.Add(NotAWellFormedXml, "The input XML is not well-formed XML.");
            ErrorMessages.Add(NoncompliantXml, "The input XML does not comply with the XML schema.");
            ErrorMessages.Add(DuplicateDetectionTemplateNotFound, "Microsoft Dynamics CRM could not retrieve the e-mail notification template.");
            ErrorMessages.Add(RulesInInconsistentStateFound, "One or more rules cannot be unpublished, either because they are in the process of being published, or are in a state where they cannot be unpublished.");
            ErrorMessages.Add(BulkDetectInvalidEmailRecipient, "The e-mail recipient either does not exist or the e-mail address for the e-mail recipient is not valid.");
            ErrorMessages.Add(CannotEnableDuplicateDetection, "Duplicate detection cannot be enabled because one or more rules are being published.");
            ErrorMessages.Add(CannotDeleteInUseEntity, "The selected entity cannot be deleted because it is referenced by one or more duplicate detection rules that are in process of being published.");
            ErrorMessages.Add(StringAttributeIndexError, "One of the attributes of the selected entity is a part of database index and so it cannot be greater than 900 bytes.");
            ErrorMessages.Add(CannotChangeAttributeRequiredLevel, "An attribute's required level cannot be changed from SystemRequired");
            ErrorMessages.Add(MaximumNumberOfAttributesForEntityReached, "The maximum number of attributes allowed for an entity has already been reached. The attribute cannot be created.");
            ErrorMessages.Add(CannotPublishMoreRules, "The selected record type already has the maximum number of published rules. Unpublish or delete existing rules for this record type, and then try again.");
            ErrorMessages.Add(CannotDeleteInUseAttribute, "The selected attribute cannot be deleted because it is referenced by one or more duplicate detection rules that are being published.");
            ErrorMessages.Add(CannotDeleteInUseOptionSet, "This option set cannot be deleted. The current set of entities that reference this option set are: {0}. These references must be removed before this option set can be deleted");
            ErrorMessages.Add(InvalidEntityName, "The record type does not match the base record type and the matching record type of the duplicate detection rule.");
            ErrorMessages.Add(InvalidOperatorCode, "The operator is not valid or it is not supported.");
            ErrorMessages.Add(CannotPublishEmptyRule, "No criteria have been specified. Add criteria, and then publish the duplicate detection rule.");
            ErrorMessages.Add(CannotPublishInactiveRule, "The selected duplicate detection rule is marked as Inactive. Before publishing, you must activate the rule.");
            ErrorMessages.Add(DuplicateCheckNotEnabled, "Duplicate detection is not enabled. To enable duplicate detection, click Settings, click Data Management, and then click Duplicate Detection Settings.");
            ErrorMessages.Add(DuplicateCheckNotSupportedOnEntity, "Duplicate detection is not supported on this record type.");
            ErrorMessages.Add(InvalidStateCodeStatusCode, "State code is invalid or state code is valid but status code is invalid for a specified state code.");
            ErrorMessages.Add(SyncToMsdeFailure, "Failed to start or connect to the offline mode MSDE database.");
            ErrorMessages.Add(AccessDenied, "Access is denied.");
            ErrorMessages.Add(CannotDeleteOptionSet, "The selected OptionSet cannot be deleted");
            ErrorMessages.Add(InvalidOptionSetOperation, "Invalid OptionSet");
            ErrorMessages.Add(OptionValuePrefixOutOfRange, "CustomizationOptionValuePrefix must be a number between {0} and {1}");
            ErrorMessages.Add(CheckPrivilegeGroupForUserOnPremiseError, "Please select an account that is a member of the PrivUserGroup security group and try again.");
            ErrorMessages.Add(CheckPrivilegeGroupForUserOnSplaError, "Please select a CRM System Administrator account that belongs to the root business unit and try again.");
            ErrorMessages.Add(UnManagedIdsAccessDenied, "Not enough privilege to access the Microsoft Dynamics CRM object or perform the requested operation.");
            ErrorMessages.Add(EntityIsIntersect, "The specified entity is intersect entity");
            ErrorMessages.Add(CannotDeleteTeamOwningRecords, "Can't delete a team which owns records. Reassign the records and try again.");
            ErrorMessages.Add(CannotRemoveMembersFromDefaultTeam, "Can't remove members from the default business unit team.");
            ErrorMessages.Add(CannotAddMembersToDefaultTeam, "Can't add members to the default business unit team.");
            ErrorMessages.Add(CannotUpdateNameDefaultTeam, "The default business unit team name can't be updated.");
            ErrorMessages.Add(CannotSetParentDefaultTeam, "The default business unit team parent can't be set.");
            ErrorMessages.Add(CannotDeleteDefaultTeam, "The default business unit team can't be deleted.");
            ErrorMessages.Add(TeamNameTooLong, "The specified name for the team is too long.");
            ErrorMessages.Add(InvalidDomainName, "The domain logon for this user is invalid. Select another domain logon and try again.");
            ErrorMessages.Add(InvalidUserName, "You must enter the user name in the format <name>@<domain>. Correct the format and try again.");
            ErrorMessages.Add(BulkMailServiceNotAccessible, "The Microsoft Dynamics CRM Bulk E-Mail Service is not running.");
            ErrorMessages.Add(RsMoveItemError, "Cannot move report item {0} to {1}");
            ErrorMessages.Add(ReportParentChildNotCustomizable, "The report could not be updated because either the parent report or the child report is not customizable.");
            ErrorMessages.Add(ConvertFetchDataSetError, "An unexpected error occurred while processing the Fetch data set.");
            ErrorMessages.Add(ConvertReportToCrmError, "An unexpected error occurred while converting supplied report to CRM format.");
            ErrorMessages.Add(ReportViewerError, "An error occurred during report rendering.");
            ErrorMessages.Add(RsGetItemTypeError, "Error occurred while fetching the report.");
            ErrorMessages.Add(RsSetPropertiesError, "Error occurred while setting property values for the report.");
            ErrorMessages.Add(RsReportParameterTypeMismatchError, "The parameter type of the report is not valid.");
            ErrorMessages.Add(RsUpdateReportExecutionSnapshotError, "Error occurred while taking snapshot of a report.");
            ErrorMessages.Add(RsSetReportHistoryLimitError, "Error occurred while setting report history snapshot limit.");
            ErrorMessages.Add(RsSetReportHistoryOptionsError, "Error occurred while setting report history snapshot options.");
            ErrorMessages.Add(RsSetExecutionOptionsError, "Error occurred while setting execution options.");
            ErrorMessages.Add(RsSetReportParametersError, "Error occurred while setting report parameters.");
            ErrorMessages.Add(RsGetReportParametersError, "Error occurred while getting report parameters.");
            ErrorMessages.Add(RsSetItemDataSourcesError, "Error occurred while setting the data source.");
            ErrorMessages.Add(RsGetItemDataSourcesError, "Error occurred while fetching current data sources.");
            ErrorMessages.Add(RsCreateBatchError, "Error occurred while creating a batch operation.");
            ErrorMessages.Add(RsListReportHistoryError, "Error occurred while fetching the report history snapshots.");
            ErrorMessages.Add(RsGetReportHistoryLimitError, "Error occurred while fetching the number of snapshots stored for the report.");
            ErrorMessages.Add(RsExecuteBatchError, "Error occurred while performing the batch operation.");
            ErrorMessages.Add(RsCancelBatchError, "Error occurred while canceling the batch operation.");
            ErrorMessages.Add(RsListExtensionsError, "Error occurred while fetching the list of data extensions installed on the report server.");
            ErrorMessages.Add(RsGetDataSourceContentsError, "Error occurred while getting the data source contents.");
            ErrorMessages.Add(RsSetDataSourceContentsError, "Error occurred while setting the data source contents.");
            ErrorMessages.Add(RsFindItemsError, "Error occurred while finding an item on the report server.");
            ErrorMessages.Add(RsDeleteItemError, "Error occurred while deleting an item from the report server.");
            ErrorMessages.Add(ReportSecurityError, "The report contains a security violation.");
            ErrorMessages.Add(ReportMissingReportSourceError, "No source has been specified for the report.");
            ErrorMessages.Add(ReportMissingParameterError, "A parameter expected by the report has not been supplied.");
            ErrorMessages.Add(ReportMissingEndpointError, "The SOAP endpoint used by the ReportViewer control could not be accessed.");
            ErrorMessages.Add(ReportMissingDataSourceError, "A data source expected by the report has not been supplied.");
            ErrorMessages.Add(ReportMissingDataSourceCredentialsError, "Credentials have not been supplied for a data source used by the report.");
            ErrorMessages.Add(ReportLocalProcessingError, "Error occurred while viewing locally processed report.");
            ErrorMessages.Add(ReportServerSp2HotFixNotApplied, "Report server SP2 Workgroup does not have the hotfix for role creation");
            ErrorMessages.Add(DataSourceProhibited, "A non fetch based data source is not permitted on this report");
            ErrorMessages.Add(ReportServerVersionLow, "Report server does not meet the minimal version requirement");
            ErrorMessages.Add(ReportServerNoPrivilege, "Not enough privilege to configure report server");
            ErrorMessages.Add(ReportServerInvalidUrl, "Cannot contact report server from given URL");
            ErrorMessages.Add(ReportServerUnknownException, "Unknown exception thrown by report server");
            ErrorMessages.Add(ReportNotAvailable, "Report not available");
            ErrorMessages.Add(ErrorUploadingReport, "An error occurred while trying to add the report to Microsoft Dynamics CRM. Try adding the report again. If this problem persists, contact your system administrator.");
            ErrorMessages.Add(ReportFileTooBig, "The file is too large and cannot be uploaded. Please reduce the size of the file and try again.");
            ErrorMessages.Add(ReportFileZeroLength, "You have uploaded an empty file.  Please select a new file and try again.");
            ErrorMessages.Add(ReportTypeBlocked, "The report is not a valid type.  It cannot be uploaded or downloaded.");
            ErrorMessages.Add(ReportUploadDisabled, "Reporting Services reports cannot be uploaded. If you want to create a new report, please use the Report Wizard.");
            ErrorMessages.Add(BothConnectionSidesAreNeeded, "You must provide a name or select a role for both sides of this connection.");
            ErrorMessages.Add(CannotConnectToSelf, "Cannot connect a record to itself.");
            ErrorMessages.Add(UnrelatedConnectionRoles, "The connection roles are not related.");
            ErrorMessages.Add(ConnectionRoleNotValidForObjectType, "The record type {0} is not defined for use with the connection role {1}.");
            ErrorMessages.Add(ConnectionCannotBeEnabledOnThisEntity, "Connections cannot be enabled on this entity");
            ErrorMessages.Add(ConnectionNotSupported, "The selected record does not support connections. You cannot add the connection.");
            ErrorMessages.Add(ConnectionObjectsMissing, "Both objects being connected are missing.");
            ErrorMessages.Add(ConnectionInvalidStartEndDate, "Start date / end date is invalid.");
            ErrorMessages.Add(ConnectionExists, "Connection already exists.");
            ErrorMessages.Add(DecoupleUserOwnedEntity, "Can only decouple user owned entities.");
            ErrorMessages.Add(DecoupleChildEntity, "Cannot decouple a child entity.");
            ErrorMessages.Add(ExistingParentalRelationship, "A parental relationship already exists.");
            ErrorMessages.Add(InvalidCascadeLinkType, "The cascade link type is not valid for the cascade action.");
            ErrorMessages.Add(InvalidDeleteModification, "A system relationship's delete cascading action cannot be modified.");
            ErrorMessages.Add(CustomerOpportunityRoleExists, "Customer opportunity role exists.");
            ErrorMessages.Add(CustomerRelationshipExists, "Customer relationship already exists.");
            ErrorMessages.Add(MultipleRelationshipsNotSupported, "Multiple relationships are not supported");
            ErrorMessages.Add(ImportDuplicateEntity, "This import has failed because a different entity with the identical name, {0}, already exists in the target organization.");
            ErrorMessages.Add(CascadeProxyEmptyCallerId, "Empty Caller Id");
            ErrorMessages.Add(CascadeProxyInvalidPrincipalType, "Invalid security principal type");
            ErrorMessages.Add(CascadeProxyInvalidNativeDaPtr, "Invalid pointer of unmanaged data access object");
            ErrorMessages.Add(CascadeFailToCreateNativeDaWrapper, "Failed to create unmanaged data access wrapper");
            ErrorMessages.Add(CascadeReparentOnNonUserOwned, "Cannot perform Cascade Reparent on Non-UserOwned entities");
            ErrorMessages.Add(CascadeMergeInvalidSpecialColumn, "Invalid Column Name for Merge Special Casing");
            ErrorMessages.Add(CascadeRemoveLinkOnNonNullable, "CascadeDelete is defined as RemoveLink while the foreign key is not nullable");
            ErrorMessages.Add(CascadeDeleteNotAllowDelete, "Object is not allowed to be deleted");
            ErrorMessages.Add(CascadeInvalidLinkType, "Invalid CascadeLink Type");
            ErrorMessages.Add(IsvExtensionsPrivilegeNotPresent, "To import ISV.Config, your user account must be associated with a security role that includes the ISV Extensions privilege.");
            ErrorMessages.Add(RelationshipNameLengthExceedsLimit, "Relationship name cannot be more than 50 characters long.");
            ErrorMessages.Add(ImportEmailTemplateErrorMissingFile, "E-mail Template '{0}' import: The attachment '{1}' was not found in the import zip file.");
            ErrorMessages.Add(CascadeInvalidExtraConditionValue, "Invalid Extra-condition value");
            ErrorMessages.Add(ImportWorkflowNameConflictError, "Workflow {0} cannot be imported because a workflow with same name and different unique identifier exists in the target system. Change the name of this workflow, and then try again.");
            ErrorMessages.Add(ImportWorkflowPublishedError, "Workflow {0}({1}) cannot be imported because a workflow with same unique identifier is published on the target system. Unpublish the workflow on the target system before attempting to import this workflow again.");
            ErrorMessages.Add(ImportWorkflowEntityDependencyError, "Cannot import workflow definition. Required entity dependency is missing.");
            ErrorMessages.Add(ImportWorkflowAttributeDependencyError, "Cannot import workflow definition. Required attribute dependency is missing.");
            ErrorMessages.Add(ImportWorkflowError, "Cannot import workflow definition. The workflow with specified workflow id is not updatable or workflow name is not unique.");
            ErrorMessages.Add(ImportGenericEntitiesError, "An error occurred while importing generic entities.");
            ErrorMessages.Add(ImportRolePermissionError, "You do not have the necessary privileges to import security roles.");
            ErrorMessages.Add(ImportRoleError, "Cannot import security role. The role with specified role id is not updatable or role name is not unique.");
            ErrorMessages.Add(ImportOrgSettingsError, "There was an error parsing the Organization Settings during Import.");
            ErrorMessages.Add(InvalidSharePointSiteCollectionUrl, "The URL must conform to the http or https schema.");
            ErrorMessages.Add(InvalidSiteRelativeUrlFormat, "The relative url contains invalid characters. Please use a different name. Valid relative url names cannot end with the following strings: .aspx, .ashx, .asmx, .svc , cannot begin or end with a dot or /, cannot contain consecutive dots or / and cannot contain any of the following characters: ~ \" # % & * : < > ? \\ { | }.");
            ErrorMessages.Add(InvalidRelativeUrlFormat, "The relative url contains invalid characters. Please use a different name. Valid relative url names cannot ends with the following strings: .aspx, .ashx, .asmx, .svc , cannot begin or end with a dot, cannot contain consecutive dots and cannot contain any of the following characters: ~ \" # % & * : < > ? / \\ { | }.");
            ErrorMessages.Add(InvalidAbsoluteUrlFormat, "The absolute url contains invalid characters. Please use a different name. Valid absolute url cannot ends with the following strings: .aspx, .ashx, .asmx, .svc");
            ErrorMessages.Add(InvalidUrlConsecutiveSlashes, "The Url contains consecutive slashes which is not allowed.");
            ErrorMessages.Add(SharePointRecordWithDuplicateUrl, "There is already a record with the same Url.");
            ErrorMessages.Add(SharePointAbsoluteAndRelativeUrlEmpty, "Both absolute URL and relative URL cannot be null.");
            ErrorMessages.Add(ImportOptionSetsError, "An error occurred while importing OptionSets.");
            ErrorMessages.Add(ImportRibbonsError, "An error occurred while importing Ribbons.");
            ErrorMessages.Add(ImportReportsError, "An error occurred while importing Reports.");
            ErrorMessages.Add(ImportSolutionError, "An error occurred while importing a Solution.");
            ErrorMessages.Add(ImportDependencySolutionError, "{0} requires solutions that are not currently installed. Import the following solutions before Importing this one. {1} ");
            ErrorMessages.Add(ExportSolutionError, "An error occurred while exporting a Solution.");
            ErrorMessages.Add(ExportManagedSolutionError, "An error occurred while exporting a solution. Managed solutions cannot be exported.");
            ErrorMessages.Add(ExportMissingSolutionError, "An error occurred while exporting a solution. The solution does not exist in this system.");
            ErrorMessages.Add(ImportSolutionManagedError, "Solution '{0}' already exists in this system as managed and cannot be upgraded.");
            ErrorMessages.Add(ImportOptionSetAttributeError, "Attribute '{0}' was not imported as it references a non-existing global Option Set ('{1}').");
            ErrorMessages.Add(ImportSolutionManagedToUnmanagedMismatch, "The solution is already installed on this system as an unmanaged solution and the package supplied is attempting to install it in managed mode. Import can only update solutions when the modes match. Uninstall the current solution and try again.");
            ErrorMessages.Add(ImportSolutionUnmanagedToManagedMismatch, "The solution is already installed on this system as a managed solution and the package supplied is attempting to install it in unmanaged mode. Import can only update solutions when the modes match. Uninstall the current solution and try again.");
            ErrorMessages.Add(ImportSolutionIsvConfigWarning, "ISV Config was overwritten.");
            ErrorMessages.Add(ImportSolutionSiteMapWarning, "SiteMap was overwritten.");
            ErrorMessages.Add(ImportSolutionOrganizationSettingsWarning, "Organization settings were overwritten.");
            ErrorMessages.Add(ImportExportDeprecatedError, "This message is no longer available. Please consult the SDK for alternative messages.");
            ErrorMessages.Add(ImportSystemSolutionError, "System solution cannot be imported.");
            ErrorMessages.Add(ImportTranslationMissingSolutionError, "An error occurred while importing the translations. The solution associated with the translations does not exist in this system.");
            ErrorMessages.Add(ExportDefaultAsPackagedError, "The default solution cannot be exported as a package.");
            ErrorMessages.Add(ImportDefaultAsPackageError, "The package supplied for the default solution is trying to install it in managed mode. The default solution cannot be managed. In the XML for the default solution, set the Managed value back to \"false\" and try to import the solution again.");
            ErrorMessages.Add(ImportCustomizationsBadZipFileError, "The solution file is invalid. The compressed file must contain the following files at its root: solution.xml, customizations.xml, and [Content_Types].xml. Customization files exported from previous versions of Microsoft Dynamics CRM are not supported.");
            ErrorMessages.Add(ImportTranslationsBadZipFileError, "The translation file is invalid. The compressed file must contain the following files at its root: CrmTranslations.xml, [Content_Types].xml.");
            ErrorMessages.Add(ImportAttributeNameError, "Invalid name for attribute {0}.  Custom attribute names must start with a valid customization prefix. The prefix for a solution component should match the prefix that is specified for the publisher of the solution.");
            ErrorMessages.Add(ImportFieldSecurityProfileIsSecuredMissingError, "Some field security permissions could not be imported because the following fields are not securable: {0}.");
            ErrorMessages.Add(ImportFieldSecurityProfileAttributesMissingError, "Some field security permissions could not be imported because the following fields are not in the system: {0}.");
            ErrorMessages.Add(ImportFileSignatureInvalid, "The import file has an invalid digital signature.");
            ErrorMessages.Add(ImportSolutionPackageNotValid, "The solution package you are importing was generated on a version of Microsoft Dynamics CRM that cannot be imported into this system. Package Version: {0} {1}, System Version: {2} {3}.");
            ErrorMessages.Add(ImportSolutionPackageNeedsUpgrade, "The solution package you are importing was generated on a different version of Microsoft Dynamics CRM. The system will attempt to transform the package prior to import. Package Version: {0} {1}, System Version: {2} {3}.");
            ErrorMessages.Add(ImportSolutionPackageMinimumVersionNeeded, "The solution package you are importing was generated on a version of Microsoft Dynamics CRM that is lower than the minimum supported version stated on the package. Minimum Version Supported: {0} {1}, System Version: {2} {3}.");
            ErrorMessages.Add(ImportSdkMessagesError, "An error occurred while importing Sdk Messages.");
            ErrorMessages.Add(ImportEmailTemplatePersonalError, "E-mail Template was not imported. The Template is a personal template on the target system; import cannot overwrite personal templates.");
            ErrorMessages.Add(ImportNonWellFormedFileError, "Invalid customization file. This file is not well formed.");
            ErrorMessages.Add(ImportPluginTypesError, "An error occurred while importing plug-in types.");
            ErrorMessages.Add(ImportSiteMapError, "An error occurred while importing the Site Map.");
            ErrorMessages.Add(ImportMappingsMissingEntityMapError, "This customization file contains a reference to an entity map that does not exist on the target system.");
            ErrorMessages.Add(ImportMappingsSystemMapError, "Import cannot create system attribute mappings");
            ErrorMessages.Add(ImportIsvConfigError, "There was an error parsing the IsvConfig during Import");
            ErrorMessages.Add(ImportArticleTemplateError, "There was an error in parsing the article templates in Import Xml");
            ErrorMessages.Add(ImportEmailTemplateError, "There was an error in parsing the email templates in Import Xml");
            ErrorMessages.Add(ImportContractTemplateError, "There was an error in parsing the contract templates in Import Xml");
            ErrorMessages.Add(ImportRelationshipRoleMapsError, "The number of format parameters passed into the input string is incorrect");
            ErrorMessages.Add(ImportRelationshipRolesError, "The number of format parameters passed into the input string is incorrect");
            ErrorMessages.Add(ImportRelationshipRolesPrivilegeError, "{0} cannot be imported. The {1} privilege is required to import this component.");
            ErrorMessages.Add(ImportEntityNameMismatchError, "The number of format parameters passed into the input string is incorrect");
            ErrorMessages.Add(ImportFormXmlError, "The number of format parameters passed into the input string is incorrect");
            ErrorMessages.Add(ImportFieldXmlError, "The number of format parameters passed into the input string is incorrect");
            ErrorMessages.Add(ImportSavedQueryExistingError, "The number of format parameters passed into the input string is incorrect");
            ErrorMessages.Add(ImportSavedQueryOtcMismatchError, "There was an error processing saved queries of the same object type code (unresolvable system collision)");
            ErrorMessages.Add(ImportEntityCustomResourcesNewStringError, "Invalid Entity new string in the Custom Resources");
            ErrorMessages.Add(ImportEntityCustomResourcesError, "Invalid Custom Resources in the Import File");
            ErrorMessages.Add(ImportEntityIconError, "Invalid Icon in the Import File");
            ErrorMessages.Add(ImportSavedQueryDeletedError, "A saved query with the same id is marked as deleted in the system. Please first publish the customized entity and import again.");
            ErrorMessages.Add(ImportEntitySystemUserOnPremiseMismatchError, "The systemuser entity was imported, but customized forms for the entity were not imported. Systemuser entity forms from Microsoft Dynamics CRM Online cannot be imported into on-premises or hosted versions of Microsoft Dynamics CRM.");
            ErrorMessages.Add(ImportEntitySystemUserLiveMismatchError, "The systemuser entity was imported but customized forms for the entity were not imported. Systemuser entity forms from on-premises or hosted versions of Microsoft Dynamics CRM cannot be imported into Microsoft Dynamics CRM Online.");
            ErrorMessages.Add(ImportLanguagesIgnoredError, "Translated labels for the following languages could not be imported because they have not been enabled for this organization: {0}");
            ErrorMessages.Add(ImportInvalidFileError, "Invalid Import File");
            ErrorMessages.Add(ImportXsdValidationError, "The import file is invalid. XSD validation failed with the following error: '{0}'. The validation failed at: '...{1} <<<<<ERROR LOCATION>>>>> {2}...'.\"");
            ErrorMessages.Add(ImportInvalidXmlError, "This solution package cannot be imported because it contains invalid XML. You can attempt to repair the file by manually editing the XML contents using the information found in the schema validation errors, or you can contact your solution provider.");
            ErrorMessages.Add(ImportWrongPublisherError, "The following managed solution cannot be imported: {0}. The publisher name cannot be changed from {1} to {2}.");
            ErrorMessages.Add(ImportMissingDependenciesError, "The following solution cannot be imported: {0}. Some dependencies are missing.");
            ErrorMessages.Add(ImportGenericError, "The import failed. For more information, see the related error messages.");
            ErrorMessages.Add(ImportMissingComponent, "Cannot add a Root Component {0} of type {1} because it is not in the target system.");
            ErrorMessages.Add(ImportMissingRootComponentEntry, "The import has failed because component {0} of type {1} is not declared in the solution file as a root component. To fix this, import again using the XML file that was generated when you exported the solution.");
            ErrorMessages.Add(UnmanagedComponentParentsManagedComponent, "Found {0} dependency records where unmanaged component is the parent of a managed component. First record (dependentcomponentobjectid = {1}, type = {2}, requiredcomponentobjectid = {3}, type= {4}, solution = {5}).");
            ErrorMessages.Add(FailedToGetNetworkServiceName, "Failed to obtain the localized name for NetworkService account");
            ErrorMessages.Add(CustomParentingSystemNotSupported, "A custom entity can not have a parental relationship to a system entity");
            ErrorMessages.Add(InvalidFormatParameters, "The number of format parameters passed into the input string is incorrect");
            ErrorMessages.Add(ConfigurationPageNotValidForSolution, "The solution configuration page must exist within the solution it represents.");
            ErrorMessages.Add(SolutionConfigurationPageMustBeHtmlWebResource, "The solution configuration page must exist within the solution it represents.");
            ErrorMessages.Add(InvalidSolutionConfigurationPage, "The specified configuration page for this solution is invalid.");
            ErrorMessages.Add(InvalidLanguageForSolution, "Solution and Publisher Options are not available since your language does not match system base language.");
            ErrorMessages.Add(CannotHaveDuplicateYomi, "One attribute can be tied to only one yomi at a time");
            ErrorMessages.Add(SavedQueryIsNotCustomizable, "The specified view is not customizable");
            ErrorMessages.Add(CannotDeleteChildAttribute, "The Child Attribute is not valid for deletion");
            ErrorMessages.Add(EntityHasNoStateCode, "Specified entity does not have a statecode.");
            ErrorMessages.Add(NoAttributesForEntityCreate, "No attributes for Create Entity action.");
            ErrorMessages.Add(DuplicateAttributeSchemaName, "An attribute with the specified name already exists");
            ErrorMessages.Add(DuplicateDisplayCollectionName, "An object with the specified display collection name already exists.");
            ErrorMessages.Add(DuplicateDisplayName, "An object with the specified display name already exists.");
            ErrorMessages.Add(DuplicateName, "An object with the specified name already exists");
            ErrorMessages.Add(InvalidRelationshipType, "The specified relationship type is not valid for this operation");
            ErrorMessages.Add(InvalidPrimaryFieldType, "Primary UI Attribute has to be of type String");
            ErrorMessages.Add(InvalidOwnershipTypeMask, "The specified ownership type mask is not valid for this operation");
            ErrorMessages.Add(InvalidDisplayName, "The specified display name is not valid");
            ErrorMessages.Add(InvalidSchemaName, "An entity with the specified name already exists. Please specify a unique name.");
            ErrorMessages.Add(RelationshipIsNotCustomRelationship, "The specified relationship is not a custom relationship");
            ErrorMessages.Add(AttributeIsNotCustomAttribute, "The specified attribute is not a custom attribute");
            ErrorMessages.Add(EntityIsNotCustomizable, "The specified entity is not customizable");
            ErrorMessages.Add(MultipleParentsNotSupported, "An entity can have only one parental relationship");
            ErrorMessages.Add(CannotCreateActivityRelationship, "Relationship with activities cannot be created through this operation");
            ErrorMessages.Add(CyclicalRelationship, "The specified relationship will result in a cycle.");
            ErrorMessages.Add(InvalidRelationshipDescription, "The specified relationship cannot be created");
            ErrorMessages.Add(CannotDeletePrimaryUiAttribute, "The Primary UI Attribute is not valid for deletion");
            ErrorMessages.Add(RowGuidIsNotValidName, "rowguid is a reserved name and cannot be used as an identifier");
            ErrorMessages.Add(FailedToScheduleActivity, "Failed to schedule activity.");
            ErrorMessages.Add(CannotDeleteLastEmailAttribute, "You cannot delete this field because the record type has been enabled for e-mail.");
            ErrorMessages.Add(SystemAttributeMap, "SystemAttributeMap Error Occurred");
            ErrorMessages.Add(UpdateAttributeMap, "UpdateAttributeMap Error Occurred");
            ErrorMessages.Add(InvalidAttributeMap, "InvalidAttributeMap Error Occurred");
            ErrorMessages.Add(SystemEntityMap, "SystemEntityMap Error Occurred");
            ErrorMessages.Add(UpdateEntityMap, "UpdateEntityMap Error Occurred");
            ErrorMessages.Add(NonMappableEntity, "NonMappableEntity Error Occurred");
            ErrorMessages.Add(UnManagedidsCalloutException, "Callout code throws exception");
            ErrorMessages.Add(UnManagedidscalloutinvalidevent, "Invalid callout event");
            ErrorMessages.Add(UnManagedidscalloutinvalidconfig, "Invalid callout configuration");
            ErrorMessages.Add(UnManagedidscalloutisvstop, "Callout ISV code stopped the operation");
            ErrorMessages.Add(UnManagedidscalloutisvabort, "Callout ISV code aborted the operation");
            ErrorMessages.Add(UnManagedidscalloutisvexception, "Callout ISV code throws exception");
            ErrorMessages.Add(UnManagedidscustomentityambiguousrelationship, "More than one relationship between the requested entities exists.");
            ErrorMessages.Add(UnManagedidscustomentitynorelationship, "No relationship exists between the requested entities.");
            ErrorMessages.Add(UnManagedidscustomentityparentchildidentical, "The supplied parent and child entities are identical.");
            ErrorMessages.Add(UnManagedidscustomentityinvalidparent, "The supplied parent passed in is not a valid entity.");
            ErrorMessages.Add(UnManagedidscustomentityinvalidchild, "The supplied child passed in is not a valid entity.");
            ErrorMessages.Add(UnManagedidscustomentitywouldcreateloop, "This association would create a loop in the database.");
            ErrorMessages.Add(UnManagedidscustomentityexistingloop, "There is an existing loop in the database.");
            ErrorMessages.Add(UnManagedidscustomentitystackunderflow, "Custom entity MD stack underflow.");
            ErrorMessages.Add(UnManagedidscustomentitystackoverflow, "Custom entity MD stack overflow.");
            ErrorMessages.Add(UnManagedidscustomentitytlsfailure, "Custom entity MD TLS not initialized.");
            ErrorMessages.Add(UnManagedidscustomentityinvalidownership, "Custom entity ownership type mask is improperly set.");
            ErrorMessages.Add(UnManagedidscustomentitynotinitialized, "Custom entity interface was not properly initialized.");
            ErrorMessages.Add(UnManagedidscustomentityalreadyinitialized, "Custom entity interface already initialized on this thread.");
            ErrorMessages.Add(UnManagedidscustomentitynameviolation, "Supplied entity found, but it is not a custom entity.");
            ErrorMessages.Add(UnManagedidscascadeunexpectederror, "Unexpected error occurred in cascading operation");
            ErrorMessages.Add(UnManagedidscascadeemptylinkerror, "The relationship link is empty");
            ErrorMessages.Add(UnManagedidscascadeundefinedrelationerror, "Relationship type is not supported");
            ErrorMessages.Add(UnManagedidscascadeinconsistencyerror, "Cascade map information is inconsistent.");
            ErrorMessages.Add(MergeLossOfParentingWarning, "Merge warning: sub-entity might lose parenting");
            ErrorMessages.Add(MergeDifferentlyParentedWarning, "Merge warning: sub-entity will be differently parented.");
            ErrorMessages.Add(MergeEntitiesIdenticalError, "Merge cannot be performed on master and sub-entities that are identical.");
            ErrorMessages.Add(MergeEntityNotActiveError, "Merge cannot be performed on entity that is inactive.");
            ErrorMessages.Add(UnManagedidsmergedifferentbizorgerror, "Merge cannot be performed on entities from different business entity.");
            ErrorMessages.Add(MergeActiveQuoteError, "Merge cannot be performed on sub-entity that has active quote.");
            ErrorMessages.Add(MergeSecurityError, "Merge is not allowed: caller does not have the privilege or access.");
            ErrorMessages.Add(MergeCyclicalParentingError, "Merge could create cyclical parenting.");
            ErrorMessages.Add(UnManagedidscalendarruledoesnotexist, "The calendar rule does not exist.");
            ErrorMessages.Add(UnManagedidscalendarinvalidcalendar, "The calendar is invalid.");
            ErrorMessages.Add(AttachmentInvalidFileName, "Attachment file name contains invalid characters.");
            ErrorMessages.Add(UnManagedidsattachmentcannottruncatetempfile, "Cannot truncate temporary attachment file.");
            ErrorMessages.Add(UnManagedidsattachmentcannotunmaptempfile, "Cannot unmap temporary attachment file.");
            ErrorMessages.Add(UnManagedidsattachmentcannotcreatetempfile, "Cannot create temporary attachment file.");
            ErrorMessages.Add(UnManagedidsattachmentisempty, "Attachment is empty.");
            ErrorMessages.Add(UnManagedidsattachmentcannotreadtempfile, "Cannot read temporary attachment file.");
            ErrorMessages.Add(UnManagedidsattachmentinvalidfilesize, "Attachment file size is too big.");
            ErrorMessages.Add(UnManagedidsattachmentcannotgetfilesize, "Cannot get temporary attachment file size.");
            ErrorMessages.Add(UnManagedidsattachmentcannotopentempfile, "Cannot open temporary attachment file.");
            ErrorMessages.Add(UnManagedidscustomizationtransformationnotsupported, "Transformation is not supported for this object.");
            ErrorMessages.Add(ContractDetailDiscountAmountAndPercent, "Both 'amount' and 'percentage' cannot be set.");
            ErrorMessages.Add(ContractDetailDiscountAmount, "The contract's discount type does not support 'percentage' discounts.");
            ErrorMessages.Add(ContractDetailDiscountPercent, "The contract's discount type does not support 'amount' discounts.");
            ErrorMessages.Add(IncidentIsAlreadyClosedOrCancelled, "Already Closed or Canceled");
            ErrorMessages.Add(UnManagedidsincidentparentaccountandparentcontactnotpresent, "You should specify a parent contact or account.");
            ErrorMessages.Add(UnManagedidsincidentparentaccountandparentcontactpresent, "You can either specify a parent contact or account, but not both.");
            ErrorMessages.Add(IncidentCannotCancel, "The incident can not be cancelled because there are open activities for this incident.");
            ErrorMessages.Add(IncidentInvalidContractLineStateForCreate, "The case can not be created against this contract line item because the contract line item is cancelled or expired.");
            ErrorMessages.Add(IncidentNullSpentTimeOrBilled, "The timespent on the Incident is NULL or IncidentResolution Activity's IsBilled is NULL.");
            ErrorMessages.Add(IncidentInvalidAllotmentType, "The allotment type for the contract is invalid.");
            ErrorMessages.Add(UnManagedidsincidentcannotclose, "The incident can not be closed because there are open activities for this incident.");
            ErrorMessages.Add(IncidentMissingActivityRegardingObject, "The incident id is missing.");
            ErrorMessages.Add(UnManagedidsincidentmissingactivityobjecttype, "Missing object type code.");
            ErrorMessages.Add(UnManagedidsincidentnullactivitytypecode, "The activitytypecode can't be NULL.");
            ErrorMessages.Add(UnManagedidsincidentinvalidactivitytypecode, "The activitytypecode is wrong.");
            ErrorMessages.Add(UnManagedidsincidentassociatedactivitycorrupted, "The activity associated with this case is corrupted.");
            ErrorMessages.Add(UnManagedidsincidentinvalidstate, "Incident state is invalid.");
            ErrorMessages.Add(IncidentContractDoesNotHaveAllotments, "The contract does not have enough allotments. The case can not be created against this contract.");
            ErrorMessages.Add(UnManagedidsincidentcontractdetaildoesnotmatchcontract, "The contract line item is not in the specified contract.");
            ErrorMessages.Add(IncidentMissingContractDetail, "The contract detail id is missing.");
            ErrorMessages.Add(IncidentInvalidContractStateForCreate, "The case can not be created against this contract because of the contract state.");
            ErrorMessages.Add(DisabledCrmGoingOffline, "Microsoft Dynamics CRM functionality is not available while Offline Synchronization is occuring");
            ErrorMessages.Add(DisabledCrmGoingOnline, "Microsoft Dynamics CRM functionality is not available while Online Synchronization is occuring");
            ErrorMessages.Add(DisabledCrmAddinLoadFailure, "An error occurred loading Microsoft Dynamics CRM functionality. Try restarting Outlook. Contact your system administrator if errors persist.");
            ErrorMessages.Add(DisabledCrmClientVersionLower, "The Microsoft Dynamics CRM for Outlook needs to be upgraded before it can be used. Contact your system administrator for upgrade instructions.");
            ErrorMessages.Add(DisabledCrmClientVersionHigher, "The Microsoft Dynamics CRM server needs to be upgraded before Microsoft Dynamics CRM client can be used. Contact your system administrator for assistance.");
            ErrorMessages.Add(DisabledCrmPostOfflineUpgrade, "Microsoft Dynamics CRM functionality is not available until the Microsoft Dynamics CRM client is taken back online");
            ErrorMessages.Add(DisabledCrmOnlineCrmNotAvailable, "Microsoft Dynamics CRM server is not available");
            ErrorMessages.Add(GoOfflineMetadataVersionsMismatch, "Client and Server metadata versions are different due to new customization on the server. Please try going offline again.");
            ErrorMessages.Add(GoOfflineGetBcpFileException, "CRM server was not able to process your request. Contact your system administrator for assistance and try going offline again.");
            ErrorMessages.Add(GoOfflineDbSizeLimit, "You have exceeded the storage limit for your offline database. You must reduce the amount of data to be taken offline by changing your Local Data Groups.");
            ErrorMessages.Add(GoOfflineServerFailedGenerateBcpFile, "CRM server was not able to generate BCP file. Contact your system administrator for assistance and try going offline again.");
            ErrorMessages.Add(GoOfflineBcpFileSize, "Client was not able to download BCP file. Contact your system administrator for assistance and try going offline again.");
            ErrorMessages.Add(GoOfflineFailedMoveData, "Client was not able to download data. Contact your system administrator for assistance and try going offline again.");
            ErrorMessages.Add(GoOfflineFailedPrepareMsde, "Prepare MSDE failed. Contact your system administrator for assistance and try going offline again.");
            ErrorMessages.Add(GoOfflineFailedReloadMetadataCache, "The Microsoft Dynamics CRM for Outlook was unable to go offline. Please try going offline again.");
            ErrorMessages.Add(DoNotTrackItem, "Selected item will not be tracked.");
            ErrorMessages.Add(GoOfflineFileWasDeleted, "Data file was deleted on server before it was sent to client.");
            ErrorMessages.Add(GoOfflineEmptyFileForDelete, "Data file for delete is empty.");
            ErrorMessages.Add(OrganizationUiDeprecated, "The OrganizationUI entity is deprecated. It has been replaced by the SystemForm entity.");
            ErrorMessages.Add(UnManagedidssqltimeouterror, "SQL timeout expired.");
            ErrorMessages.Add(UnManagedidssqlerror, "Generic SQL error.");
            ErrorMessages.Add(UnManagedidsrcsyncinvalidfiltererror, "Invalid filter specified.");
            ErrorMessages.Add(UnManagedidsrcsyncnotprimary, "Cannot sync: not the primary OutlookSync client.");
            ErrorMessages.Add(UnManagedidsrcsyncnoprimary, "No primary client exists.");
            ErrorMessages.Add(UnManagedidsrcsyncnoclient, "Client does not exist.");
            ErrorMessages.Add(UnManagedidsrcsyncfilternoaccess, "Cannot go offline: missing access rights on required entity.");
            ErrorMessages.Add(InvalidOfflineOperation, "Operation not valid when offline.");
            ErrorMessages.Add(UnManagedidsrcsyncsqlgenericerror, "unManagedidsrcsyncsqlgenericerror");
            ErrorMessages.Add(UnManagedidsrcsyncsqlpausederror, "unManagedidsrcsyncsqlpausederror");
            ErrorMessages.Add(UnManagedidsrcsyncsqlstoppederror, "unManagedidsrcsyncsqlstoppederror");
            ErrorMessages.Add(UnManagedidsrcsyncsubscriptionowner, "The caller id does not match the subscription owner id.  Only subscription owners may perform subscription operations.");
            ErrorMessages.Add(UnManagedidsrcsyncinvalidsubscription, "The specified subscription does not exist.");
            ErrorMessages.Add(UnManagedidsrcsyncsoapparseerror, "unManagedidsrcsyncsoapparseerror");
            ErrorMessages.Add(UnManagedidsrcsyncsoapreaderror, "unManagedidsrcsyncsoapreaderror");
            ErrorMessages.Add(UnManagedidsrcsyncsoapfaulterror, "unManagedidsrcsyncsoapfaulterror");
            ErrorMessages.Add(UnManagedidsrcsyncsoapservererror, "unManagedidsrcsyncsoapservererror");
            ErrorMessages.Add(UnManagedidsrcsyncsoapsendfailed, "unManagedidsrcsyncsoapsendfailed");
            ErrorMessages.Add(UnManagedidsrcsyncsoapconnfailed, "unManagedidsrcsyncsoapconnfailed");
            ErrorMessages.Add(UnManagedidsrcsyncsoapgenfailed, "unManagedidsrcsyncsoapgenfailed");
            ErrorMessages.Add(UnManagedidsrcsyncmsxmlfailed, "unManagedidsrcsyncmsxmlfailed");
            ErrorMessages.Add(UnManagedidsrcsyncinvalidsynctime, "The specified sync time is invalid.  Sync times must not be earlier than those returned by the previous sync.  Please reinitialize your subscription.");
            ErrorMessages.Add(AttachmentBlocked, "The attachment is either not a valid type or is too large. It cannot be uploaded or downloaded.");
            ErrorMessages.Add(UnManagedidsarticletemplateisnotactive, "KB article template is inactive.");
            ErrorMessages.Add(UnManagedidsfulltextoperationfailed, "Full text operation failed.");
            ErrorMessages.Add(UnManagedidsarticletemplatecontainsarticles, "Cannot change article template because there are knowledge base articles using it.");
            ErrorMessages.Add(UnManagedidsqueueorganizationidnotmatch, "Callers' organization Id does not match businessunit's organization Id.");
            ErrorMessages.Add(UnManagedidsqueuemissingbusinessunitid, "Missing businessunitid.");
            ErrorMessages.Add(SubjectDoesNotExist, "Subject does not exist.");
            ErrorMessages.Add(SubjectLoopBeingCreated, "Creating this parental association would create a loop in Subjects hierarchy.");
            ErrorMessages.Add(SubjectLoopExists, "Loop exists in the subjects hierarchy.");
            ErrorMessages.Add(InvalidSubmitFromUnapprovedArticle, "You are trying to submit an article that has a status of unapproved. You can only submit an article with the status of draft.");
            ErrorMessages.Add(InvalidUnpublishFromUnapprovedArticle, "You are trying to unpublish an article that has a status of unapproved. You can only unpublish an article with the status of publish.");
            ErrorMessages.Add(InvalidApproveFromDraftArticle, "You are trying to approve an article that has a status of draft. You can only approve an article with the status of unapproved.");
            ErrorMessages.Add(InvalidUnpublishFromDraftArticle, "You are trying to unpublish an article that has a status of draft. You can only unpublish an article with the status of published.");
            ErrorMessages.Add(InvalidApproveFromPublishedArticle, "You are trying to approve an article that has a status of published. You can only approve an article with the status of unapproved.");
            ErrorMessages.Add(InvalidSubmitFromPublishedArticle, "You are trying to submit an article that has a status of published. You can only submit an article with the status of draft.");
            ErrorMessages.Add(QuoteReviseExistingActiveQuote, "Quote cannot be revised as there already exists another quote in Draft/Active state and with same quote number.");
            ErrorMessages.Add(BaseCurrencyNotDeletable, "The base currency of an organization cannot be deleted.");
            ErrorMessages.Add(CannotDeleteBaseMoneyCalculationAttribute, "The base money calculation Attribute is not valid for deletion");
            ErrorMessages.Add(InvalidExchangeRate, "The exchange rate is invalid.");
            ErrorMessages.Add(InvalidCurrency, "The currency is invalid.");
            ErrorMessages.Add(CurrencyCannotBeNullDueToNonNullMoneyFields, "The currency cannot be null.");
            ErrorMessages.Add(CannotUpdateProductCurrency, "The currency of the product cannot be updated because there are associated price list items with pricing method percentage.");
            ErrorMessages.Add(InvalidPriceLevelCurrencyForPricingMethod, "The currency of the price list needs to match the currency of the product for pricing method percentage.");
            ErrorMessages.Add(DiscountTypeAndPriceLevelCurrencyNotEqual, "The currency of the discount needs to match the currency of the price list for discount type amount.");
            ErrorMessages.Add(CurrencyRequiredForDiscountTypeAmount, "The currency cannot be null for discount type amount.");
            ErrorMessages.Add(RecordAndPricelistCurrencyNotEqual, "The currency of the record does not match the currency of the price list.");
            ErrorMessages.Add(ExchangeRateOfBaseCurrencyNotUpdatable, "The exchange rate of the base currency cannot be modified.");
            ErrorMessages.Add(BaseCurrencyCannotBeDeactivated, "The base currency cannot be deactivated.");
            ErrorMessages.Add(DuplicateIsoCurrencyCode, "Cannot insert duplicate currency record. Currency with the same currency code already exist in the system.");
            ErrorMessages.Add(InvalidIsoCurrencyCode, "Invalid ISO currency code.");
            ErrorMessages.Add(PercentageDiscountCannotHaveCurrency, "Currency cannot be set when discount type is percentage.");
            ErrorMessages.Add(RecordAndOpportunityCurrencyNotEqual, "The currency of the record does not match the currency of the price list.");
            ErrorMessages.Add(QuoteAndSalesOrderCurrencyNotEqual, "The currency of the record does not match the currency of the price list.");
            ErrorMessages.Add(SalesOrderAndInvoiceCurrencyNotEqual, "The currency of the record does not match the currency of the price list.");
            ErrorMessages.Add(BaseCurrencyOverflow, "The exchange rate set for the currency specified in this record has generated a value for {0} that is larger than the maximum allowed for the base currency ({1}).");
            ErrorMessages.Add(BaseCurrencyUnderflow, "The exchange rate set for the currency specified in this record has generated a value for {0} that is smaller than the minimum allowed for the base currency ({1}).");
            ErrorMessages.Add(CurrencyNotEqual, "The currency of the {0} does not match the currency of the {1}.");
            ErrorMessages.Add(UnitNoName, "The unit name cannot be null.");
            ErrorMessages.Add(UnManagedidsinvoicecloseapideprecated, "The Invoice Close API is deprecated. It has been replaced by the Pay and Cancel APIs.");
            ErrorMessages.Add(ProductDoesNotExist, "The product does not exist.");
            ErrorMessages.Add(ProductKitLoopBeingCreated, "Using this product would create a loop in the kit hierarchy.");
            ErrorMessages.Add(ProductKitLoopExists, "Loop exists in the kit hierarchy.");
            ErrorMessages.Add(DiscountPercent, "The discount type does not support 'amount' discounts.");
            ErrorMessages.Add(DiscountAmount, "The discount type does not support 'percentage' discounts.");
            ErrorMessages.Add(DiscountAmountAndPercent, "Both 'amount' and 'percentage' cannot be set.");
            ErrorMessages.Add(EntityIsUnlocked, "This entity is already unlocked.");
            ErrorMessages.Add(EntityIsLocked, "This entity is already locked.");
            ErrorMessages.Add(BaseUnitDoesNotExist, "The base unit does not exist.");
            ErrorMessages.Add(UnitDoesNotExist, "The unit does not exist.");
            ErrorMessages.Add(UnitLoopBeingCreated, "Using this base unit would create a loop in the unit hierarchy.");
            ErrorMessages.Add(UnitLoopExists, "Loop exists in the unit hierarchy.");
            ErrorMessages.Add(QuantityReadonly, "Do not modify the Quantity field when you update the primary unit.");
            ErrorMessages.Add(BaseUnitNotNull, "Do not use a base unit as the value for a primary unit. This value should always be null.");
            ErrorMessages.Add(UnitNotInSchedule, "The unit does not exist in the specified unit schedule.");
            ErrorMessages.Add(MissingOpportunityId, "The opportunity id is missing or invalid.");
            ErrorMessages.Add(ProductInvalidUnit, "The specified unit is not valid for this product.");
            ErrorMessages.Add(ProductMissingUomSheduleId, "The unit schedule id of the product is missing.");
            ErrorMessages.Add(MissingPriceLevelId, "The price level id is missing.");
            ErrorMessages.Add(MissingProductId, "The product id is missing.");
            ErrorMessages.Add(InvalidPricePerUnit, "The price per unit is invalid.");
            ErrorMessages.Add(PriceLevelNameExists, "The name already exists.");
            ErrorMessages.Add(PriceLevelNoName, "The name can not be null.");
            ErrorMessages.Add(MissingUomId, "The unit id is missing.");
            ErrorMessages.Add(ProductInvalidPriceLevelPercentage, "The pricing percentage must be greater than or equal to zero and less than 100000.");
            ErrorMessages.Add(InvalidBaseUnit, "The base unit does not belong to the schedule.");
            ErrorMessages.Add(MissingUomScheduleId, "The unit schedule id is missing.");
            ErrorMessages.Add(ParentReadOnly, "The parent is read only and cannot be edited.");
            ErrorMessages.Add(DuplicateProductPriceLevel, "This product and unit combination has a price for this price list.");
            ErrorMessages.Add(ProductInvalidQuantityDecimal, "The number of decimal places on the quantity is invalid.");
            ErrorMessages.Add(ProductProductNumberExists, "The product number already exists.");
            ErrorMessages.Add(ProductNoProductNumber, "The product number can not be null.");
            ErrorMessages.Add(UnManagedidscannotdeactivatepricelevel, "The price level cannot be deactivated because it is the default price level of an account, contact or product.");
            ErrorMessages.Add(BaseUnitNotDeletable, "The base unit of a schedule cannot be deleted.");
            ErrorMessages.Add(DiscountRangeOverlap, "The new quantities overlap the range covered by existing quantities.");
            ErrorMessages.Add(LowQuantityGreaterThanHighQuantity, "Low quantity should be less than high quantity.");
            ErrorMessages.Add(LowQuantityLessThanZero, "Low quantity should be greater than zero.");
            ErrorMessages.Add(InvalidSubstituteProduct, "A product cannot be a substitute of itself.");
            ErrorMessages.Add(InvalidKitProduct, "The product cannot be added to itself.");
            ErrorMessages.Add(InvalidKit, "The product is not a kit.");
            ErrorMessages.Add(InvalidQuantityDecimalCode, "The quantity decimal code is invalid.");
            ErrorMessages.Add(CannotSpecifyBothProductAndProductDesc, "You cannot set both 'productid' and 'productdescription' for the same record.");
            ErrorMessages.Add(CannotSpecifyBothUomAndProductDesc, "You cannot set both 'uomid' and 'productdescription' for the same record.");
            ErrorMessages.Add(UnManagedidsstatedoesnotexist, "The state is not valid for this object.");
            ErrorMessages.Add(FiscalSettingsAlreadyUpdated, "Fiscal settings have already been updated. They can be updated only once.");
            ErrorMessages.Add(UnManagedidssalespeopleinvalidfiscalcalendartype, "Invalid fiscal calendar type");
            ErrorMessages.Add(UnManagedidssalespeopleinvalidfiscalperiodindex, "Invalid fiscal period index");
            ErrorMessages.Add(SalesPeopleManagerNotAllowed, "Territory manager cannot belong to other territory");
            ErrorMessages.Add(UnManagedidssalespeopleinvalidterritoryobjecttype, "Territories cannot be retrieved by this kind of object");
            ErrorMessages.Add(SalesPeopleDuplicateCalendarNotAllowed, "Fiscal calendar already exists for this salesperson/year");
            ErrorMessages.Add(UnManagedidssalespeopleduplicatecalendarfound, "Duplicate fiscal calendars found for this salesperson/year");
            ErrorMessages.Add(SalesPeopleEmptyEffectiveDate, "Fiscal calendar effective date cannot be empty");
            ErrorMessages.Add(SalesPeopleEmptySalesPerson, "Parent salesperson cannot be empty");
            ErrorMessages.Add(InvalidNumberGroupFormat, "Invalid input string for numbergroupformat. The input string should contain an array of integers. Every element in the value array should be between one and nine, except for the last element, which can be zero.");
            ErrorMessages.Add(BaseUomNameNotSpecified, "baseuomname not specified");
            ErrorMessages.Add(FaxNoSupport, "The fax cannot be sent because this type of attachment is not allowed or does not support virtual printing to a fax device.");
            ErrorMessages.Add(FaxNoData, "The fax cannot be sent because there is no data to send. Specify at least one of the following: a cover page, a fax attachment, a fax description.");
            ErrorMessages.Add(InvalidPartyMapping, "Invalid party mapping.");
            ErrorMessages.Add(InvalidActivityXml, "Invalid Xml in an activity config file.");
            ErrorMessages.Add(ActivityInvalidObjectTypeCode, "An Invalid type code was specified by the throwing method");
            ErrorMessages.Add(ActivityInvalidSessionToken, "An Invalid session token was passed into the throwing method");
            ErrorMessages.Add(FaxServiceNotRunning, "The Microsoft Windows fax service is not running or is not installed.");
            ErrorMessages.Add(FaxSendBlocked, "The recipient is marked as \"Do Not Fax\".");
            ErrorMessages.Add(NoDialNumber, "There is no fax number specified on the fax or for the recipient.");
            ErrorMessages.Add(TooManyRecipients, "Sending to multiple recipients is not supported.");
            ErrorMessages.Add(MissingRecipient, "The fax must have a recipient before it can be sent.");
            ErrorMessages.Add(UnManagedidsactivitynotroutable, "This type of activity is not routable");
            ErrorMessages.Add(UnManagedidsactivitydurationdoesnotmatch, "Activity duration does not match start/end time");
            ErrorMessages.Add(UnManagedidsactivityinvalidduration, "Invalid activity duration");
            ErrorMessages.Add(UnManagedidsactivityinvalidtimeformat, "Invalid activity time, check format");
            ErrorMessages.Add(UnManagedidsactivityinvalidregardingobject, "Invalid activity regarding object, it probably does not exist");
            ErrorMessages.Add(ActivityPartyObjectTypeNotAllowed, "Cannot create activity party of specified object type.");
            ErrorMessages.Add(UnManagedidsactivityinvalidpartyobjecttype, "Activity party object type is invalid");
            ErrorMessages.Add(UnManagedidsactivitypartyobjectidortypemissing, "Activity party object Id or type is missing");
            ErrorMessages.Add(UnManagedidsactivityinvalidobjecttype, "Activity regarding object type is invalid");
            ErrorMessages.Add(UnManagedidsactivityobjectidortypemissing, "Activity regarding object Id or type is missing");
            ErrorMessages.Add(UnManagedidsactivityinvalidtype, "Invalid activity type code");
            ErrorMessages.Add(UnManagedidsactivityinvalidstate, "Invalid activity state");
            ErrorMessages.Add(ContractInvalidDatesForRenew, "The start date / end date of this renewed contract can not overlap with any other invoiced / active contracts with the same contract number.");
            ErrorMessages.Add(UnManagedidscontractinvalidstartdateforrenewedcontract, "The start date of the renewed contract can not be earlier than the end date of the originating contract.");
            ErrorMessages.Add(UnManagedidscontracttemplateabbreviationexists, "The value for abbreviation already exists.");
            ErrorMessages.Add(ContractInvalidPrice, "The price is invalid.");
            ErrorMessages.Add(UnManagedidscontractinvalidtotalallotments, "The totalallotments is invalid.");
            ErrorMessages.Add(ContractInvalidContract, "The contract is invalid.");
            ErrorMessages.Add(UnManagedidscontractinvalidowner, "The owner of the contract is invalid.");
            ErrorMessages.Add(ContractInvalidContractTemplate, "The contract template is invalid.");
            ErrorMessages.Add(ContractInvalidBillToCustomer, "The bill-to customer of the contract is invalid.");
            ErrorMessages.Add(ContractInvalidBillToAddress, "The bill-to address of the contract is invalid.");
            ErrorMessages.Add(ContractInvalidServiceAddress, "The service address of the contract is invalid.");
            ErrorMessages.Add(ContractInvalidCustomer, "The customer of the contract is invalid.");
            ErrorMessages.Add(ContractNoLineItems, "There are no contract line items for this contract.");
            ErrorMessages.Add(ContractTemplateNoAbbreviation, "Abbreviation can not be NULL.");
            ErrorMessages.Add(UnManagedidscontractopencasesexist, "There are open cases against this contract line item.");
            ErrorMessages.Add(UnManagedidscontractlineitemdoesnotexist, "The contract line item does not exist.");
            ErrorMessages.Add(UnManagedidscontractdoesnotexist, "The contract does not exist.");
            ErrorMessages.Add(ContractTemplateDoesNotExist, "The contract template does not exist.");
            ErrorMessages.Add(ContractInvalidAllotmentTypeCode, "The allotment type code is invalid.");
            ErrorMessages.Add(ContractLineInvalidState, "The state of the contract line item is invalid.");
            ErrorMessages.Add(ContractInvalidState, "The state of the contract is invalid.");
            ErrorMessages.Add(ContractInvalidStartEndDate, "Start date / end date or billing start date / billing end date is invalid.");
            ErrorMessages.Add(UnManagedidscontractaccountmissing, "Account is required to save a contract.");
            ErrorMessages.Add(UnManagedidscontractunexpected, "An unexpected error occurred in Contracts.");
            ErrorMessages.Add(UnManagedidsevalerrorformatlookupparameter, "Error happens when evaluating WFPM_FORMAT_LOOKUP parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorformattimezonecodeparameter, "unManagedidsevalerrorformattimezonecodeparameter");
            ErrorMessages.Add(UnManagedidsevalerrorformatdecimalparameter, "Error happens when evaluating WFPM_FORMAT_DECIMAL parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorformatintegerparameter, "Error happens when evaluating WFPM_FORMAT_INTEGER parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorobjecttype, "Error happens when evaluating WFPM_GetObjectType parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorqueueidparameter, "unManagedidsevalerrorqueueidparameter");
            ErrorMessages.Add(UnManagedidsevalerrorformatpicklistparameter, "Error happens when evaluating WFPM_FORMAT_PICKLIST parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorformatbooleanparameter, "Error happens when evaluating WFPM_FORMAT_BOOLEAN parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorformatdatetimeparameter, "Error happens when evaluating WFPM_FORMAT_DATETIME parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorisnulllistparameter, "unManagedidsevalerrorisnulllistparameter");
            ErrorMessages.Add(UnManagedidsevalerrorinlistparameter, "unManagedidsevalerrorinlistparameter");
            ErrorMessages.Add(UnManagedidsevalerrorsetactivityparty, "unManagedidsevalerrorsetactivityparty");
            ErrorMessages.Add(UnManagedidsevalerrorremovefromactivityparty, "unManagedidsevalerrorremovefromactivityparty");
            ErrorMessages.Add(UnManagedidsevalerrorappendtoactivityparty, "unManagedidsevalerrorappendtoactivityparty");
            ErrorMessages.Add(UnManagedidsevaltimererrorcalculatescheduletime, "Failed to calculate the schedule time for the timer action.");
            ErrorMessages.Add(UnManagedidsevaltimerinvalidparameternumber, "Invalid parameters for Timer action.");
            ErrorMessages.Add(UnManagedidsevalcreateshouldhave2Parameters, "Create action should have 2 parameters.");
            ErrorMessages.Add(UnManagedidsevalerrorcreate, "Error in create update.");
            ErrorMessages.Add(UnManagedidsevalerrorcontainparameter, "Error occurred when evaluating a WFPM_CONTAIN parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorendwithparameter, "Error occurred when evaluating a WFPM_END_WITH parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorbeginwithparameter, "Error occurred when evaluating a WFPM_BEGIN_WITH parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorstrlenparameter, "Error occurred when evaluating a WFPM_STRLEN parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorsubstrparameter, "Error occurred when evaluating a WFPM_SUBSTR parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorinvalidrecipient, "Invalid email recipient.");
            ErrorMessages.Add(UnManagedidsevalerrorinparameter, "Error occurred when evaluating a WFPM_IN parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorbetweenparameter, "Error occurred when evaluating a WFPM_BETWEEN parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorneqparameter, "Error occurred when evaluating a WFPM_NEQ parameter.");
            ErrorMessages.Add(UnManagedidsevalerroreqparameter, "Error occurred when evaluating a WFPM_EQ parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorleqparameter, "Error occurred when evaluating a WFPM_LEQ parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorltparameter, "Error occurred when evaluating a WFPM_LT parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorgeqparameter, "Error occurred when evaluating a WFPM_GEQ parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorgtparameter, "Error occurred when evaluating a WFPM_GT parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorabsparameter, "Error occurred when evaluating a WFPM_ABS parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorinvalidparameter, "Invalid parameter.");
            ErrorMessages.Add(UnManagedidsevalgenericerror, "Evaluation error.");
            ErrorMessages.Add(UnManagedidsevalerrorincidentqueue, "Failed to evaluate INCIDENT_QUEUE.");
            ErrorMessages.Add(UnManagedidsevalerrorhalt, "Error in action halt.");
            ErrorMessages.Add(UnManagedidsevalerrorexec, "Error in action exec.");
            ErrorMessages.Add(UnManagedidsevalerrorposturl, "Error in action posturl.");
            ErrorMessages.Add(UnManagedidsevalerrorsetstate, "Error in action set state.");
            ErrorMessages.Add(UnManagedidsevalerrorroute, "Error in action route.");
            ErrorMessages.Add(UnManagedidsevalerrorupdate, "Error in action update.");
            ErrorMessages.Add(UnManagedidsevalerrorassign, "Error in action assign.");
            ErrorMessages.Add(UnManagedidsevalerroremailtemplate, "Error in action email template.");
            ErrorMessages.Add(UnManagedidsevalerrorsendemail, "Error in action send email.");
            ErrorMessages.Add(UnManagedidsevalerrorunhandleincident, "Error in action unhandle incident.");
            ErrorMessages.Add(UnManagedidsevalerrorhandleincident, "Error in action handle incident.");
            ErrorMessages.Add(UnManagedidsevalerrorcreateincident, "Error in action create incident.");
            ErrorMessages.Add(UnManagedidsevalerrornoteattachment, "Error in action note attachment.");
            ErrorMessages.Add(UnManagedidsevalerrorcreatenote, "Error in action create note.");
            ErrorMessages.Add(UnManagedidsevalerrorunhandleactivity, "Error in action unhandle activity.");
            ErrorMessages.Add(UnManagedidsevalerrorhandleactivity, "Error in action handle activity.");
            ErrorMessages.Add(UnManagedidsevalerroractivityattachment, "Error in action activity attachment.");
            ErrorMessages.Add(UnManagedidsevalerrorcreateactivity, "Error in action create activity.");
            ErrorMessages.Add(UnManagedidsevalerrordividedbyzero, "Divided by zero.");
            ErrorMessages.Add(UnManagedidsevalerrormodulusparameter, "Error occurred when evaluating a WFPM_MODULUR parameter.");
            ErrorMessages.Add(UnManagedidsevalerrormodulusparameters, "Modulus parameter can have only two subparameters.");
            ErrorMessages.Add(UnManagedidsevalerrordivisionparameter, "Error occurred when evaluating a WFPM_DIVISION parameter.");
            ErrorMessages.Add(UnManagedidsevalerrordivisionparameters, "Division parameter can have only two subparameters.");
            ErrorMessages.Add(UnManagedidsevalerrormultiplicationparameter, "Error occurred when evaluating a WFPM_MULTIPLICATION parameter.");
            ErrorMessages.Add(UnManagedidsevalerrorsubtractionparameter, "Error occurred when evaluating a WFPM_SUBTRACTION parameter.");
            ErrorMessages.Add(UnManagedidsevalerroraddparameter, "Error occurred when evaluating a WFPM_ADD parameter.");
            ErrorMessages.Add(UnManagedidsevalmissselectquery, "Missing the query subparameter in a select parameter.");
            ErrorMessages.Add(UnManagedidsevalchangetypeerror, "Change type error.");
            ErrorMessages.Add(UnManagedidsevalallcompleted, "Evaluation completed and stop further processing.");
            ErrorMessages.Add(UnManagedidsevalmetabaseattributenotmatchquery, "The specified refattributeid does not the query for a WFPM_SELECT parameter.");
            ErrorMessages.Add(UnManagedidsevalmetabaseentitynotmatchquery, "The specified refentityid does not the query for a WFPM_SELECT parameter.");
            ErrorMessages.Add(UnManagedidsevalpropertyisnull, "The required property of the object was not set.");
            ErrorMessages.Add(UnManagedidsevalmetabaseattributenotfound, "The specified metabase attribute does not exist.");
            ErrorMessages.Add(UnManagedidsevalmetabaseentitycompoundkeys, "The specified metabase object has compound keys. We do not support compound-key entities yet.");
            ErrorMessages.Add(UnManagedidsevalpropertynotfound, "The required property of the object was not found.");
            ErrorMessages.Add(UnManagedidsevalobjectnotfound, "The required object does not exist.");
            ErrorMessages.Add(UnManagedidsevalcompleted, "Evaluation completed.");
            ErrorMessages.Add(UnManagedidsevalaborted, "Evaluation aborted.");
            ErrorMessages.Add(UnManagedidsevalallaborted, "Evaluation aborted and stop further processing.");
            ErrorMessages.Add(UnManagedidsevalassignshouldhave4Parameters, "Assign action should have 4 parameters.");
            ErrorMessages.Add(UnManagedidsevalupdateshouldhave3Parameters, "Update action should have 3 parameters.");
            ErrorMessages.Add(UnManagedidscpdecryptfailed, "Decryption of the password failed.");
            ErrorMessages.Add(UnManagedidscpencryptfailed, "Encryption of the supplied password failed.");
            ErrorMessages.Add(UnManagedidscpbadpassword, "Incorrect password for the specified customer portal user.");
            ErrorMessages.Add(UnManagedidscpuserdoesnotexist, "The customer portal user does not exist, or the password was incorrect.");
            ErrorMessages.Add(UnManagedidsdataaccessunexpected, "Unexpected error in data access.  DB Connection may not have been opened successfully.");
            ErrorMessages.Add(UnManagedidspropbagattributealreadyset, "One of the attributes passed has already been set");
            ErrorMessages.Add(UnManagedidspropbagattributenotnullable, "One of the attributes passed cannot be NULL");
            ErrorMessages.Add(UnManagedidsrspropbagdbinfoalreadyset, "The DB info for the recordset property bag has already been set.");
            ErrorMessages.Add(UnManagedidsrspropbagdbinfonotset, "The DB info for the recordset property bag has not been set.");
            ErrorMessages.Add(UnManagedidspropbagcolloutofrange, "The bag index in the collection was out of range.");
            ErrorMessages.Add(UnManagedidspropbagnullproperty, "The specified property was null in the property bag.");
            ErrorMessages.Add(UnManagedidspropbagnointerface, "The property bag interface could not be found.");
            ErrorMessages.Add(UnManagedMissingObjectType, "Object type must be specified for one of the attributes.");
            ErrorMessages.Add(UnManagedObjectTypeUnexpected, "Object type was specified for one of the attributes that does not allow it.");
            ErrorMessages.Add(BusinessUnitCannotBeDisabled, "Business unit cannot be disabled: no active user with system admin role exists outside of business unit subtree.");
            ErrorMessages.Add(BusinessUnitIsNotDisabledAndCannotBeDeleted, "Not disabled business unit cannot be deleted.");
            ErrorMessages.Add(BusinessUnitHasChildAndCannotBeDeleted, "Business unit has a child business unit and cannot be deleted.");
            ErrorMessages.Add(BusinessUnitDefaultTeamOwnsRecords, "Business unit default team owns records. Business unit cannot be deleted.");
            ErrorMessages.Add(RootBusinessUnitCannotBeDisabled, "Root Business unit cannot be disabled.");
            ErrorMessages.Add(UnManagedidspropbagpropertynotfound, "The specified property was not found in the property bag.");
            ErrorMessages.Add(ReadOnlyUserNotSupported, "The read-only access mode is not supported");
            ErrorMessages.Add(SupportUserCannotBeCreateNorUpdated, "The support user cannot not be updated");
            ErrorMessages.Add(CannotAssignRolesToSupportUser, "The support user are read-only, which cannot be assigned with other roles");
            ErrorMessages.Add(CannotMakeSelfReadOnlyUser, "You cannot make yourself a read only user");
            ErrorMessages.Add(CannotMakeReadOnlyUser, "A user cannot be made a read only user if they are the last non read only user that has the System Administrator Role.");
            ErrorMessages.Add(UnManagedidsbizmgmtcantchangeorgname, "The organization name cannot be changed.");
            ErrorMessages.Add(MultipleOrganizationsNotAllowed, "Only one organization and one root business are allowed.");
            ErrorMessages.Add(UserSettingsInvalidAdvancedFindStartupMode, "Invalid advanced find startup mode.");
            ErrorMessages.Add(CannotModifySpecialUser, "No modifications to the 'SYSTEM' or 'INTEGRATION' user are permitted.");
            ErrorMessages.Add(UnManagedidsbizmgmtcannotaddlocaluser, "A local user cannot be added to the CRM.");
            ErrorMessages.Add(CannotModifySysAdmin, "The System Administrator Role cannot be modified.");
            ErrorMessages.Add(CannotModifySupportUser, "The Support User Role cannot be modified.");
            ErrorMessages.Add(CannotAssignSupportUser, "The Support User Role cannot be assigned to a user.");
            ErrorMessages.Add(CannotRemoveFromSupportUser, "A user cannot be removed from the Support User Role.");
            ErrorMessages.Add(CannotCreateFromSupportUser, "Cannot create a role from Support User Role.");
            ErrorMessages.Add(CannotUpdateSupportUser, "Cannot update the Support User Role.");
            ErrorMessages.Add(CannotRemoveFromSysAdmin, "A user cannot be removed from the System Administrator Role if they are the only user that has the role.");
            ErrorMessages.Add(CannotDisableSysAdmin, "A user cannot be disabled if they are the only user that has the System Administrator Role.");
            ErrorMessages.Add(CannotDeleteSysAdmin, "The System Administrator Role cannot be deleted.");
            ErrorMessages.Add(CannotDeleteSupportUser, "The Support User Role cannot be deleted.");
            ErrorMessages.Add(CannotDeleteSystemCustomizer, "The System Customizer Role cannot be deleted.");
            ErrorMessages.Add(UnManagedidsbizmgmtcannotreadaccountcontrol, "Insufficient permissions to the specified Active Directory user. Contact your System Administrator.");
            ErrorMessages.Add(UserAlreadyExists, "The specified Active Directory user already exists as a CRM user.");
            ErrorMessages.Add(UnManagedidsbizmgmtusersettingsnotcreated, "The specified user's settings have not yet been created.");
            ErrorMessages.Add(ObjectNotFoundInAd, "The object does not exist in active directory.");
            ErrorMessages.Add(GenericActiveDirectoryError, "Active Directory Error.");
            ErrorMessages.Add(UnManagedidsbizmgmtnoparentbusiness, "The specified business does not have a parent business.");
            ErrorMessages.Add(ParentUserDoesNotExist, "The parent user Id is invalid.");
            ErrorMessages.Add(ChildUserDoesNotExist, "The child user Id is invalid.");
            ErrorMessages.Add(UserLoopBeingCreated, "You cannot set the selected user as the manager for this user because the selected user is either already the manager or is in the user's immediate management hierarchy.  Either select another user to be the manager or do not update the record.");
            ErrorMessages.Add(UserLoopExists, "A manager for this user cannot be set because an existing relationship in the management hierarchy is causing a circular relationship.  This is usually caused by a manual edit of the Microsoft Dynamics CRM database. To fix this, the hierarchy in the database must be changed to remove the circular relationship.");
            ErrorMessages.Add(ParentBusinessDoesNotExist, "The parent business Id is invalid.");
            ErrorMessages.Add(ChildBusinessDoesNotExist, "The child businesss Id is invalid.");
            ErrorMessages.Add(BusinessManagementLoopBeingCreated, "Creating this parental association would create a loop in business hierarchy.");
            ErrorMessages.Add(BusinessManagementLoopExists, "Loop exists in the business hierarchy.");
            ErrorMessages.Add(BusinessManagementInvalidUserId, "The user Id is invalid.");
            ErrorMessages.Add(UnManagedidsbizmgmtuserdoesnothaveparent, "This user does not have a parent user.");
            ErrorMessages.Add(UnManagedidsbizmgmtcannotenableprovision, "This is a provisioned root-business. Use IBizProvision::Enable to enable this root-business.");
            ErrorMessages.Add(UnManagedidsbizmgmtcannotenablebusiness, "This is a sub-business. Use IBizMerchant::Enable to enable this sub-business.");
            ErrorMessages.Add(UnManagedidsbizmgmtcannotdisableprovision, "This is a provisioned root-business. Use IBizProvision::Disable to disable this root-business.");
            ErrorMessages.Add(UnManagedidsbizmgmtcannotdisablebusiness, "This business unit cannot be disabled.");
            ErrorMessages.Add(UnManagedidsbizmgmtcannotdeleteprovision, "This is a provisioned root-business. Use IBizProvision::Delete to delete this root-business.");
            ErrorMessages.Add(UnManagedidsbizmgmtcannotdeletebusiness, "This is a sub-business. Use IBizMerchant::Delete to delete this sub-business.");
            ErrorMessages.Add(UnManagedidsbizmgmtcannotremovepartnershipdefaultuser, "The default user of a partnership can not be removed.");
            ErrorMessages.Add(UnManagedidsbizmgmtpartnershipnotinpendingstatus, "The partnership has been accepted or declined.");
            ErrorMessages.Add(UnManagedidsbizmgmtdefaultusernotinpartnerbusiness, "The default user is not from partner business.");
            ErrorMessages.Add(UnManagedidsbizmgmtcallernotinpartnerbusiness, "The caller is not from partner business.");
            ErrorMessages.Add(UnManagedidsbizmgmtdefaultusernotinprimarybusiness, "The default user is not from primary business.");
            ErrorMessages.Add(UnManagedidsbizmgmtcallernotinprimarybusiness, "The caller is not from primary business.");
            ErrorMessages.Add(UnManagedidsbizmgmtpartnershipalreadyexists, "A partnership between specified primary business and partner business already exists.");
            ErrorMessages.Add(UnManagedidsbizmgmtprimarysameaspartner, "The primary business is the same as partner business.");
            ErrorMessages.Add(UnManagedidsbizmgmtmisspartnerbusiness, "The partnership partner business was unexpectedly missing.");
            ErrorMessages.Add(UnManagedidsbizmgmtmissprimarybusiness, "The partnership primary business was unexpectedly missing.");
            ErrorMessages.Add(MissingTeamName, "The team name was unexpectedly missing.");
            ErrorMessages.Add(TeamAdministratorMissedPrivilege, "The team administrator does not have privilege read team.");
            ErrorMessages.Add(UserNotInParentHierarchy, "The user is not in parent user's business hierarchy.");
            ErrorMessages.Add(UnManagedidsbizmgmtusercannotbeownparent, "The user can not be its own parent user.");
            ErrorMessages.Add(UnManagedidsbizmgmtcannotmovedefaultuser, "unManagedidsbizmgmtcannotmovedefaultuser");
            ErrorMessages.Add(UnManagedidsbizmgmtbusinessparentdiffmerchant, "The business is not in the same merchant as parent business.");
            ErrorMessages.Add(UnManagedidsbizmgmtdefaultusernotinbusiness, "The default user is not in the business.");
            ErrorMessages.Add(UnManagedidsbizmgmtmissparentbusiness, "The parent business was unexpectedly missing.");
            ErrorMessages.Add(UnManagedidsbizmgmtmissuserdomainname, "The user's domain name was unexpectedly missing.");
            ErrorMessages.Add(UnManagedidsbizmgmtmissbusinessname, "The business name was unexpectedly missing.");
            ErrorMessages.Add(UnManagedidsxmlinvalidread, "A field that is not valid for read was specified");
            ErrorMessages.Add(UnManagedidsxmlinvalidfield, "An invalid value was passed in for a field");
            ErrorMessages.Add(UnManagedidsxmlinvalidentityattributes, "Invalid attributes");
            ErrorMessages.Add(UnManagedidsxmlunexpected, "An unexpected error has occurred");
            ErrorMessages.Add(UnManagedidsxmlparseerror, "A parse error was encountered in the XML");
            ErrorMessages.Add(UnManagedidsxmlinvalidcollectionname, "The collection name specified is incorrect");
            ErrorMessages.Add(UnManagedidsxmlinvalidupdate, "A field that is not valid for update was specified");
            ErrorMessages.Add(UnManagedidsxmlinvalidcreate, "A field that is not valid for create was specified");
            ErrorMessages.Add(UnManagedidsxmlinvalidentityname, "The entity name specified is incorrect");
            ErrorMessages.Add(UnManagedidsnotesnoattachment, "The specified note has no attachments.");
            ErrorMessages.Add(UnManagedidsnotesloopbeingcreated, "Creating this parental association would create a loop in the annotation hierarchy.");
            ErrorMessages.Add(UnManagedidsnotesloopexists, "A loop exists in the annotation hierarchy.");
            ErrorMessages.Add(UnManagedidsnotesalreadyattached, "The specified note is already attached to an object.");
            ErrorMessages.Add(UnManagedidsnotesnotedoesnotexist, "The specified note does not exist.");
            ErrorMessages.Add(DuplicatedPrivilege, "Privilege {0} is duplicated.");
            ErrorMessages.Add(MemberHasAlreadyBeenContacted, "This marketing list member was not contacted, because the member has previously received this communication.");
            ErrorMessages.Add(TeamInWrongBusiness, "The team belongs to a different business unit than the role.");
            ErrorMessages.Add(UnManagedidsrolesdeletenonparentrole, "Cannot delete a role that is inherited from a parent business.");
            ErrorMessages.Add(InvalidPrivilegeDepth, "Invalid privilege depth.");
            ErrorMessages.Add(UnManagedidsrolesinvalidrolename, "The role name is invalid.");
            ErrorMessages.Add(UserInWrongBusiness, "The user belongs to a different business unit than the role.");
            ErrorMessages.Add(UnManagedidsrolesmissprivid, "The privilege ID was unexpectedly missing.");
            ErrorMessages.Add(UnManagedidsrolesmissrolename, "The role name was unexpectedly missing.");
            ErrorMessages.Add(UnManagedidsrolesmissbusinessid, "The role's business unit ID was unexpectedly missing.");
            ErrorMessages.Add(UnManagedidsrolesmissroleid, "The role ID was unexpectedly missing.");
            ErrorMessages.Add(UnManagedidsrolesinvalidtemplateid, "Invalid role template ID.");
            ErrorMessages.Add(RoleAlreadyExists, "A role with the specified name already exists.");
            ErrorMessages.Add(UnManagedidsrolesroledoesnotexist, "The specified role does not exist.");
            ErrorMessages.Add(UnManagedidsrolesinvalidroleid, "Invalid role ID.");
            ErrorMessages.Add(UnManagedidsrolesinvalidroledata, "The role data is invalid.");
            ErrorMessages.Add(QueryBuilderAttributeCannotBeGroupByAndAggregate, "An attribute can either be an aggregate or a Group By but not both");
            ErrorMessages.Add(SqlArithmeticOverflowError, "A SQL arithmetic overflow error occurred");
            ErrorMessages.Add(QueryBuilderInvalidDateGrouping, "An invalid value was specified for dategrouping.");
            ErrorMessages.Add(QueryBuilderAliasRequiredForAggregateOrderBy, "An alias is required for an order clause for an aggregate Query.");
            ErrorMessages.Add(QueryBuilderAttributeRequiredForNonAggregateOrderBy, "An attribute is required for an order clause for a non-aggregate Query.");
            ErrorMessages.Add(QueryBuilderAliasNotAllowedForNonAggregateOrderBy, "An alias cannot be specified for an order clause for a non-aggregate Query. Use an attribute.");
            ErrorMessages.Add(QueryBuilderAttributeNotAllowedForAggregateOrderBy, "An attribute cannot be specified for an order clause for an aggregate Query. Use an alias.");
            ErrorMessages.Add(QueryBuilderDuplicateAlias, "FetchXML should have unique aliases.");
            ErrorMessages.Add(QueryBuilderInvalidAggregateAttribute, "Aggregate SUM, MIN, MAX and AVG can only be used with integer, float, money and decimal type attributes.");
            ErrorMessages.Add(QueryBuilderDeserializeInvalidGroupBy, "The only valid values for groupby attribute are 'true', 'false', '1', and '0'.");
            ErrorMessages.Add(QueryBuilderNoAttrsDistinctConflict, "The no-attrs tag cannot be used in conjuction with Distinct set to true.");
            ErrorMessages.Add(QueryBuilderInvalidPagingCookie, "Invalid page number in paging cookie.");
            ErrorMessages.Add(QueryBuilderPagingOrderBy, "Order by columns do not match those in paging cookie.");
            ErrorMessages.Add(QueryBuilderEntitiesDontMatch, "The entity name specified in fetchxml does not match the entity name specified in the Entity or Query Expression.");
            ErrorMessages.Add(QueryBuilderTopCountGreaterThanZero, "Converting from EntityExpression to Query failed. Top.Count must be equal to zero.");
            ErrorMessages.Add(QueryBuilderLinkNodeForOrderNotFound, "Converting from Query to EntityExpression failed. Link Node for order was not found.");
            ErrorMessages.Add(QueryBuilderDeserializeNoDocElemXml, "Document Element can't be null.");
            ErrorMessages.Add(QueryBuilderDeserializeEmptyXml, "Xml String can't be null.");
            ErrorMessages.Add(QueryBuilderElementNotFound, "A required element was not specified.");
            ErrorMessages.Add(QueryBuilderInvalidFilterType, "Unsupported filter type. Valid values are 'and', or 'or'.");
            ErrorMessages.Add(QueryBuilderInvalidJoinOperator, "Unsupported join operator.");
            ErrorMessages.Add(QueryBuilderInvalidConditionOperator, "Unsupported condition operator.");
            ErrorMessages.Add(QueryBuilderInvalidOrderType, "A valid order type must be set in the order before calling this method.");
            ErrorMessages.Add(QueryBuilderAttributeNotFound, "A required attribute was not specified.");
            ErrorMessages.Add(QueryBuilderDeserializeInvalidUtcOffset, "The utc-offset attribute is not supported for deserialization.");
            ErrorMessages.Add(QueryBuilderDeserializeInvalidNode, "The element node encountered is invalid.");
            ErrorMessages.Add(QueryBuilderDeserializeInvalidGetMinActiveRowVersion, "The only valid values for GetMinActiveRowVersion attribute are 'true', 'false', '1', and '0'.");
            ErrorMessages.Add(QueryBuilderDeserializeInvalidAggregate, "An error occurred while processing Aggregates in Query");
            ErrorMessages.Add(QueryBuilderDeserializeInvalidDescending, "The only valid values for descending attribute are 'true', 'false', '1', and '0'.");
            ErrorMessages.Add(QueryBuilderDeserializeInvalidNoLock, "The only valid values for no-lock attribute are 'true', 'false', '1', and '0'.");
            ErrorMessages.Add(QueryBuilderDeserializeInvalidLinkType, "The only valid values for link-type attribute are 'natural', 'inner', and 'outer'.");
            ErrorMessages.Add(QueryBuilderDeserializeInvalidMapping, "The only valid values for mapping are 'logical' or 'internal' which is deprecated.");
            ErrorMessages.Add(QueryBuilderDeserializeInvalidDistinct, "The only valid values for distinct attribute are 'true', 'false', '1', and '0'.");
            ErrorMessages.Add(QueryBuilderSerialzeLinkTopCriteria, "Fetch does not support where clause with conditions from linkentity.");
            ErrorMessages.Add(QueryBuilderColumnSetVersionMissing, "The specified columnset version is invalid.");
            ErrorMessages.Add(QueryBuilderInvalidColumnSetVersion, "The specified columnset version is invalid.");
            ErrorMessages.Add(QueryBuilderAttributePairMismatch, "AttributeFrom and AttributeTo must be either both specified or both omitted.");
            ErrorMessages.Add(QueryBuilderByAttributeNonEmpty, "QueryByAttribute must specify a non-empty attribute array.");
            ErrorMessages.Add(QueryBuilderByAttributeMismatch, "QueryByAttribute must specify a non-empty value array with the same number of elements as in the attributes array.");
            ErrorMessages.Add(QueryBuilderMultipleIntersectEntities, "More than one intersect entity exists between the two entities specified.");
            ErrorMessages.Add(QueryBuilderReportViewDoesNotExist, "A report view does not exist for the specified entity.");
            ErrorMessages.Add(QueryBuilderValueGreaterThanZero, "A value greater than zero must be specified.");
            ErrorMessages.Add(QueryBuilderNoAlias, "No alias for the given entity in the condition was found.");
            ErrorMessages.Add(QueryBuilderAliasDoesNotExist, "The specified alias for the given entity in the condition does not exist.");
            ErrorMessages.Add(QueryBuilderInvalidAlias, "Invalid alias for aggregate operation.");
            ErrorMessages.Add(QueryBuilderInvalidValue, "Invalid value specified for type.");
            ErrorMessages.Add(QueryBuilderAttributeWithAggregate, "Attributes can not be returned when aggregate operation is specified.");
            ErrorMessages.Add(QueryBuilderBadCondition, "Incorrect filter condition or conditions.");
            ErrorMessages.Add(QueryBuilderNoAttribute, "The specified attribute does not exist on this entity.");
            ErrorMessages.Add(QueryBuilderNoEntity, "The specified entity was not found.");
            ErrorMessages.Add(QueryBuilderUnexpected, "An unexpected error occurred.");
            ErrorMessages.Add(QueryBuilderInvalidUpdate, "An attempt was made to update a non-updateable field.");
            ErrorMessages.Add(QueryBuilderInvalidLogicalOperator, "Unsupported logical operator: {0}.  Accepted values are ('and', 'or').");
            ErrorMessages.Add(UnManagedidsmetadatanorelationship, "The relationship does not exist");
            ErrorMessages.Add(MetadataNoMapping, "The mapping between specified entities does not exist");
            ErrorMessages.Add(MetadataNotSerializable, "The given metadata entity is not serializable");
            ErrorMessages.Add(UnManagedidsmetadatanoentity, "The specified entity does not exist");
            ErrorMessages.Add(UnManagedidscommunicationsnosenderaddress, "The sender does not have an email address on the party record");
            ErrorMessages.Add(UnManagedidscommunicationstemplateinvalidtemplate, "The template body is invalid");
            ErrorMessages.Add(UnManagedidscommunicationsnoparticipationmask, "Participation type is missing from an activity");
            ErrorMessages.Add(UnManagedidscommunicationsnorecipients, "At least one system user or queue in the organization must be a recipient");
            ErrorMessages.Add(EmailRecipientNotSpecified, "The e-mail must have at least one recipient before it can be sent");
            ErrorMessages.Add(UnManagedidscommunicationsnosender, "No email address was specified, and the calling user does not have an email address set");
            ErrorMessages.Add(UnManagedidscommunicationsbadsender, "More than one sender specified");
            ErrorMessages.Add(UnManagedidscommunicationsnopartyaddress, "Object address not found on party or party is marked as non-emailable");
            ErrorMessages.Add(UnManagedidsjournalingmissingincidentid, "Incident Id missed.");
            ErrorMessages.Add(UnManagedidsjournalingmissingcontactid, "Contact Id missed.");
            ErrorMessages.Add(UnManagedidsjournalingmissingopportunityid, "Opportunity Id missed.");
            ErrorMessages.Add(UnManagedidsjournalingmissingaccountid, "Account Id missed.");
            ErrorMessages.Add(UnManagedidsjournalingmissingleadid, "Lead Id missed.");
            ErrorMessages.Add(UnManagedidsjournalingmissingeventtype, "Event type missed.");
            ErrorMessages.Add(UnManagedidsjournalinginvalideventtype, "Invalid event type.");
            ErrorMessages.Add(UnManagedidsjournalingmissingeventdirection, "Event direction code missed.");
            ErrorMessages.Add(UnManagedidsjournalingunsupportedobjecttype, "Unsupported type of objects passed in operation.");
            ErrorMessages.Add(SdkEntityDoesNotSupportMessage, "The method being invoked does not support provided entity type.");
            ErrorMessages.Add(OpportunityAlreadyInOpenState, "The opportunity is already in the open state.");
            ErrorMessages.Add(LeadAlreadyInClosedState, "The lead is already closed.");
            ErrorMessages.Add(LeadAlreadyInOpenState, "The lead is already in the open state.");
            ErrorMessages.Add(CustomerIsInactive, "An inactive customer cannot be set as the parent of an object.");
            ErrorMessages.Add(OpportunityCannotBeClosed, "The opportunity cannot be closed.");
            ErrorMessages.Add(OpportunityIsAlreadyClosed, "The opportunity is already closed.");
            ErrorMessages.Add(UnManagedidscustomeraddresstypeinvalid, "Invalid customer address type.");
            ErrorMessages.Add(UnManagedidsleadnotassignedtocaller, "The lead is not being assigned to the caller for acceptance.");
            ErrorMessages.Add(UnManagedidscontacthaschildopportunities, "The Contact has child opportunities.");
            ErrorMessages.Add(UnManagedidsaccounthaschildopportunities, "The Account has child opportunities.");
            ErrorMessages.Add(UnManagedidsleadoneaccount, "A lead can be associated with only one account.");
            ErrorMessages.Add(UnManagedidsopportunityorphan, "Removing this association will make the opportunity an orphan.");
            ErrorMessages.Add(UnManagedidsopportunityoneaccount, "An opportunity can be associated with only one account.");
            ErrorMessages.Add(UnManagedidsleadusercannotreject, "The user does not have the privilege to reject a lead, so he cannot be assigned the lead for acceptance.");
            ErrorMessages.Add(UnManagedidsleadnotassigned, "The lead has not been assigned.");
            ErrorMessages.Add(UnManagedidsleadnoparent, "The lead does not have a parent.");
            ErrorMessages.Add(ContactLoopBeingCreated, "Creating this parental association would create a loop in Contacts hierarchy.");
            ErrorMessages.Add(ContactLoopExists, "Loop exists in the contacts hierarchy.");
            ErrorMessages.Add(PresentParentAccountAndParentContact, "You can either specify a contacts parent contact or its account, but not both.");
            ErrorMessages.Add(AccountLoopBeingCreated, "Creating this parental association would create a loop in Accounts hierarchy.");
            ErrorMessages.Add(AccountLoopExists, "Loop exists in the accounts hierarchy.");
            ErrorMessages.Add(UnManagedidsopportunitymissingparent, "The parent of the opportunity is missing.");
            ErrorMessages.Add(UnManagedidsopportunityinvalidparent, "The parent of an opportunity must be an account or contact.");
            ErrorMessages.Add(ContactDoesNotExist, "Contact does not exist.");
            ErrorMessages.Add(AccountDoesNotExist, "Account does not exist.");
            ErrorMessages.Add(UnManagedidsleaddoesnotexist, "Lead does not exist.");
            ErrorMessages.Add(UnManagedidsopportunitydoesnotexist, "Opportunity does not exist.");
            ErrorMessages.Add(ReportDoesNotExist, "Report does not exist.");
            ErrorMessages.Add(ReportLoopBeingCreated, "Creating this parental association would create a loop in Reports hierarchy.");
            ErrorMessages.Add(ReportLoopExists, "Loop exists in the reports hierarchy.");
            ErrorMessages.Add(ParentReportLinksToSameNameChild, "Parent report already links to another report with the same name.");
            ErrorMessages.Add(DuplicateReportVisibility, "A ReportVisibility with the same ReportId and VisibilityCode already exists. Duplicates are not allowed.");
            ErrorMessages.Add(ReportRenderError, "An error occurred during report rendering.");
            ErrorMessages.Add(SubReportDoesNotExist, "Subreport does not exist.");
            ErrorMessages.Add(SrsDataConnectorNotInstalled, "MSCRM Data Connector Not Installed");
            ErrorMessages.Add(InvalidCustomReportingWizardXml, "Invalid wizard xml");
            ErrorMessages.Add(UpdateNonCustomReportFromTemplate, "Cannot update a report from a template if the report was not created from a template");
            ErrorMessages.Add(SnapshotReportNotReady, "The selected report is not ready for viewing. The report is still being created or a report snapshot is not available.");
            ErrorMessages.Add(ExistingExternalReport, "The report could not be published for external use because a report of the same name already exists. Delete that report in SQL Server Reporting Services or rename this report, and try again.");
            ErrorMessages.Add(ParentReportNotSupported, "Parent report is not supported for the type of report specified. Only SQL Reporting Services reports can have parent reports.");
            ErrorMessages.Add(ParentReportDoesNotReferenceChild, "Specified parent report does not reference the current one. Only SQL Reporting Services reports can have parent reports.");
            ErrorMessages.Add(MultipleParentReportsFound, "More than one report link found. Each report can have only one parent.");
            ErrorMessages.Add(ReportingServicesReportExpected, "The report is not a Reporting Services report.");
            ErrorMessages.Add(InvalidTransformationParameter, "A parameter for the transformation is either missing or invalid.");
            ErrorMessages.Add(ReflexiveEntityParentOrChildDoesNotExist, "Either the parent or child entity does not exist");
            ErrorMessages.Add(EntityLoopBeingCreated, "Creating this parental association would create a loop in this entity hierarchy.");
            ErrorMessages.Add(EntityLoopExists, "Loop exists in this entity hierarchy.");
            ErrorMessages.Add(UnsupportedProcessCode, "The process code is not supported on this entity.");
            ErrorMessages.Add(NoOutputTransformationParameterMappingFound, "There is no output transformation parameter mapping defined. A transformation mapping must have atleast one output transformation parameter mapping.");
            ErrorMessages.Add(RequiredColumnsNotFoundInImportFile, "One or more source columns used in the transformation do not exist in the source file.");
            ErrorMessages.Add(InvalidTransformationParameterMapping, "The transformation parameter mapping defined is invalid. Check that the target attribute name exists.");
            ErrorMessages.Add(UnmappedTransformationOutputDataFound, "One or more outputs returned by the transformation is not mapped to target fields.");
            ErrorMessages.Add(InvalidTransformationParameterDataType, "The data type of one or more of the transformation parameters is unsupported.");
            ErrorMessages.Add(ArrayMappingFoundForSingletonParameter, "An array transformation parameter mapping is defined for a single parameter.");
            ErrorMessages.Add(SingletonMappingFoundForArrayParameter, "A single transformation parameter mapping is defined for an array parameter.");
            ErrorMessages.Add(IncompleteTransformationParameterMappingsFound, "One or more mandatory transformation parameters do not have mappings defined for them.");
            ErrorMessages.Add(InvalidTransformationParameterMappings, "One or more transformation parameter mappings are invalid or do not match the transformation parameter description.");
            ErrorMessages.Add(GenericTransformationInvocationError, "The transformation returned invalid data.");
            ErrorMessages.Add(InvalidTransformationType, "The specified transformation type is not supported.");
            ErrorMessages.Add(UnableToLoadTransformationType, "Unable to load the transformation type.");
            ErrorMessages.Add(UnableToLoadTransformationAssembly, "Unable to load the transformation assembly.");
            ErrorMessages.Add(InvalidColumnMapping, "ColumnMapping is Invalid. Check that the target attribute exists.");
            ErrorMessages.Add(CannotModifyOldDataFromImport, "The corresponding record in Microsoft Dynamics CRM has more recent data, so this record was ignored.");
            ErrorMessages.Add(ImportFileTooLargeToUpload, "The import file is too large to upload.");
            ErrorMessages.Add(InvalidImportFileContent, "The content of the import file is not valid. You must select a text file.");
            ErrorMessages.Add(EmptyRecord, "The record is empty");
            ErrorMessages.Add(LongParseRow, "The row is too long to import");
            ErrorMessages.Add(ParseMustBeCalledBeforeTransform, "Cannot call transform before parse.");
            ErrorMessages.Add(HeaderValueDoesNotMatchAttributeDisplayLabel, "The column heading does not match the attribute display label.");
            ErrorMessages.Add(InvalidTargetEntity, "The specified target record type does not exist.");
            ErrorMessages.Add(NoHeaderColumnFound, "A column heading is missing.");
            ErrorMessages.Add(ParsingMetadataNotFound, "Data required to parse the file, such as the data delimiter, field delimiter, or column headings, was not found.");
            ErrorMessages.Add(EmptyHeaderRow, "The first row of the file is empty.");
            ErrorMessages.Add(EmptyContent, "The file is empty.");
            ErrorMessages.Add(InvalidIsFirstRowHeaderForUseSystemMap, "The first row of the file does not contain column headings.");
            ErrorMessages.Add(InvalidGuid, "The globally unique identifier (GUID) in this row is invalid");
            ErrorMessages.Add(GuidNotPresent, "The required globally unique identifier (GUID) in this row is not present");
            ErrorMessages.Add(OwnerValueNotMapped, "The owner value is not mapped");
            ErrorMessages.Add(PicklistValueNotMapped, "The record could not be processed as the Option set value could not be mapped.");
            ErrorMessages.Add(ErrorInDelete, "The Microsoft Dynamics CRM record could not be deleted");
            ErrorMessages.Add(ErrorIncreate, "The Microsoft Dynamics CRM record could not be created");
            ErrorMessages.Add(ErrorInUpdate, "The Microsoft Dynamics CRM record could not be updated");
            ErrorMessages.Add(ErrorInSetState, "The status or status reason of the Microsoft Dynamics CRM record could not be set");
            ErrorMessages.Add(InvalidDataFormat, "The source data is not in the required format");
            ErrorMessages.Add(InvalidFormatForDataDelimiter, "Mismatched data delimiter: only one delimiter was found.");
            ErrorMessages.Add(CrmUserDoesNotExist, "No Microsoft Dynamics CRM user exists with the specified domain name and user ID");
            ErrorMessages.Add(LookupNotFound, "The lookup reference could not be resolved");
            ErrorMessages.Add(DuplicateLookupFound, "A duplicate lookup reference was found");
            ErrorMessages.Add(InvalidImportFileData, "The data is not in the required format");
            ErrorMessages.Add(InvalidXmlSsContent, "The file could not be uploaded because the file format is not valid. Save the file in the XML Spreadsheet 2003 (.xml) format and then upload.");
            ErrorMessages.Add(InvalidImportFileParseData, "Field and data delimiters for this file are not specified.");
            ErrorMessages.Add(InvalidValueForFileType, "The file type is invalid.");
            ErrorMessages.Add(EmptyImportFileRow, "Empty row.");
            ErrorMessages.Add(ErrorInParseRow, "The row could not be parsed. This is typically caused by a row that is too long.");
            ErrorMessages.Add(DataColumnsNumberMismatch, "The number of fields differs from the number of column headings.");
            ErrorMessages.Add(InvalidHeaderColumn, "The column heading contains an invalid combination of data delimiters.");
            ErrorMessages.Add(OwnerMappingExistsWithSourceSystemUserName, "The data map already contains this owner mapping.");
            ErrorMessages.Add(PickListMappingExistsWithSourceValue, "The data map already contains this list value mapping.");
            ErrorMessages.Add(InvalidValueForDataDelimiter, "The data delimiter is invalid.");
            ErrorMessages.Add(InvalidValueForFieldDelimiter, "The field delimiter is invalid.");
            ErrorMessages.Add(PickListMappingExistsForTargetValue, "This list value is mapped more than once. Remove any duplicate mappings, and then import this data map again.");
            ErrorMessages.Add(MappingExistsForTargetAttribute, "This attribute is mapped more than once. Remove any duplicate mappings, and then import this data map again.");
            ErrorMessages.Add(SourceEntityMappedToMultipleTargets, "This source entity is mapped to more than one Microsoft Dynamics CRM entity. Remove any duplicate mappings, and then import this data map again.");
            ErrorMessages.Add(AttributeNotOfTypePicklist, "This attribute is not mapped to a drop-down list, Boolean, or state/status attribute. However, you have included a ListValueMap element for it.  Fix this inconsistency, and then import this data map again.");
            ErrorMessages.Add(AttributeNotOfTypeReference, "This attribute is not mapped as a reference attribute. However, you have included a ReferenceMap for it.  Fix this inconsistency, and then import this data map again.");
            ErrorMessages.Add(TargetEntityNotFound, "The file specifies an entity that does not exist in Microsoft Dynamics CRM.");
            ErrorMessages.Add(TargetAttributeNotFound, "The file specifies an attribute that does not exist in Microsoft Dynamics CRM.");
            ErrorMessages.Add(PicklistValueNotFound, "The file specifies a list value that does not exist in Microsoft Dynamics CRM.");
            ErrorMessages.Add(TargetAttributeInvalidForMap, "This attribute is not valid for mapping.");
            ErrorMessages.Add(TargetEntityInvalidForMap, "The file specifies an entity that is not valid for data migration.");
            ErrorMessages.Add(InvalidFileBadCharacters, "The file could not be uploaded because it contains invalid character(s)");
            ErrorMessages.Add(ErrorsInImportFiles, "Invalid File(s) for Import");
            ErrorMessages.Add(InvalidOperationWhenListIsNotActive, "List is not active. Cannot perform this operation.");
            ErrorMessages.Add(InvalidOperationWhenPartyIsNotActive, "The party is not active. Cannot perform this operation.");
            ErrorMessages.Add(AsyncOperationSuspendedOrLocked, ">A background job associated with this import is either suspended or locked. In order to delete this import, in the Workplace, click Imports, open the import, click System Jobs, and resume any suspended jobs.");
            ErrorMessages.Add(DuplicateHeaderColumn, "A duplicate column heading exists.");
            ErrorMessages.Add(EmptyHeaderColumn, "The column heading cannot be empty.");
            ErrorMessages.Add(InvalidColumnNumber, "The column number specified in the data map does not exist.");
            ErrorMessages.Add(TransformMustBeCalledBeforeImport, "Cannot call import before transform.");
            ErrorMessages.Add(OperationCanBeCalledOnlyOnce, "The specified action can be done only one time.");
            ErrorMessages.Add(DuplicateRecordsFound, "A record was not created or updated because a duplicate of the current record already exists.");
            ErrorMessages.Add(CampaignActivityClosed, "This Campaign Activity is closed or canceled. Campaign activities cannot be distributed after they have been closed or canceled.");
            ErrorMessages.Add(UnexpectedErrorInMailMerge, "There was an unexpected error during mail merge.");
            ErrorMessages.Add(UserCancelledMailMerge, "The mail merge operation was cancelled by the user.");
            ErrorMessages.Add(FilteredDuetoMissingEmailAddress, "This customer is filtered due to missing email address.");
            ErrorMessages.Add(CannotDeleteAsBackgroundOperationInProgress, "This record is currently being used by Microsoft Dynamics CRM and cannot be deleted. Try again later. If  the problem persists, contact your system administrator.");
            ErrorMessages.Add(FilteredDuetoInactiveState, "This customer is filtered due to inactive state.");
            ErrorMessages.Add(MissingBowfRules, "Bulk Operation related workflow rules are missing.");
            ErrorMessages.Add(CannotSpecifyOwnerForActivityPropagation, "Cannot specify owner on activity for distribution");
            ErrorMessages.Add(CampaignActivityAlreadyPropagated, "This campaign activity has been distributed already. Campaign activities cannot be distributed more than one time.");
            ErrorMessages.Add(FilteredDuetoAntiSpam, "This customer is filtered due to AntiSpam settings.");
            ErrorMessages.Add(TemplateTypeNotSupportedForUnsubscribeAcknowledgement, "This template type is not supported for unsubscribe acknowledgement.");
            ErrorMessages.Add(ErrorInImportConfig, "Cannot process with Bulk Import as Import Configuration has some errors.");
            ErrorMessages.Add(ImportConfigNotSpecified, "Cannot process with Bulk Import as Import Configuration not specified.");
            ErrorMessages.Add(InvalidActivityType, "An invalid object type was specified for distributing activities.");
            ErrorMessages.Add(UnsupportedParameter, "A parameter specified is not supported by the Bulk Operation");
            ErrorMessages.Add(MissingParameter, "A required parameter is missing for the Bulk Operation");
            ErrorMessages.Add(CannotSpecifyCommunicationAttributeOnActivityForPropagation, "Cannot specify communication attribute on activity for distribution");
            ErrorMessages.Add(CannotSpecifyRecipientForActivityPropagation, "Cannot specify a recipient for activity distribution.");
            ErrorMessages.Add(CannotSpecifyAttendeeForAppointmentPropagation, "Cannot specify an attendee for appointment distribution.");
            ErrorMessages.Add(CannotSpecifySenderForActivityPropagation, "Cannot specify a sender for appointment distribution");
            ErrorMessages.Add(CannotSpecifyOrganizerForAppointmentPropagation, "Cannot specify an organizer for appointment distribution");
            ErrorMessages.Add(InvalidRegardingObjectTypeCode, "The regarding Object Type Code is not valid for the Bulk Operation.");
            ErrorMessages.Add(UnspecifiedActivityXmlForCampaignActivityPropagate, "Must specify an Activity Xml for CampaignActivity Execute/Distribute");
            ErrorMessages.Add(MoneySizeExceeded, "Supplied value exceeded the MIN/MAX value of Money Type field.");
            ErrorMessages.Add(ExtraPartyInformation, "Extra party information should not be provided for this operation.");
            ErrorMessages.Add(NotSupported, "This action is not supported.");
            ErrorMessages.Add(InvalidOperationForClosedOrCancelledCampaignActivity, "Can not add items to closed (cancelled) campaignactivity.");
            ErrorMessages.Add(InvalidEmailTemplate, "Must specify a valid Template Id");
            ErrorMessages.Add(CannotCreateResponseForTemplate, "CampaignResponse can not be created for Template Campaign.");
            ErrorMessages.Add(CannotPropagateCamapaignActivityForTemplate, "Cannot execute (distribute) a CampaignActivity for a template Campaign.");
            ErrorMessages.Add(InvalidChannelForCampaignActivityPropagate, "Cannot distribute activities for campaign activities of the specified channel type.");
            ErrorMessages.Add(InvalidActivityTypeForCampaignActivityPropagate, "Must specify a valid CommunicationActivity");
            ErrorMessages.Add(ObjectNotRelatedToCampaign, "Specified Object not related to the parent Campaign");
            ErrorMessages.Add(CannotRelateObjectTypeToCampaignActivity, "Specified Object Type not supported");
            ErrorMessages.Add(CannotUpdateCampaignForCampaignResponse, "Parent campaign is not updatable.");
            ErrorMessages.Add(CannotUpdateCampaignForCampaignActivity, "Parent campaign is not updatable.");
            ErrorMessages.Add(CampaignNotSpecifiedForCampaignResponse, "RegardingObjectId is a required field.");
            ErrorMessages.Add(CampaignNotSpecifiedForCampaignActivity, "RegardingObjectId is a required field.");
            ErrorMessages.Add(CannotRelateObjectTypeToCampaign, "Specified Object Type not supported");
            ErrorMessages.Add(CannotCopyIncompatibleListType, "Cannot copy lists of different types.");
            ErrorMessages.Add(InvalidActivityTypeForList, "Cannot create activities of the specified list type.");
            ErrorMessages.Add(CannotAssociateInactiveItemToCampaign, "Cannot associate an inactive item to a Campaign.");
            ErrorMessages.Add(InvalidFetchXml, "Malformed FetchXml.");
            ErrorMessages.Add(InvalidOperationWhenListLocked, "List is Locked. Cannot perform this action.");
            ErrorMessages.Add(UnsupportedListMemberType, "Unsupported list member type.");
            ErrorMessages.Add(CannotMoveDisabledUser, "Disabled users cannot be moved to a different business unit.");
            ErrorMessages.Add(InvalidPrimaryKey, "Invalid primary key.");
            ErrorMessages.Add(IsvAborted, "ISV code aborted the operation.");
            ErrorMessages.Add(CannotAssignOutlookFilters, "Cannot assign outlook filters");
            ErrorMessages.Add(CannotCreateOutlookFilters, "Cannot create outlook filters");
            ErrorMessages.Add(CannotGrantAccessToOutlookFilters, "Cannot grant access to outlook filters");
            ErrorMessages.Add(CannotModifyAccessToOutlookFilters, "Cannot modify access for outlook filters");
            ErrorMessages.Add(CannotRevokeAccessToOutlookFilters, "Cannot revoke access for outlook filters");
            ErrorMessages.Add(CannotGrantAccessToOfflineFilters, "Cannot grant access to offline filters");
            ErrorMessages.Add(CannotModifyAccessToOfflineFilters, "Cannot modify access for offline filters");
            ErrorMessages.Add(CannotRevokeAccessToOfflineFilters, "Cannot revoke access for offline filters");
            ErrorMessages.Add(DuplicateOutlookAppointment, "The Appointment being promoted from Outlook is already tracked in CRM");
            ErrorMessages.Add(AppointmentScheduleNotSet, "Scheduled End and Scheduled Start must be set for Appointments in order to sync with Outlook.");
            ErrorMessages.Add(PrivilegeCreateIsDisabledForOrganization, "Privilege Create is disabled for organization.");
            ErrorMessages.Add(UnauthorizedAccess, "Attempted to perform an unauthorized operation.");
            ErrorMessages.Add(InvalidCharactersInField, "The field '{0}' contains one or more invalid characters.");
            ErrorMessages.Add(CannotChangeStateOfNonpublicView, "Only public views can be deactivated and activated.");
            ErrorMessages.Add(CannotDeactivateDefaultView, "Default views cannot be deactivated.");
            ErrorMessages.Add(CannotSetInactiveViewAsDefault, "Inactive views cannot be set as default view.");
            ErrorMessages.Add(CannotExceedFilterLimit, "Cannot exceed synchronization filter limit.");
            ErrorMessages.Add(CannotHaveMultipleDefaultFilterTemplates, "Cannot have multiple default synchronization templates for a single entity.");
            ErrorMessages.Add(CrmConstraintParsingError, "Crm constraint parsing error occurred.");
            ErrorMessages.Add(CrmConstraintEvaluationError, "Crm constraint evaluation error occurred.");
            ErrorMessages.Add(CrmExpressionEvaluationError, "Crm expression evaluation error occurred.");
            ErrorMessages.Add(CrmExpressionParametersParsingError, "Crm expression parameters parsing error occurred.");
            ErrorMessages.Add(CrmExpressionBodyParsingError, "Crm expression body parsing error occurred.");
            ErrorMessages.Add(CrmExpressionParsingError, "Crm expression parsing error occurred.");
            ErrorMessages.Add(CrmMalformedExpressionError, "Crm malformed expression error occurred.");
            ErrorMessages.Add(CalloutException, "Callout Exception occurred.");
            ErrorMessages.Add(DateTimeFormatFailed, "Failed to produce a formatted datetime value.");
            ErrorMessages.Add(NumberFormatFailed, "Failed to produce a formatted numeric value.");
            ErrorMessages.Add(InvalidRestore, "RestoreCaller must be called after SwitchToSystemUser.");
            ErrorMessages.Add(InvalidCaller, "Cannot switch ExecutionContext to system user without setting Caller first.");
            ErrorMessages.Add(CrmSecurityError, "A failure occurred in CrmSecurity.");
            ErrorMessages.Add(TransactionAborted, "Transaction Aborted.");
            ErrorMessages.Add(CannotBindToSession, "Cannot bind to another session, session already bound.");
            ErrorMessages.Add(SessionTokenUnavailable, "Session token is not available unless there is a transaction in place.");
            ErrorMessages.Add(TransactionNotCommited, "Transaction not committed.");
            ErrorMessages.Add(TransactionNotStarted, "Transaction not started.");
            ErrorMessages.Add(MultipleChildPicklist, "Crm Internal Exception: Picklists with more than one childAttribute are not supported.");
            ErrorMessages.Add(InvalidSingletonResults, "Crm Internal Exception: Singleton Retrieve Query should not return more than 1 record.");
            ErrorMessages.Add(FailedToLoadAssembly, "Failed to load assembly");
            ErrorMessages.Add(CrmQueryExpressionNotInitialized, "The QueryExpression has not been initialized. Please use the constructor that takes in the entity name to create a correctly initialized instance");
            ErrorMessages.Add(InvalidRegistryKey, "Invalid registry key specified.");
            ErrorMessages.Add(InvalidPriv, "Invalid privilege type.");
            ErrorMessages.Add(MetadataNotFound, "Metadata not found.");
            ErrorMessages.Add(InvalidEntityClassException, "Invalid entity class.");
            ErrorMessages.Add(InvalidXmlEntityNameException, "Invalid Xml entity name.");
            ErrorMessages.Add(InvalidXmlCollectionNameException, "Invalid Xml collection name.");
            ErrorMessages.Add(InvalidRecurrenceRule, "Error in RecurrencePatternFactory.");
            ErrorMessages.Add(CrmImpersonationError, "Error occurred in the Crm AutoReimpersonator.");
            ErrorMessages.Add(ServiceInstantiationFailed, "Instantiation of an Entity failed.");
            ErrorMessages.Add(EntityInstantiationFailed, "Instantiation of an Entity instance Service failed.");
            ErrorMessages.Add(FormTransitionError, "The import has failed because the system cannot transition the entity form {0} from unmanaged to managed. Add at least one full (root) component to the managed solution, and then try to import it again.");
            ErrorMessages.Add(UserTimeConvertException, "Failed to convert user time zone information.");
            ErrorMessages.Add(UserTimeZoneException, "Failed to retrieve user time zone information.");
            ErrorMessages.Add(InvalidConnectionString, "The connection string not found or invalid.");
            ErrorMessages.Add(OpenCrmDbConnection, "Db Connection is Open, when it should be Closed.");
            ErrorMessages.Add(UnpopulatedPrimaryKey, "Primary Key must be populated for calls to platform on rich client in offline mode.");
            ErrorMessages.Add(InvalidVersion, "Unhandled Version mismatch found.");
            ErrorMessages.Add(InvalidOperation, "Invalid Operation performed.");
            ErrorMessages.Add(InvalidMetadata, "Invalid Metadata.");
            ErrorMessages.Add(InvalidDateTime, "The date-time format is invalid, or value is outside the supported range.");
            ErrorMessages.Add(UnManagedidscannotdefaultprivateview, "Private views cannot be default.");
            ErrorMessages.Add(DuplicateRecord, "Operation failed due to a SQL integrity violation.");
            ErrorMessages.Add(UnManagedidsnorelationship, "No relationship exists between the objects specified.");
            ErrorMessages.Add(MissingQueryType, "The query type is missing.");
            ErrorMessages.Add(InvalidRollupType, "The rollup type is invalid.");
            ErrorMessages.Add(InvalidState, "The object is not in a valid state to perform this operation.");
            ErrorMessages.Add(UnManagedidsviewisnotsharable, "The view is not sharable.");
            ErrorMessages.Add(PrincipalPrivilegeDenied, "Target user or team does not hold required privileges.");
            ErrorMessages.Add(CannotUpdateObjectBecauseItIsInactive, "The object cannot be updated because it is inactive.");
            ErrorMessages.Add(CannotDeleteCannedView, "System-defined views cannot be deleted.");
            ErrorMessages.Add(CannotUpdateBecauseItIsReadOnly, "The object cannot be updated because it is read-only.");
            ErrorMessages.Add(InvalidCustomer, "The customer is invalid.");
            ErrorMessages.Add(UnManagedidsdataoutofrange, "Data out of range");
            ErrorMessages.Add(UnManagedidsownernotenabled, "The specified owner has been disabled.");
            ErrorMessages.Add(BusinessManagementObjectAlreadyExists, "An object with the specified name already exists.");
            ErrorMessages.Add(InvalidOwnerId, "The owner ID is invalid or missing.");
            ErrorMessages.Add(CannotDeleteAsItIsReadOnly, "The object cannot be deleted because it is read-only.");
            ErrorMessages.Add(CannotDeleteDueToAssociation, "The object you tried to delete is associated with another object and cannot be deleted.");
            ErrorMessages.Add(UnManagedidsanonymousenabled, "The logged-in user was not found in the Active Directory.");
            ErrorMessages.Add(UnManagedidsusernotenabled, "The specified user is either disabled or is not a member of any business unit.");
            ErrorMessages.Add(BusinessNotEnabled, "The specified business unit is disabled.");
            ErrorMessages.Add(CannotAssignToDisabledBusiness, "The specified business unit cannot be assigned to because it is disabled.");
            ErrorMessages.Add(IsvUnExpected, "An unexpected error occurred from ISV code.");
            ErrorMessages.Add(OnlyOwnerCanRevoke, "Only the owner of an object can revoke the owner's access to that object.");
            ErrorMessages.Add(UnManagedidsoutofmemory, "Out of memory.");
            ErrorMessages.Add(UnManagedidscannotassigntobusiness, "Cannot assign an object to a merchant.");
            ErrorMessages.Add(PrivilegeDenied, "The user does not hold the necessary privileges.");
            ErrorMessages.Add(InvalidObjectTypes, "Invalid object type.");
            ErrorMessages.Add(UnManagedidscannotgrantorrevokeaccesstobusiness, "Cannot grant or revoke access rights to a merchant.");
            ErrorMessages.Add(UnManagedidsinvaliduseridorbusinessidorusersbusinessinvalid, "One of the following occurred: invalid user id, invalid business id or the user does not belong to the business.");
            ErrorMessages.Add(UnManagedidspresentuseridandteamid, "Both the user id and team id are present. Only one should be present.");
            ErrorMessages.Add(MissingUserId, "The user id or the team id is missing.");
            ErrorMessages.Add(MissingBusinessId, "The business id is missing or invalid.");
            ErrorMessages.Add(NotImplemented, "The requested functionality is not yet implemented.");
            ErrorMessages.Add(InvalidPointer, "The object is disposed.");
            ErrorMessages.Add(ObjectDoesNotExist, "The specified object was not found.");
            ErrorMessages.Add(UnExpected, "An unexpected error occurred.");
            ErrorMessages.Add(MissingOwner, "Item does not have an owner.");
            ErrorMessages.Add(CannotShareWithOwner, "An item cannot be shared with the owning user.");
            ErrorMessages.Add(UnManagedidsinvalidvisibilitymodificationaccess, "User does not have access to modify the visibility of this item.");
            ErrorMessages.Add(UnManagedidsinvalidowninguser, "Item does not have an owning user.");
            ErrorMessages.Add(UnManagedidsinvalidassociation, "Invalid association.");
            ErrorMessages.Add(InvalidAssigneeId, "Invalid assignee id.");
            ErrorMessages.Add(UnManagedidsfailureinittoken, "Failure in obtaining user token.");
            ErrorMessages.Add(UnManagedidsinvalidvisibility, "Invalid visibility.");
            ErrorMessages.Add(InvalidAccessRights, "Invalid access rights.");
            ErrorMessages.Add(InvalidSharee, "Invalid share id.");
            ErrorMessages.Add(UnManagedidsinvaliditemid, "Invalid item id.");
            ErrorMessages.Add(UnManagedidsinvalidorgid, "Invalid organization id.");
            ErrorMessages.Add(UnManagedidsinvalidbusinessid, "Invalid business id.");
            ErrorMessages.Add(UnManagedidsinvalidteamid, "Invalid team id.");
            ErrorMessages.Add(UnManagedidsinvaliduserid, "The user id is invalid or missing.");
            ErrorMessages.Add(InvalidParentId, "The parent id is invalid or missing.");
            ErrorMessages.Add(InvalidParent, "The parent object is invalid or missing.");
            ErrorMessages.Add(InvalidUserAuth, "User does not have the privilege to act on behalf another user.");
            ErrorMessages.Add(InvalidArgument, "Invalid argument.");
            ErrorMessages.Add(EmptyXml, "Empty XML.");
            ErrorMessages.Add(InvalidXml, "Invalid XML.");
            ErrorMessages.Add(RequiredFieldMissing, "Required field missing.");
            ErrorMessages.Add(SearchTextLenExceeded, "Search Text Length Exceeded.");
            ErrorMessages.Add(CannotAssignOfflineFilters, "Cannot assign offline filters");
            ErrorMessages.Add(ArticleIsPublished, "The article cannot be updated or deleted because it is in published state");
            ErrorMessages.Add(InvalidArticleTemplateState, "The article template state is undefined");
            ErrorMessages.Add(InvalidArticleStateTransition, "This article state transition is invalid because of the current state of the article");
            ErrorMessages.Add(InvalidArticleState, "The article state is undefined");
            ErrorMessages.Add(NullKbArticleTemplateId, "The kbarticletemplateid cannot be NULL");
            ErrorMessages.Add(NullArticleTemplateStructureXml, "The article template structurexml cannot be NULL");
            ErrorMessages.Add(NullArticleTemplateFormatXml, "The article template formatxml cannot be NULL");
            ErrorMessages.Add(NullArticleXml, "The article xml cannot be NULL");
            ErrorMessages.Add(InvalidContractDetailId, "The Contract detail id is invalid");
            ErrorMessages.Add(InvalidTotalPrice, "The total price is invalid");
            ErrorMessages.Add(InvalidTotalDiscount, "The total discount is invalid");
            ErrorMessages.Add(InvalidNetPrice, "The net price is invalid");
            ErrorMessages.Add(InvalidAllotmentsRemaining, "The allotments remaining is invalid");
            ErrorMessages.Add(InvalidAllotmentsUsed, "The allotments used is invalid");
            ErrorMessages.Add(InvalidAllotmentsTotal, "The total allotments is invalid");
            ErrorMessages.Add(InvalidAllotmentsCalc, "Allotments: remaining + used != total");
            ErrorMessages.Add(CannotRouteToSameQueue, "The queue item cannot be routed to the same queue");
            ErrorMessages.Add(CannotAddSingleQueueEnabledEntityToQueue, "The entity record cannot be added to the queue as it already exists in other queue.");
            ErrorMessages.Add(CannotUpdateDeactivatedQueueItem, "This item is deactivated. To work with this item, reactivate it and then try again.");
            ErrorMessages.Add(CannotCreateQueueItemInactiveObject, "Deactivated object cannot be added to queue.");
            ErrorMessages.Add(InsufficientPrivilegeToQueueOwner, "The owner of this queue does not have sufficient privileges to work with the queue.");
            ErrorMessages.Add(NoPrivilegeToWorker, "You cannot add items to an inactive queue. Select another queue and try again.");
            ErrorMessages.Add(CannotAddQueueItemsToInactiveQueue, "The selected user does not have sufficient permissions to work on items in this queue.");
            ErrorMessages.Add(EmailAlreadyExistsInDestinationQueue, "You cannot add this e-mail to the selected queue. A queue item for this e-mail already exists in the queue. You can delete the item from the queue, and then try again.");
            ErrorMessages.Add(CouldNotFindQueueItemInQueue, "Could not find any queue item associated with the Target in the specified SourceQueueId. Either the SourceQueueId or Target is invalid or the queue item does not exist.");
            ErrorMessages.Add(MultipleQueueItemsFound, "This item occurs in more than one queue and cannot be routed from this list. Locate the item in a queue and try to route the item again.");
            ErrorMessages.Add(ActiveQueueItemAlreadyExists, "An active queue item already exists for the given object. Cannot create more than one active queue item for this object.");
            ErrorMessages.Add(CannotRouteInactiveQueueItem, "You can't route a queue item that has been deactivated.");
            ErrorMessages.Add(QueueIdNotPresent, "You must enter the target queue. Provide a valid value in the Queue field and try again.");
            ErrorMessages.Add(QueueItemNotPresent, "You must enter the name of the record that you would like to put in the queue. Provide a valid value in the Queue Item field and try again.");
            ErrorMessages.Add(CannotUpdatePrivateOrWipQueue, "The private or WIP Bin queue is not allowed to be updated or deleted");
            ErrorMessages.Add(CannotFindUserQueue, "Cannot find user queue");
            ErrorMessages.Add(CannotFindObjectInQueue, "The object was not found in the given queue");
            ErrorMessages.Add(CannotRouteToQueue, "Cannot route to Work in progress queue");
            ErrorMessages.Add(RouteTypeUnsupported, "The route type is unsupported");
            ErrorMessages.Add(UserIdOrQueueNotSet, "Primary User Id or Destination Queue Type code not set");
            ErrorMessages.Add(RoutingNotAllowed, "This object type can not be routed.");
            ErrorMessages.Add(CannotUpdateMetricOnChildGoal, "You cannot update metric on a child goal.");
            ErrorMessages.Add(CannotUpdateGoalPeriodInfoChildGoal, "You cannot update goal period related attributes on a child goal.");
            ErrorMessages.Add(CannotUpdateMetricOnGoalWithChildren, "You cannot update metric on a goal which has associated child goals.");
            ErrorMessages.Add(FiscalPeriodGoalMissingInfo, "For a goal of fiscal period type, the fiscal period attribute must be set.");
            ErrorMessages.Add(CustomPeriodGoalHavingExtraInfo, "For a goal of custom period type, fiscal year and fiscal period attributes must be left blank.");
            ErrorMessages.Add(ParentChildMetricIdDiffers, "The metricid of child goal should be same as the parent goal.");
            ErrorMessages.Add(ParentChildPeriodAttributesDiffer, "The period settings of child goal should be same as the parent goal.");
            ErrorMessages.Add(CustomPeriodGoalMissingInfo, "For a goal of custom period type, goalstartdate and goalenddate attributes must have data.");
            ErrorMessages.Add(GoalMissingPeriodTypeInfo, "Goal Period Type needs to be specified when creating a goal. This field cannot be null.");
            ErrorMessages.Add(ParticipatingQueryEntityMismatch, "The entitytype of participating query should be the same as the entity specified in fetchxml.");
            ErrorMessages.Add(CannotUpdateGoalPeriodInfoClosedGoal, "You cannot change the time period of this goal because there are one or more closed subordinate goals.");
            ErrorMessages.Add(CannotUpdateRollupFields, "You cannot write on rollup fields if isoverride is not set to true in your create/update request.");
            ErrorMessages.Add(CannotDeleteMetricWithGoals, "This goal metric is being used by one or more goals and cannot be deleted.");
            ErrorMessages.Add(CannotUpdateRollupAttributeWithClosedGoals, "The changes made to the roll-up field definition cannot be saved because the related goal metric is being used by one or more closed goals.");
            ErrorMessages.Add(MetricNameAlreadyExists, "A goal metric with the same name already exists. Specify a different name, and try again.");
            ErrorMessages.Add(CannotUpdateMetricWithGoals, "The changes made to this record cannot be saved because this goal metric is being used by one or more goals.");
            ErrorMessages.Add(CannotCreateUpdateSourceAttribute, "Source Attribute Not Valid For Create/Update if Metric Type is Count.");
            ErrorMessages.Add(InvalidDateAttribute, "Date Attribute specified is not an attribute of Source Entity.");
            ErrorMessages.Add(InvalidSourceEntityAttribute, "Attribute {0} is not an attribute of Entity {1}.");
            ErrorMessages.Add(GoalAttributeAlreadyMapped, "The Metric Detail for Specified Goal Attribute already exists.");
            ErrorMessages.Add(InvalidSourceAttributeType, "Source Attribute Type does not match the Amount Data Type specified.");
            ErrorMessages.Add(MaxLimitForRollupAttribute, "Only three metric details per metric can be created.");
            ErrorMessages.Add(InvalidGoalAttribute, "Goal Attribute does not match the specified metric type.");
            ErrorMessages.Add(CannotUpdateParentAndDependents, "Cannot update metric or period attributes when parent is being updated.");
            ErrorMessages.Add(UserDoesNotHaveSendAsAllowed, "User does not have send-as privilege");
            ErrorMessages.Add(CannotUpdateQuoteCurrency, "The currency cannot be changed because this quote has Products associated with it. If you want to change the currency please delete all of the Products and then change the currency or create a new quote with the appropriate currency.");
            ErrorMessages.Add(UserDoesNotHaveSendAsForQueue, "You do not have sufficient privileges to send e-mail as the selected queue. Contact your system administrator for assistance.");
            ErrorMessages.Add(InvalidSourceStateValue, "The source state specified for the entity is invalid.");
            ErrorMessages.Add(InvalidSourceStatusValue, "The source status specified for the entity is invalid.");
            ErrorMessages.Add(InvalidEntityForDateAttribute, "Entity For Date Attribute can be either source entity or its parent.");
            ErrorMessages.Add(InvalidEntityForRollup, "The entity {0} is not a valid entity for rollup.");
            ErrorMessages.Add(InvalidFiscalPeriod, "The fiscal period {0} does not fall in the permitted range of fiscal periods as per organization's fiscal settings.");
            ErrorMessages.Add(UnManagedchildentityisnotchild, "The child entity supplied is not a child.");
            ErrorMessages.Add(UnManagedmissingparententity, "The parent entity could not be located.");
            ErrorMessages.Add(UnManagedunablegetexecutioncontext, "Failed to retrieve execution context (TLS).");
            ErrorMessages.Add(UnManagedpendingtrxexists, "A pending transaction already exists.");
            ErrorMessages.Add(UnManagedinvalidtrxcountforcommit, "The transaction count was expected to be 1 in order to commit.");
            ErrorMessages.Add(UnManagedinvalidtrxcountforrollback, "The transaction count was expected to be 1 in order to rollback.");
            ErrorMessages.Add(UnManagedunableswitchusercontext, "Cannot set to a different user context.");
            ErrorMessages.Add(UnManagedmissingdataaccess, "The data access could not be retrieved from the ExecutionContext.");
            ErrorMessages.Add(UnManagedinvalidcharacterdataforaggregate, "Character data is not valid when clearing an aggregate.");
            ErrorMessages.Add(UnManagedtrxinterophandlerset, "The TrxInteropHandler has already been set.");
            ErrorMessages.Add(UnManagedinvalidbinaryfield, "The platform cannot handle binary fields.");
            ErrorMessages.Add(UnManagedinvaludidispatchfield, "The platform cannot handle idispatch fields.");
            ErrorMessages.Add(UnManagedinvaliddbdatefield, "The platform cannot handle dbdate fields.");
            ErrorMessages.Add(UnManagedinvalddbtimefield, "The platform cannot handle dbtime fields.");
            ErrorMessages.Add(UnManagedinvalidfieldtype, "The platform cannot handle the specified field type.");
            ErrorMessages.Add(UnManagedinvalidstreamfield, "The platform cannot handle stream fields.");
            ErrorMessages.Add(UnManagedinvalidparametertypeforparameterizedquery, "A parameterized query is not supported for the supplied parameter type.");
            ErrorMessages.Add(UnManagedinvaliddynamicparameteraccessor, "SetParam failed processing the DynamicParameterAccessor parameter.");
            ErrorMessages.Add(UnManagedunablegetsessiontokennotrx, "Unable to retrieve the session token as there are no pending transactions.");
            ErrorMessages.Add(UnManagedunablegetsessiontoken, "Unable to retrieve the session token.");
            ErrorMessages.Add(UnManagedinvalidsecurityprincipal, "The security principal is invalid or missing.");
            ErrorMessages.Add(UnManagedmissingpreviousownertype, "Unable to determine the previous owner's type.");
            ErrorMessages.Add(UnManagedinvalidprivilegeid, "The privilege id is invalid or missing.");
            ErrorMessages.Add(UnManagedinvalidprivilegeusergroup, "The privilege user group id is invalid or missing.");
            ErrorMessages.Add(UnManagedunexpectedpropertytype, "Unexpected type for the property.");
            ErrorMessages.Add(UnManagedmissingaddressentity, "The address entity could not be found.");
            ErrorMessages.Add(UnManagederroraddingfiltertoqueryplan, "An error occurred adding a filter to the query plan.");
            ErrorMessages.Add(UnManagedmissingreferencesfromrelationship, "Unable to access a relationship in an entity's ReferencesFrom collection.");
            ErrorMessages.Add(UnManagedmissingreferencingattribute, "The relationship's ReferencingAttribute is missing or invalid.");
            ErrorMessages.Add(UnManagedinvalidoperator, "The operator provided is not valid.");
            ErrorMessages.Add(UnManagedunabletoaccessqueryplanfilter, "Unable to access a filter in the query plan.");
            ErrorMessages.Add(UnManagedmissingattributefortag, "An expected attribute was not found for the tag specified.");
            ErrorMessages.Add(UnManagederrorprocessingfilternodes, "An unexpected error occurred processing the filter nodes.");
            ErrorMessages.Add(UnManagedunabletolocateconditionfilter, "Unexpected error locating the filter for the condition.");
            ErrorMessages.Add(UnManagedinvalidpagevalue, "The page value is invalid or missing.");
            ErrorMessages.Add(UnManagedinvalidcountvalue, "The count value is invalid or missing.");
            ErrorMessages.Add(UnManagedinvalidversionvalue, "The version value is invalid or missing.");
            ErrorMessages.Add(UnManagedinvalidvaluettagoutsideconditiontag, "A invalid value tag was found outside of it's condition tag.");
            ErrorMessages.Add(UnManagedinvalidorganizationid, "The organizationid is missing or invalid.");
            ErrorMessages.Add(UnManagedinvalidowninguser, "The owninguser is mising or invalid.");
            ErrorMessages.Add(UnManagedinvalidowningbusinessunitorbusinessunitid, "The owningbusinessunit or businessunitid is missing or invalid.");
            ErrorMessages.Add(UnManagedinvalidprivilegeedepth, "Invalid privilege depth for user.");
            ErrorMessages.Add(UnManagedinvalidlinkobjects, "Invalid link entity, link to attribute, or link from attribute.");
            ErrorMessages.Add(UnManagedpartylistattributenotsupported, "Attributes of type partylist are not supported.");
            ErrorMessages.Add(UnManagedinvalidargumentsforcondition, "An invalid number of arguments was supplied to a condition.");
            ErrorMessages.Add(UnManagedunknownaggregateoperation, "An unknown aggregate operation was supplied.");
            ErrorMessages.Add(UnManagedmissingparentattributeonentity, "The parent attribute was not found on the expected entity.");
            ErrorMessages.Add(UnManagedinvalidprocesschildofcondition, "ProcessChildOfCondition was called with non-child-of condition.");
            ErrorMessages.Add(UnManagedunexpectedrimarykey, "Primary key attribute was not as expected.");
            ErrorMessages.Add(UnManagedmissinglinkentity, "Unexpected error locating link entity.");
            ErrorMessages.Add(UnManagedinvalidprocessliternalcondition, "ProcessLiteralCondition is only valid for use with Rollup queries.");
            ErrorMessages.Add(UnManagedemptyprocessliteralcondition, "No data specified for ProcessLiteralCondition.");
            ErrorMessages.Add(UnManagedunusablevariantdata, "Variant supplied contains data in an unusable format.");
            ErrorMessages.Add(UnManagedfieldnotvalidatedbyplatform, "A field was not validated by the platform.");
            ErrorMessages.Add(UnManagedmissingfilterattribute, "Missing filter attribute.");
            ErrorMessages.Add(UnManagedinvalidequalityoperand, "Only QB_LITERAL is supported for equality operand.");
            ErrorMessages.Add(UnManagedfilterindexoutofrange, "The filter index is out of range.");
            ErrorMessages.Add(UnManagedentityisnotintersect, "The entity is not an intersect entity.");
            ErrorMessages.Add(UnManagedcihldofconditionforoffilefilters, "Child-of condition is only allowed on offline filters.");
            ErrorMessages.Add(UnManagedinvalidowningbusinessunit, "The owningbusinessunit is missing or invalid.");
            ErrorMessages.Add(UnManagedinvalidbusinessunitid, "The businessunitid is missing or invalid.");
            ErrorMessages.Add(UnManagedmorethanonesortattribute, "More than one sort attributes were defined.");
            ErrorMessages.Add(UnManagedunabletoaccessqueryplan, "Unable to access the query plan.");
            ErrorMessages.Add(UnManagedparentattributenotfound, "The parent attribute was not found for the child attribute.");
            ErrorMessages.Add(UnManagedinvalidtlsmananger, "Failed to retrieve TLS Manager.");
            ErrorMessages.Add(UnManagedinvalidescapedxml, "Escaped xml size not as expected.");
            ErrorMessages.Add(UnManagedunabletoretrieveprivileges, "Failed to retrieve privileges.");
            ErrorMessages.Add(UnManagedproxycreationfailed, "Cannot create an instance of managed proxy.");
            ErrorMessages.Add(UnManagedinvalidprincipal, "The principal id is missing or invalid.");
            ErrorMessages.Add(RestrictInheritedRole, "Inherited roles cannot be modified.");
            ErrorMessages.Add(UnManagedidsfetchbetweentext, "between, not-between, in, and not-in operators are not allowed on attributes of type text or ntext.");
            ErrorMessages.Add(UnManagedidscantdisable, "The user cannot be disabled because they have workflow rules running under their context.");
            ErrorMessages.Add(CascadeInvalidLinkTypeTransition, "Invalid link type for system entity cascading actions.");
            ErrorMessages.Add(InvalidOrgOwnedCascadeLinkType, "Cascade User-Owned is not a valid cascade link type for org-owned entity relationships.");
            ErrorMessages.Add(CallerCannotChangeOwnDomainName, "The caller cannot change their own domain name");
            ErrorMessages.Add(AsyncOperationInvalidStateChange, "The target state could not be set because the state transition is not valid.");
            ErrorMessages.Add(AsyncOperationInvalidStateChangeUnexpected, "The target state could not be set because the state was changed by another process.");
            ErrorMessages.Add(AsyncOperationMissingId, "The AsyncOperationId is required to do the update.");
            ErrorMessages.Add(AsyncOperationInvalidStateChangeToComplete, "The target state could not be set to complete because the state transition is not valid.");
            ErrorMessages.Add(AsyncOperationInvalidStateChangeToReady, "The target state could not be set to ready because the state transition is not valid.");
            ErrorMessages.Add(AsyncOperationInvalidStateChangeToSuspended, "The target state could not be set to suspended because the state transition is not valid.");
            ErrorMessages.Add(AsyncOperationCannotUpdateNonrecurring, "Cannot update recurrence pattern for a job that is not recurring.");
            ErrorMessages.Add(AsyncOperationCannotUpdateRecurring, "Cannot update recurrence pattern for a job type that is not supported.");
            ErrorMessages.Add(AsyncOperationCannotDeleteUnlessCompleted, "Cannot delete async operation unless it is in Completed state.");
            ErrorMessages.Add(SdkInvalidMessagePropertyName, "Message property name '{0}' is not valid on message {1}.");
            ErrorMessages.Add(PluginAssemblyMustHavePublicKeyToken, "Public assembly must have public key token.");
            ErrorMessages.Add(SdkMessageInvalidImageTypeRegistration, "Message {0} does not support this image type.");
            ErrorMessages.Add(SdkMessageDoesNotSupportPostImageRegistration, "PreEvent step registration does not support Post Image.");
            ErrorMessages.Add(CannotDeserializeRequest, "The SDK request could not be deserialized.");
            ErrorMessages.Add(InvalidPluginRegistrationConfiguration, "The plug-in assembly registration configuration is invalid.");
            ErrorMessages.Add(SandboxClientPluginTimeout, "The plug-in execution failed because the operation has timed-out at the Sandbox Client.");
            ErrorMessages.Add(SandboxHostPluginTimeout, "The plug-in execution failed because the operation has timed-out at the Sandbox Host.");
            ErrorMessages.Add(SandboxWorkerPluginTimeout, "The plug-in execution failed because the operation has timed-out at the Sandbox Worker.");
            ErrorMessages.Add(SandboxSdkListenerStartFailed, "The plug-in execution failed because the Sandbox Client encountered an error during initialization.");
            ErrorMessages.Add(ServiceBusPostFailed, "The service bus post failed.");
            ErrorMessages.Add(ServiceBusIssuerNotFound, "Cannot find service integration issuer information.");
            ErrorMessages.Add(ServiceBusIssuerCertificateError, "Service integration issuer certificate error.");
            ErrorMessages.Add(ServiceBusExtendedTokenFailed, "Failed to retrieve the additional token for service bus post.");
            ErrorMessages.Add(ServiceBusPostPostponed, "Service bus post is being postponed.");
            ErrorMessages.Add(ServiceBusPostDisabled, "Service bus post is disabled for the organization.");
            ErrorMessages.Add(SdkMessageNotSupportedOnServer, "The message requested is not supported on the server.");
            ErrorMessages.Add(SdkMessageNotSupportedOnClient, "The message requested is not supported on the client.");
            ErrorMessages.Add(SdkCorrelationTokenDepthTooHigh, "This workflow job was canceled because the workflow that started it included an infinite loop. Correct the workflow logic and try again. For information about workflow logic, see Help.");
            ErrorMessages.Add(OnlyStepInPredefinedStagesCanBeModified, "Invalid plug-in registration stage. Steps can only be modified in stages BeforeMainOperationOutsideTransaction, BeforeMainOperationInsideTransaction, AfterMainOperationInsideTransaction and AfterMainOperationOutsideTransaction.");
            ErrorMessages.Add(OnlyStepInServerOnlyCanHaveSecureConfiguration, "Only SdkMessageProcessingStep with ServerOnly supported deployment can have secure configuration.");
            ErrorMessages.Add(OnlyStepOutsideTransactionCanCreateCrmService, "Only SdkMessageProcessingStep in parent pipeline and in stages outside transaction can create CrmService to prevent deadlock.");
            ErrorMessages.Add(SdkCustomProcessingStepIsNotAllowed, "Custom SdkMessageProcessingStep is not allowed on the specified message and entity.");
            ErrorMessages.Add(SdkEntityOfflineQueuePlaybackIsNotAllowed, "Entity '{0}' is not allowed in offline queue playback.");
            ErrorMessages.Add(SdkMessageDoesNotSupportImageRegistration, "Message '{0}' does not support image registration.");
            ErrorMessages.Add(RequestLengthTooLarge, "Request message length is too large.");
            ErrorMessages.Add(SandboxWorkerNotAvailable, "The plug-in execution failed because no Sandbox Worker processes are currently available. Please try again.");
            ErrorMessages.Add(SandboxHostNotAvailable, "The plug-in execution failed because no Sandbox Hosts are currently available. Please check that you have a Sandbox server configured and that it is running.");
            ErrorMessages.Add(PluginAssemblyContentSizeExceeded, "\"The assembly content size '{0} bytes' has exceeded the maximum value allowed for isolated plug-ins '{1} bytes'.\"");
            ErrorMessages.Add(UnableToLoadPluginType, "Unable to load plug-in type.");
            ErrorMessages.Add(UnableToLoadPluginAssembly, "Unable to load plug-in assembly.");
            ErrorMessages.Add(InvalidPluginAssemblyContent, "Plug-in assembly does not contain the required types or assembly content cannot be updated.");
            ErrorMessages.Add(InvalidPluginTypeImplementation, "Plug-in type must implement exactly one of the following classes or interfaces: Microsoft.Crm.Sdk.IPlugin, Microsoft.Xrm.Sdk.IPlugin, System.Activities.Activity and System.Workflow.ComponentModel.Activity.");
            ErrorMessages.Add(InvalidPluginAssemblyVersion, "Plug-in assembly fullnames must be unique (ignoring the version build and revision number).");
            ErrorMessages.Add(PluginTypeMustBeUnique, "Multiple plug-in types from the same assembly and with the same typename are not allowed.");
            ErrorMessages.Add(InvalidAssemblySourceType, "The given plugin assembly source type is not supported for isolated plugin assemblies.");
            ErrorMessages.Add(InvalidAssemblyProcessorArchitecture, "The given plugin assembly was built with an unsupported target platform and cannot be loaded.");
            ErrorMessages.Add(CyclicReferencesNotSupported, "The input contains a cyclic reference, which is not supported.");
            ErrorMessages.Add(InvalidEmailAddressFormat, "Invalid e-mail address. For more information, contact your system administrator.");
            ErrorMessages.Add(ContractInvalidDiscount, "Discount cannot be greater than total price.");
            ErrorMessages.Add(InvalidLanguageCode, "The specified language code is not valid for this organization.");
            ErrorMessages.Add(ConfigNullPrimaryKey, "Primary Key cannot be nullable.");
            ErrorMessages.Add(ConfigMissingDescription, "Description must be specified.");
            ErrorMessages.Add(AttributeDoesNotSupportLocalizedLabels, "The specified attribute does not support localized labels.");
            ErrorMessages.Add(NoLanguageProvisioned, "There is no language provisioned for this organization.");
            ErrorMessages.Add(CannotImportNullStringsForBaseLanguage, "The base language translation string present in worksheet {0}, row {1}, column {2} is null.");
            ErrorMessages.Add(CannotUpdateNonCustomizableString, "The translation string present in worksheet {0}, row {1}, column {2} is not customizable.");
            ErrorMessages.Add(InvalidOrganizationId, "The organization id present in the translations file does not match with the current organization id.");
            ErrorMessages.Add(InvalidTranslationsFile, "The translations file is invalid or does not confirm to the required schema.");
            ErrorMessages.Add(MetadataRecordNotDeletable, "The metadata record being deleted cannot be deleted by the end user");
            ErrorMessages.Add(InvalidImportJobTemplateFile, "The ImportJobTemplate.xml file is invalid.");
            ErrorMessages.Add(InvalidImportJobId, "The requested importjob does not exist.");
            ErrorMessages.Add(MissingCrmAuthenticationToken, "CrmAuthenticationToken is missing.");
            ErrorMessages.Add(IntegratedAuthenticationIsNotAllowed, "Integrated authentication is not allowed.");
            ErrorMessages.Add(RequestIsNotAuthenticated, "Request is not authenticated.");
            ErrorMessages.Add(AsyncOperationTypeIsNotRecognized, "The operation type of the async operation was not recognized.");
            ErrorMessages.Add(FailedToDeserializeAsyncOperationData, "Failed to deserialize async operation data.");
            ErrorMessages.Add(UserSettingsOverMaxPagingLimit, "Paging limit over maximum configured value.");
            ErrorMessages.Add(AsyncNetworkError, "An error occurred while accessing the network.");
            ErrorMessages.Add(AsyncCommunicationError, "A communication error occurred while processing the async operation.");
            ErrorMessages.Add(MissingCrmAuthenticationTokenOrganizationName, "Organization Name must be specified in CrmAuthenticationToken.");
            ErrorMessages.Add(SdkNotEnoughPrivilegeToSetCallerOriginToken, "Caller does not have enough privilege to set CallerOriginToken to the specified value.");
            ErrorMessages.Add(OverRetrievalUpperLimitWithoutPagingCookie, "Over upper limit of records that can be requested without a paging cookie. A paging cookie is required when retrieving a high page number.");
            ErrorMessages.Add(InvalidAllotmentsOverage, "Allotment overage is invalid.");
            ErrorMessages.Add(TooManyConditionsInQuery, "Number of conditions in query exceeded maximum limit.");
            ErrorMessages.Add(TooManyLinkEntitiesInQuery, "Number of link entities in query exceeded maximum limit.");
            ErrorMessages.Add(TooManyConditionParametersInQuery, "Number of parameters in a condition exceeded maximum limit.");
            ErrorMessages.Add(InvalidOneToManyRelationshipForRelatedEntitiesQuery, "An invalid OneToManyRelationship has been specified for RelatedEntitiesQuery. Referenced Entity {0} should be the same as primary entity {1}");
            ErrorMessages.Add(PicklistValueNotUnique, "The picklist value already exists.  Picklist values must be unique.");
            ErrorMessages.Add(UnableToLogOnUserFromUserNameAndPassword, "The specified user name and password can not logon.");
            ErrorMessages.Add(PicklistValueOutOfRange, "The picklist value is out of the range.");
            ErrorMessages.Add(WrongNumberOfBooleanOptions, "Boolean attributes must have exactly two option values.");
            ErrorMessages.Add(BooleanOptionOutOfRange, "Boolean attribute options must have a value of either 0 or 1.");
            ErrorMessages.Add(CannotAddNewBooleanValue, "You cannot add an option to a Boolean attribute.");
            ErrorMessages.Add(CannotAddNewStateValue, "You cannot add state options to a State attribute.");
            ErrorMessages.Add(NoMoreCustomOptionValuesExist, "All available custom option values have been used.");
            ErrorMessages.Add(InsertOptionValueInvalidType, "You can add option values only to picklist and status attributes.");
            ErrorMessages.Add(NewStatusRequiresAssociatedState, "The new status option must have an associated state value.");
            ErrorMessages.Add(NewStatusHasInvalidState, "The state value that was provided for this new status option does not exist.");
            ErrorMessages.Add(CannotDeleteEnumOptionsFromAttributeType, "You can delete options only from picklist and status attributes.");
            ErrorMessages.Add(OptionReorderArrayIncorrectLength, "The array of option values that were provided for reordering does not match the number of options for the attribute.");
            ErrorMessages.Add(ValueMissingInOptionOrderArray, "The options array is missing a value.");
            ErrorMessages.Add(NavPaneOrderValueNotAllowed, "The provided nav pane order value is not allowed");
            ErrorMessages.Add(EntityRelationshipRoleCustomLabelsMissing, "Custom labels must be provided if an entity relationship role has a display option of UseCustomLabels");
            ErrorMessages.Add(NavPaneNotCustomizable, "The nav pane properties for this relationship are not customizable");
            ErrorMessages.Add(EntityRelationshipSchemaNameRequired, "Entity relationships require a name");
            ErrorMessages.Add(EntityRelationshipSchemaNameNotUnique, "A relationship with the specified name already exists. Please specify a unique name.");
            ErrorMessages.Add(CustomReflexiveRelationshipNotAllowedForEntity, "This entity is not valid for a custom reflexive relationship");
            ErrorMessages.Add(EntityCannotBeChildInCustomRelationship, "This entity is either not valid as a child in a custom parental relationship or is already a child in a parental relationship");
            ErrorMessages.Add(ReferencedEntityHasLogicalPrimaryNameField, "This entity has a primary field that is logical and therefore cannot be the referenced entity in a one-to-many relationship");
            ErrorMessages.Add(IntegerValueOutOfRange, "A validation error occurred. An integer provided is outside of the allowed values for this attribute.");
            ErrorMessages.Add(DecimalValueOutOfRange, "A validation error occurred. A decimal value provided is outside of the allowed values for this attribute.");
            ErrorMessages.Add(StringLengthTooLong, "A validation error occurred. A string value provided is too long.");
            ErrorMessages.Add(EntityCannotParticipateInEntityAssociation, "This entity cannot participate in an entity association");
            ErrorMessages.Add(DataMigrationManagerUnknownProblem, "The Data Migration Manager encountered an unknown problem and cannot continue. To try again, restart the Data Migration Manager.");
            ErrorMessages.Add(ImportOperationChildFailure, "One or more of the Import Child Jobs Failed");
            ErrorMessages.Add(AttributeDeprecated, "\"Attribute '{0}' on entity '{1}' is deprecated.\"");
            ErrorMessages.Add(DataMigrationManagerMandatoryUpdatesNotInstalled, "First-time configuration of the Data Migration Manager has been canceled. You will not be able to use the Data Migration Manager until configuration is completed.");
            ErrorMessages.Add(ReferencedEntityMustHaveLookupView, "Referenced entities of a relationship must have a lookup view");
            ErrorMessages.Add(ReferencingEntityMustHaveAssociationView, "Referencing entities of a relationship must have an association view");
            ErrorMessages.Add(CouldNotObtainLockOnResource, "Database resource lock could not be obtained");
            ErrorMessages.Add(SourceAttributeHeaderTooBig, "Column headers must be 160 or fewer characters. Fix the column headers, and then run Data Migration Manager again.");
            ErrorMessages.Add(CannotDeleteDefaultStatusOption, "Default Status options cannot be deleted.");
            ErrorMessages.Add(CannotFindDomainAccount, "Invalid domain account");
            ErrorMessages.Add(CannotUpdateAppDefaultValueForStateAttribute, "The default value for a status (statecode) attribute cannot be updated.");
            ErrorMessages.Add(CannotUpdateAppDefaultValueForStatusAttribute, "The default value for a status reason (statuscode) attribute is not used. The default status reason is set in the associated status (statecode) attribute option.");
            ErrorMessages.Add(InvalidOptionSetSchemaName, "An OptionSet with the specified name already exists. Please specify a unique name.");
            ErrorMessages.Add(ReferencingEntityCannotBeSolutionAware, "Referencing entities in a relationship cannot be a component in a solution.");
            ErrorMessages.Add(ErrorInFieldWidthIncrease, "An error occurred while increasing the field width.");
            ErrorMessages.Add(AsyncOperationCannotCancel, "This system job cannot be canceled.");
            ErrorMessages.Add(AsyncOperationCannotPause, "This system job cannot be paused.");
            ErrorMessages.Add(WorkflowCompileFailure, "An error has occurred during compilation of the workflow.");
            ErrorMessages.Add(UpdatePublishedWorkflowDefinition, "Cannot update a published workflow definition.");
            ErrorMessages.Add(UpdateWorkflowActivation, "Cannot update a workflow activation.");
            ErrorMessages.Add(DeleteWorkflowActivation, "Cannot delete a workflow activation.");
            ErrorMessages.Add(DeleteWorkflowActivationWorkflowDependency, "Cannot delete a workflow dependency associated with a workflow activation.");
            ErrorMessages.Add(DeletePublishedWorkflowDefinitionWorkflowDependency, "Cannot delete a workflow dependency for a published workflow definition.");
            ErrorMessages.Add(UpdateWorkflowActivationWorkflowDependency, "Cannot update a workflow dependency associated with a workflow activation.");
            ErrorMessages.Add(UpdatePublishedWorkflowDefinitionWorkflowDependency, "Cannot update a workflow dependency for a published workflow definition.");
            ErrorMessages.Add(CreateWorkflowActivationWorkflowDependency, "Cannot create a workflow dependency associated with a workflow activation.");
            ErrorMessages.Add(CreatePublishedWorkflowDefinitionWorkflowDependency, "Cannot create a workflow dependency for a published workflow definition.");
            ErrorMessages.Add(WorkflowPublishedByNonOwner, "The workflow cannot be published or unpublished by someone who is not its owner.");
            ErrorMessages.Add(PublishedWorkflowOwnershipChange, "A published workflow can only be assigned to the caller.");
            ErrorMessages.Add(OnlyWorkflowDefinitionOrTemplateCanBePublished, "Only workflow definition or draft workflow template can be published.");
            ErrorMessages.Add(OnlyWorkflowDefinitionOrTemplateCanBeUnpublished, "Only workflow definition or workflow template can be unpublished.");
            ErrorMessages.Add(DeleteWorkflowActiveDefinition, "Cannot delete an active workflow definition.");
            ErrorMessages.Add(WorkflowConditionIncorrectUnaryOperatorFormation, "Incorrect formation of unary operator.");
            ErrorMessages.Add(WorkflowConditionIncorrectBinaryOperatorFormation, "Incorrect formation of binary operator.");
            ErrorMessages.Add(WorkflowConditionOperatorNotSupported, "Condition operator not supported for specified type.");
            ErrorMessages.Add(WorkflowConditionTypeNotSupport, "Invalid type specified on condition.");
            ErrorMessages.Add(WorkflowValidationFailure, "Validation failed on the specified workflow.");
            ErrorMessages.Add(PublishedWorkflowLimitForSkuReached, "This workflow cannot be published because your organization has reached its limit for the number of workflows that can be published at the same time. (There is no limit on the number of draft workflows.) You can publish this workflow by unpublishing a different workflow, or by upgrading your license to a license that supports more workflows.");
            ErrorMessages.Add(NoPrivilegeToPublishWorkflow, "User does not have sufficient privileges to publish workflows.");
            ErrorMessages.Add(WorkflowSystemPaused, "Workflow should be paused by system.");
            ErrorMessages.Add(WorkflowPublishNoActivationParameters, "Automatic workflow cannot be published if no activation parameters have been specified.");
            ErrorMessages.Add(CreateWorkflowDependencyForPublishedTemplate, "Cannot create a workflow dependency for a published workflow template.");
            ErrorMessages.Add(DeleteActiveWorkflowTemplateDependency, "Cannot delete workflow dependency from a published workflow template .");
            ErrorMessages.Add(UpdatePublishedWorkflowTemplate, "Cannot update a published workflow template.");
            ErrorMessages.Add(DeleteWorkflowActiveTemplate, "Cannot delete an active workflow template.");
            ErrorMessages.Add(CustomActivityInvalid, "Invalid custom activity.");
            ErrorMessages.Add(PrimaryEntityInvalid, "Invalid primary entity.");
            ErrorMessages.Add(CannotDeserializeWorkflowInstance, "Workflow instance cannot be deserialized. A possible reason for this failure is a workflow referencing a custom activity that has been unregistered.");
            ErrorMessages.Add(CannotDeserializeXamlWorkflow, "Xaml representing workflow cannot be deserialized into a DynamicActivity.");
            ErrorMessages.Add(CannotDeleteCustomEntityUsedInWorkflow, "Cannot delete entity because it is used in a workflow.");
            ErrorMessages.Add(BulkMailOperationFailed, "The bulk e-mail job completed with {0} failures. The failures might be caused by missing e-mail addresses or because you do not have permission to send e-mail. To find records with missing e-mail addresses, use Advanced Find. If you need increased e-mail permissions, contact your system administrator.");
            ErrorMessages.Add(WorkflowExpressionOperatorNotSupported, "Expression operator not supported for specified type.");
            ErrorMessages.Add(ChildWorkflowNotFound, "This workflow cannot run because one or more child workflows it uses have not been published or have been deleted. Please check the child workflows and try running this workflow again.");
            ErrorMessages.Add(CannotDeleteAttributeUsedInWorkflow, "This attribute cannot be deleted because it is used in one or more workflows. Cancel any system jobs for workflows that use this attribute, then delete or modify any workflows that use the attribute, and then try to delete the attribute again.");
            ErrorMessages.Add(CannotLocateRecordForWorkflowActivity, "A record required by this workflow job could not be found.");
            ErrorMessages.Add(PublishWorkflowWhileActingOnBehalfOfAnotherUserError, "Publishing Workflows while acting on behalf of another user is not allowed.");
            ErrorMessages.Add(CannotDisableInternetMarketingUser, "You cannot disable the Internet Marketing Partner user. This user does not consume a user license and is not charged to your organization.");
            ErrorMessages.Add(CannotSetWindowsLiveIdForInternetMarketingUser, "You cannot change the Windows Live ID for the Internet Marketing Partner user. This user does not consume a user license and is not charged to your organization.");
            ErrorMessages.Add(CannotChangeAccessModeForInternetMarketingUser, "Internet Marketing User is a system user. You cannot change its access mode.");
            ErrorMessages.Add(CannotChangeInvitationStatusForInternetMarketingUser, "Internet Marketing User is a system user. You cannot change its invitation status.");
            ErrorMessages.Add(UiDataGenerationFailed, "There was an error generating the UIData from XAML.");
            ErrorMessages.Add(WorkflowReferencesInvalidActivity, "The workflow definition contains a step that references and invalid custom activity. Remove the invalid references and try again.");
            ErrorMessages.Add(PublishWorkflowWhileImpersonatingError, "Publishing Workflows while impersonating another user is not allowed.");
            ErrorMessages.Add(ExchangeAutodiscoverError, "Autodiscover could not find the Exchange Web Services URL for the specified mailbox. Verify that the mailbox address and the credentials provided are correct and that Autodiscover is enabled and has been configured correctly.");
            ErrorMessages.Add(NonCrmUiWorkflowsNotSupported, "This workflow cannot be created, updated or published because it was created outside the Microsoft Dynamics CRM Web application. Your organization does not allow this type of workflow.");
            ErrorMessages.Add(NotEnoughPrivilegesForXamlWorkflows, "Not enough privileges to complete the operation. Only the deployment administrator can create or update workflows that are created outside the Microsoft Dynamics CRM Web application.");
            ErrorMessages.Add(WorkflowAutomaticallyDeactivated, "The original workflow definition has been deactivated and replaced.");
            ErrorMessages.Add(StepAutomaticallyDisabled, "The original sdkmessageprocessingstep has been disabled and replaced.");
            ErrorMessages.Add(NonCrmUiInteractiveWorkflowNotSupported, "This interactive workflow cannot be created, updated or published because it was created outside the Microsoft Dynamics CRM Web application.");
            ErrorMessages.Add(WorkflowActivityNotSupported, "This workflow cannot be created, updated or published because it's referring unsupported workflow step.");
            ErrorMessages.Add(ExecuteNotOnDemandWorkflow, "Workflow must be marked as on-demand or child workflow.");
            ErrorMessages.Add(ExecuteUnpublishedWorkflow, "Workflow must be in Published state.");
            ErrorMessages.Add(ChildWorkflowParameterMismatch, "This workflow cannot run because arguments provided by parent workflow does not match with the specified parameters in linked child workflow. Check the child workflow reference in parent workflow and try running this workflow again.");
            ErrorMessages.Add(InvalidProcessStateData, "ProcessState is not valid for given ProcessSession instance.");
            ErrorMessages.Add(OutOfScopeSlug, "The data required to display the next dialog page cannot be found. To resolve this issue, contact the dialog owner or the system administrator.");
            ErrorMessages.Add(CrmSqlGovernorDatabaseRequestDenied, "The server is busy and the request was not completed. Try again later.");
            ErrorMessages.Add(InvalidAuthTicket, "The ticket specified for authentication didn't pass validation");
            ErrorMessages.Add(ExpiredAuthTicket, "The ticket specified for authentication is expired");
            ErrorMessages.Add(BadAuthTicket, "The ticket specified for authentication is invalid");
            ErrorMessages.Add(InsufficientAuthTicket, "The ticket specified for authentication didn't meet policy");
            ErrorMessages.Add(OrganizationDisabled, "The CRM organization you are attempting to access is currently disabled.  Please contact your system administrator");
            ErrorMessages.Add(TamperedAuthTicket, "The ticket specified for authentication has been tampered with or invalidated.");
            ErrorMessages.Add(ExpiredKey, "The key specified to compute a hash value is expired, only active keys are valid.  Expired Key : {0}.");
            ErrorMessages.Add(ScaleGroupDisabled, "The specified scalegroup is disabled. Access to organizations in this scalegroup are not allowed.");
            ErrorMessages.Add(SupportLogOnExpired, "Support login is expired");
            ErrorMessages.Add(InvalidPartnerSolutionCustomizationProvider, "Invalid partner solution customization provider type");
            ErrorMessages.Add(MultiplePartnerSecurityRoleWithSameInformation, "More than one security role found for partner user");
            ErrorMessages.Add(MultiplePartnerUserWithSameInformation, "More than one partner user found with same information");
            ErrorMessages.Add(MultipleRootBusinessUnit, "More than one root business unit found");
            ErrorMessages.Add(CannotDeletePartnerWithPartnerSolutions, "Can not delete partner as one or more solutions are associated with it");
            ErrorMessages.Add(CannotDeletePartnerSolutionWithOrganizations, "Can not delete partner solution as one or more organizations are associated with it");
            ErrorMessages.Add(CannotProvisionPartnerSolution, "Can not provision partner solution as it is either already provisioned or going through provisioning.");
            ErrorMessages.Add(CannotActOnBehalfOfAnotherUser, "User does not have the privilege to act on behalf another user.");
            ErrorMessages.Add(SystemUserDisabled, "The system user was disabled therefore the ticket expired.");
            ErrorMessages.Add(PluginDoesNotImplementCorrectInterface, "The plug-in specified does not implement the required interface Microsoft.Xrm.Sdk.IPlugin or Microsoft.Crm.Sdk.IPlugin.");
            ErrorMessages.Add(CannotCreatePluginInstance, "Can not create instance of a plug-in. Verify that plug-in type is not defined as abstract and it has a public constructor supported by CRM SDK.");
            ErrorMessages.Add(CrmLiveGenericError, "An error has occurred while processing your request.");
            ErrorMessages.Add(CrmLiveOrganizationProvisioningFailed, "An error has occurred when provisioning the organization.");
            ErrorMessages.Add(CrmLiveMissingActiveDirectoryGroup, "The specified Active Directory Group does not exist.");
            ErrorMessages.Add(CrmLiveInternalProvisioningError, "An unexpected error happened in the provisioning system.");
            ErrorMessages.Add(CrmLiveQueueItemDoesNotExist, "The specified queue item does not exist in the queue. It may have been deleted or its ID may not have been specified correctly");
            ErrorMessages.Add(CrmLiveInvalidSetupParameter, "The parameter to CRM Online Setup is incorrect or not specified.");
            ErrorMessages.Add(CrmLiveMultipleWitnessServersInScaleGroup, "The ScaleGroup has multiple witness servers specified. There should be only 1 witness server in a scale group.");
            ErrorMessages.Add(CrmLiveMissingServerRolesInScaleGroup, "The scalegroup is missing some required server roles. 1 Witness Server and 2 Sql Servers are required for Provisioning.");
            ErrorMessages.Add(CrmLiveServerCannotHaveWitnessAndDataServerRoles, "A server cannot have both Witness and Data Server Roles.");
            ErrorMessages.Add(IsNotLiveToSendInvitation, "This functionality is not supported, its only available for Online solution.");
            ErrorMessages.Add(MissingOrganizationFriendlyName, "Cannot install CRM without an organization friendly name.");
            ErrorMessages.Add(MissingOrganizationUniqueName, "Cannot install CRM without an organization unique name.");
            ErrorMessages.Add(OfferingCategoryAndTokenNull, "Offer category and Billing Token are both missing, but at least one is required.");
            ErrorMessages.Add(OfferingIdNotSupported, "This version does not support search for offering id.");
            ErrorMessages.Add(OrganizationTakenByYou, "The organization {0} is already purchased by you.");
            ErrorMessages.Add(OrganizationTakenBySomeoneElse, "The organization {0} is already purchased by another customer.");
            ErrorMessages.Add(InvalidTemplate, "The Invitation Email template is not valid");
            ErrorMessages.Add(InvalidUserQuota, "You have reached the maximum number of user quota");
            ErrorMessages.Add(InvalidRole, "You have not assigned roles to this user");
            ErrorMessages.Add(ErrorGeneratingInvitation, "Some Internal error occurred in generating invitation token, Please try again later");
            ErrorMessages.Add(CrmLiveOrganizationUpgradeFailed, "Upgrade Of Crm Organization Failed.");
            ErrorMessages.Add(UnableToSendEmail, "Some Internal error occurred in sending invitation, Please try again later");
            ErrorMessages.Add(InvalidEmail, "Email generated from the template is not valid");
            ErrorMessages.Add(VersionMismatch, "Unsupported version - This is {0} version {1}, but version {2} was requested.");
            ErrorMessages.Add(MissingParameterToMethod, "Missing parameter {0} to method {1}");
            ErrorMessages.Add(InvalidValueForCountryCode, "Account Country/Region code must not be {0}");
            ErrorMessages.Add(InvalidValueForCurrency, "Account currency code must not be {0}");
            ErrorMessages.Add(InvalidValueForLocale, "Account locale code must not be {0}");
            ErrorMessages.Add(CrmLiveSupportOrganizationExistsInScaleGroup, "Only one support organization is allowed in a scalegroup.");
            ErrorMessages.Add(CrmLiveMonitoringOrganizationExistsInScaleGroup, "Only one monitoring organization is allowed in a scalegroup.");
            ErrorMessages.Add(InvalidUserLicenseCount, "Cannot purchase {0} user licenses for the Offering {1}.");
            ErrorMessages.Add(MissingColumn, "The property bag is missing an entry for {0}.");
            ErrorMessages.Add(InvalidResourceType, "The requested action is not valid for resource type {0}.");
            ErrorMessages.Add(InvalidMinimumResourceLimit, "The resource type {0} cannot have a minimum limit of {1}.");
            ErrorMessages.Add(InvalidMaximumResourceLimit, "The resource type {0} cannot have a maximum limit of {1}.");
            ErrorMessages.Add(ConflictingProvisionTypes, "The service component {0} has conflicting provision types.");
            ErrorMessages.Add(InvalidAmountProvided, "The service component {0} cannot have a provide {1} of resource type {2}.");
            ErrorMessages.Add(CrmLiveOrganizationDeleteFailed, "An error has occurred when deleting the organization.");
            ErrorMessages.Add(OnlyDisabledOrganizationCanBeDeleted, "Can not delete enabled organization. Organization must be disabled before it can be deleted.");
            ErrorMessages.Add(CrmLiveOrganizationDetailsNotFound, "Unable to find organization details.");
            ErrorMessages.Add(CrmLiveOrganizationFriendlyNameTooShort, "The organization name provided is too short.");
            ErrorMessages.Add(CrmLiveOrganizationFriendlyNameTooLong, "The organization name provided is too long.");
            ErrorMessages.Add(CrmLiveOrganizationUniqueNameTooShort, "The unique name provided is too short.");
            ErrorMessages.Add(CrmLiveOrganizationUniqueNameTooLong, "The unique name provided is too long.");
            ErrorMessages.Add(CrmLiveOrganizationUniqueNameInvalid, "The unique name provided is not valid.");
            ErrorMessages.Add(CrmLiveOrganizationUniqueNameReserved, "The unique name is already reserved.");
            ErrorMessages.Add(ValueParsingError, "Error parsing parameter {0} of type {1} with value {2}");
            ErrorMessages.Add(InvalidGranularityValue, "The Granularity column value is incorrect. Each rule part must be a name-value pair separated by an equal sign (=). For example: FREQ=Minutes;INTERVAL=15");
            ErrorMessages.Add(CrmLiveInvalidQueueItemSchedule, "The QueueItem has an invalid schedule of start time {0} and end time {1}.");
            ErrorMessages.Add(CrmLiveQueueItemTimeInPast, "A QueueItem cannot be scheduled to start or end in the past.");
            ErrorMessages.Add(CrmLiveUnknownSku, "This Sku specified is not valid.");
            ErrorMessages.Add(ExceedCustomEntityQuota, "The custom entity limit has been reached.");
            ErrorMessages.Add(ImportWillExceedCustomEntityQuota, "This import process is trying to import {0} new custom entities. This would exceed the custom entity limits for this organization.");
            ErrorMessages.Add(OrganizationMigrationUnderway, "Organization migration is already underway.");
            ErrorMessages.Add(CrmLiveInvoicingAccountIdMissing, "Invoicing Account Number (SAP Id) cannot be empty for an invoicing sku.");
            ErrorMessages.Add(CrmLiveDuplicateWindowsLiveId, "A user with this WLID already exists.");
            ErrorMessages.Add(CrmLiveDnsDomainNotFound, "Domain was not found in the DNS table.");
            ErrorMessages.Add(CrmLiveDnsDomainAlreadyExists, "Domain already exists in the DNS table.");
            ErrorMessages.Add(InvalidInteractiveUserQuota, "You have reached the maximum number of interactive/full users.");
            ErrorMessages.Add(InvalidNonInteractiveUserQuota, "You have reached the maximum number of non-interactive users/");
            ErrorMessages.Add(CrmLiveCannotFindExternalMessageProvider, "External Message Provider could not be located for queue item type of: {0}.");
            ErrorMessages.Add(CrmLiveInvalidExternalMessageData, "External Message Data has some invalid data.  Data: {0} External Message: {1}");
            ErrorMessages.Add(CrmLiveOrganizationEnableFailed, "Enabling Organization Failed.");
            ErrorMessages.Add(CrmLiveOrganizationDisableFailed, "Disabling Organization Failed.");
            ErrorMessages.Add(CrmLiveAddOnUnexpectedError, "There was an error contacting the billing system.  Your request cannot be processed at this time.  No changes have been made to your account.  Close this wizard, and try again later.  If the problem persists, please contact our sales organization at 1-877-CRM-CHOICE (276-2464).");
            ErrorMessages.Add(CrmLiveAddOnAddLicenseLimitReached, "Your subscription has the maximum number of user licenses available.  For additional licenses, please contact our sales organization at 1-877-CRM-CHOICE (276-2464).");
            ErrorMessages.Add(CrmLiveAddOnAddStorageLimitReached, "Your subscription has the maximum amount of storage available.  For additional storage, please contact our sales organization at 1-877-CRM-CHOICE (276-2464).");
            ErrorMessages.Add(CrmLiveAddOnRemoveStorageLimitReached, "Your organization has the minimum amount of storage allowed.  You can remove only storage that has been added to your organization, and  is not being used.");
            ErrorMessages.Add(CrmLiveAddOnOrgInNoUpdateMode, "Your changes cannot be processed at this time. Your organization is currently being updated.  No changes have been made to your account.  Close this wizard, and try again later.  If the problem persists, please contact our sales organization at 1-877-CRM-CHOICE (276-2464).");
            ErrorMessages.Add(CrmLiveUnknownCategory, "This Category specified is not valid.");
            ErrorMessages.Add(CrmLiveInvalidInvoicingAccountNumber, "This Invoicing Account Number is not valid because it contains an invalid character.");
            ErrorMessages.Add(CrmLiveAddOnDataChanged, "Due to recent changes you have made to your account, these changes cannot be made at this time.   Close this wizard, and try again later.  If the problem persists, please contact our sales organization at 1-877-CRM-CHOICE (276-2464).");
            ErrorMessages.Add(CrmLiveInvalidEmail, "Invalid email address entered.");
            ErrorMessages.Add(CrmLiveInvalidPhone, "Invalid phone number entered.");
            ErrorMessages.Add(CrmLiveInvalidZipCode, "Invalid zip code entered.");
            ErrorMessages.Add(InvalidAmountFreeResourceLimit, "The resource type {0} cannot have an amount free value of {1}.");
            ErrorMessages.Add(InvalidToken, "The token is invalid.");
            ErrorMessages.Add(CrmLiveRegisterCustomCodeDisabled, "Registration of custom code feature for this organization is disabled.");
            ErrorMessages.Add(CrmLiveExecuteCustomCodeDisabled, "Execution of custom code feature for this organization is disabled.");
            ErrorMessages.Add(CrmLiveInvalidTaxId, "Invalid TaxId entered.");
            ErrorMessages.Add(LivePlatformGeneralEmailError, "An Email Error Occurred");
            ErrorMessages.Add(LivePlatformEmailInvalidTo, "The \"To\" parameter is blank or null");
            ErrorMessages.Add(LivePlatformEmailInvalidFrom, "The \"From\" parameter is blank or null");
            ErrorMessages.Add(LivePlatformEmailInvalidSubject, "The \"Subject\" parameter is blank or null");
            ErrorMessages.Add(LivePlatformEmailInvalidBody, "The \"Body\" parameter is blank or null");
            ErrorMessages.Add(BillingPartnerCertificate, "Could not determine the right Partner certificate to use with Billing.  Issuer: {0}  Subject: {1}  Distinguished matches: [{2}]  Name matches: [{3}]  All valid certificates: [{4}].");
            ErrorMessages.Add(BillingNoSettingError, "No Billing application configuration setting [{0}] was found.");
            ErrorMessages.Add(BillingTestConnectionError, "Billing is not available: Call to IsServiceAvailable returned 'False'.");
            ErrorMessages.Add(BillingTestConnectionException, "Billing TestConnection exception.");
            ErrorMessages.Add(BillingUserPuidNullError, "User Puid is required, but is null.");
            ErrorMessages.Add(BillingUnmappedErrorCode, "Billing error code [{0}] was thrown with exception {1}");
            ErrorMessages.Add(BillingUnknownErrorCode, "Billing error code [{0}] was thrown with exception {1}");
            ErrorMessages.Add(BillingUnknownException, "Billing error was thrown with exception {0}");
            ErrorMessages.Add(BillingRetrieveKeyError, "Could not retrieve Billing session key: \"{0}\"");
            ErrorMessages.Add(BdkEAddressValidationFailure, "{0}  ");
            ErrorMessages.Add(BdkEAgreementAlreadySigned, "{0}  ");
            ErrorMessages.Add(BdkEAuthorizationFailed, "{0}  ");
            ErrorMessages.Add(BdkEAvsFailed, "{0}  ");
            ErrorMessages.Add(BdkEBadCitynameLength, "{0}  ");
            ErrorMessages.Add(BdkEBadStatecodeLength, "{0}  ");
            ErrorMessages.Add(BdkEBadZipcodeLength, "{0}  ");
            ErrorMessages.Add(BdkEBadxml, "{0}  ");
            ErrorMessages.Add(BdkEBannedPaymentInstrument, "{0}  ");
            ErrorMessages.Add(BdkEBannedperson, "{0}  ");
            ErrorMessages.Add(BdkECannotExceedMaxOwnership, "{0}  ");
            ErrorMessages.Add(BdkECountryCurrencyPiMismatch, "{0}  ");
            ErrorMessages.Add(BdkECreditCardExpired, "{0}  ");
            ErrorMessages.Add(BdkEDateExpired, "{0}  ");
            ErrorMessages.Add(BdkEErrorCountrycodeMismatch, "{0}  ");
            ErrorMessages.Add(BdkEErrorCountrycodeRequired, "{0}  ");
            ErrorMessages.Add(BdkEExtraReferralData, "{0}  ");
            ErrorMessages.Add(BdkEGuidExists, "{0}  ");
            ErrorMessages.Add(BdkEInvalidAddressId, "{0}  ");
            ErrorMessages.Add(BdkEInvalidBillableAccountId, "{0}  The specified Billing account is invalid.  Or, although the objectID is of the correct type, the account it identifies does not exist in the system.");
            ErrorMessages.Add(BdkEInvalidBufSize, "{0}  ");
            ErrorMessages.Add(BdkEInvalidCategoryName, "{0}  ");
            ErrorMessages.Add(BdkEInvalidCountryCode, "{0}  ");
            ErrorMessages.Add(BdkEInvalidCurrency, "{0}  ");
            ErrorMessages.Add(BdkEInvalidCustomerType, "{0}  ");
            ErrorMessages.Add(BdkEInvalidDate, "{0}  ");
            ErrorMessages.Add(BdkEInvalidEmailAddress, "{0}  ");
            ErrorMessages.Add(BdkEInvalidFilter, "{0}  ");
            ErrorMessages.Add(BdkEInvalidGuid, "{0}  ");
            ErrorMessages.Add(BdkEInvalidInputToTaxwareOrVerazip, "{0}  ");
            ErrorMessages.Add(BdkEInvalidLocale, "{0}  ");
            ErrorMessages.Add(BdkEInvalidObjectId, "{0}  The Billing system cannot find the object (e.g. account or subscription or offering).");
            ErrorMessages.Add(BdkEInvalidOfferingGuid, "{0}  ");
            ErrorMessages.Add(BdkEInvalidPaymentInstrumentStatus, "{0}  ");
            ErrorMessages.Add(BdkEInvalidPaymentMethodId, "{0}  ");
            ErrorMessages.Add(BdkEInvalidPhoneType, "{0}  ");
            ErrorMessages.Add(BdkEInvalidPolicyId, "{0}  ");
            ErrorMessages.Add(BdkEInvalidReferraldataXml, "{0}  ");
            ErrorMessages.Add(BdkEInvalidStateForCountry, "{0}  ");
            ErrorMessages.Add(BdkEInvalidSubscriptionId, "{0}  The subscription id specified is invalid.  Or, although the objectID is of correct type and also points to a valid account in SCS, the subscription it identifies does not exist in SCS.");
            ErrorMessages.Add(BdkEInvalidTaxExemptType, "{0}  ");
            ErrorMessages.Add(BdkEMegConflict, "{0}  ");
            ErrorMessages.Add(BdkEMultipleCitiesFound, "{0}  ");
            ErrorMessages.Add(BdkEMultipleCountiesFound, "{0}  ");
            ErrorMessages.Add(BdkENonActiveAccount, "{0}  ");
            ErrorMessages.Add(BdkENopermission, "{0}  The calling partner does not have access to this method or when the requester does not have permission to search against the supplied search PUID.");
            ErrorMessages.Add(BdkEObjectRoleLimitExceeded, "{0}  ");
            ErrorMessages.Add(BdkEOfferingAccountCurrencyMismatch, "{0}  ");
            ErrorMessages.Add(BdkEOfferingCountryAccountMismatch, "{0}  ");
            ErrorMessages.Add(BdkEOfferingNotPurchaseable, "{0}  ");
            ErrorMessages.Add(BdkEOfferingPaymentInstrumentMismatch, "{0}  ");
            ErrorMessages.Add(BdkEOfferingRequiresPi, "{0}  ");
            ErrorMessages.Add(BdkEPartnernotinbilling, "{0}  ");
            ErrorMessages.Add(BdkEPaymentProviderConnectionFailed, "{0}  ");
            ErrorMessages.Add(BdkEPrimaryPhoneRequired, "{0}  ");
            ErrorMessages.Add(BdkEPolicyDealCountryMismatch, "{0}  ");
            ErrorMessages.Add(BdkEPuidRoleLimitExceeded, "{0}  ");
            ErrorMessages.Add(BdkERatingFailure, "{0}  ");
            ErrorMessages.Add(BdkERequiredFieldMissing, "{0}  ");
            ErrorMessages.Add(BdkEStateCityInvalid, "{0}  ");
            ErrorMessages.Add(BdkEStateInvalid, "{0}  ");
            ErrorMessages.Add(BdkEStateZipCityInvalid, "{0}  ");
            ErrorMessages.Add(BdkEStateZipCityInvalid2, "{0}  ");
            ErrorMessages.Add(BdkEStateZipCityInvalid3, "{0}  ");
            ErrorMessages.Add(BdkEStateZipCityInvalid4, "{0}  ");
            ErrorMessages.Add(BdkEStateZipCoversMultipleCities, "{0}  ");
            ErrorMessages.Add(BdkEStateZipInvalid, "{0}  ");
            ErrorMessages.Add(BdkETaxidExpdate, "{0}  ");
            ErrorMessages.Add(BdkETokenBlacklisted, "{0}  ");
            ErrorMessages.Add(BdkETokenExpired, "{0}  ");
            ErrorMessages.Add(BdkETokenNotValidForOffering, "{0}  ");
            ErrorMessages.Add(BdkETokenRangeBlacklisted, "{0}  ");
            ErrorMessages.Add(BdkETransBalanceToPiInvalid, "{0}  ");
            ErrorMessages.Add(BdkEUnknownServerFailure, "{0}  Unknown server failure.");
            ErrorMessages.Add(BdkEUnsupportedCharExist, "{0}  ");
            ErrorMessages.Add(BdkEVatidDoesnothaveexpdate, "{0}  ");
            ErrorMessages.Add(BdkEZipCityMissing, "{0}  ");
            ErrorMessages.Add(BdkEZipInvalid, "{0}  Billing zip code error.");
            ErrorMessages.Add(BdkEZipInvalidForEnteredState, "{0}  Billing zip code error.");
            ErrorMessages.Add(BdkEUsageCountForTokenExceeded, "{0}  Billing token is already spent.");
            ErrorMessages.Add(MissingParameterToStoredProcedure, "Missing parameter to stored procedure:  {0}");
            ErrorMessages.Add(SqlErrorInStoredProcedure, "SQL error {0} occurred in stored procedure {1}");
            ErrorMessages.Add(StoredProcedureContext, "CRM error {0} in {1}:{2}");
            ErrorMessages.Add(InvitingOrganizationNotFound, "{0} -- Inviting organization not found -- {1}");
            ErrorMessages.Add(InvitingUserNotInOrganization, "{0} -- Inviting user is not in the inviting organization -- {1}");
            ErrorMessages.Add(InvitedUserAlreadyExists, "{0} -- Invited user is already in an organization -- {1}");
            ErrorMessages.Add(InvitedUserIsOrganization, "{0} -- The user {1} has authentication {2} and is already related to organization {3} with relation id {4}");
            ErrorMessages.Add(InvitationNotFound, "{0} -- Invitation not found or status is not Open -- Token={1} Puid={2} Id={3} Status={4}");
            ErrorMessages.Add(InvitedUserAlreadyAdded, "{0} -- The crm user {1} is already added, but to organization {2} instead of the inviting organization {3}");
            ErrorMessages.Add(InvitationWrongUserOrgRelation, "{0} -- The pre-created userorg relation {1} is wrong.  Authentication {2} is already used by another user");
            ErrorMessages.Add(InvitationIsExpired, "{0} -- Invitation is expired -- Token={1} Puid={2} Id={3} Status={4}");
            ErrorMessages.Add(InvitationIsAccepted, "{0} -- Invitation has already been accepted -- Token={1} Puid={2} Id={3} Status={4}");
            ErrorMessages.Add(InvitationIsRejected, "{0} -- Invitation has already been rejected by the new user-- Token={1} Puid={2} Id={3} Status={4}");
            ErrorMessages.Add(InvitationIsRevoked, "{0} -- Invitation has been revoked by the organization -- Token={1} Puid={2} Id={3} Status={4}");
            ErrorMessages.Add(InvitedUserMultipleTimes, "The CRM user {0} has been invited multiple times.");
            ErrorMessages.Add(InvitationStatusError, "\"The invitation has status {0}.\"");
            ErrorMessages.Add(InvalidInvitationToken, "The invitation token {0} is not correctly formatted.");
            ErrorMessages.Add(InvalidInvitationLiveId, "A user with this e-mail address was not found. Sign in to Windows Live ID with the same e-mail address where you received the invitation.  If you do not have a Windows Live ID, please create one using that e-mail address.");
            ErrorMessages.Add(InvitationSendToSelf, "The invitation cannot be sent to yourself.");
            ErrorMessages.Add(InvitationCannotBeReset, "The invitation for the user cannot be reset.");
            ErrorMessages.Add(UserDataNotFound, "The user data could not be found.");
            ErrorMessages.Add(CannotInviteDisabledUser, "An invitation cannot be sent to a disabled user");
            ErrorMessages.Add(InvitationBillingAdminUnknown, "You are not a billing administrator for this organization and therefore, you cannot send invitations.  You can either contact your billing administrator and ask him or her to send the invitation, or the billing administrator can visit https://billing.microsoft.com and make you a delegate billing administrator. You can then send invitations.");
            ErrorMessages.Add(CannotResetSysAdminInvite, "An invitation cannot be reset for a user if they are the only user that has the System Administrator Role.");
            ErrorMessages.Add(CannotSendInviteToDuplicateWindowsLiveId, "An invitation cannot be sent because there are multiple users with this WLID.");
            ErrorMessages.Add(UserInviteDisabled, "Invitation cannot be sent because user invitations are disabled.");
            ErrorMessages.Add(InvitationOrganizationNotEnabled, "The organization for the invitation is not enabled.");
            ErrorMessages.Add(ClientAuthSignedOut, "The user signed out.");
            ErrorMessages.Add(ClientAuthSyncIssue, "Synchronization between processes failed.");
            ErrorMessages.Add(ClientAuthCanceled, "Authentication was canceled by the user.");
            ErrorMessages.Add(ClientAuthNoConnectivityOffline, "There is no connectivity when running in offline mode.");
            ErrorMessages.Add(ClientAuthNoConnectivity, "There is no connectivity.");
            ErrorMessages.Add(ClientAuthOfflineInvalidCallerId, "Offline SDK calls must be made in the offline user context.");
            ErrorMessages.Add(ConfigDbObjectDoesNotExist, "'{0}' with Value = ({1}) does not exist in MSCRM_CONFIG database");
            ErrorMessages.Add(ConfigDbDuplicateRecord, "Duplicate '{0}' with Value = ({1}) exists in MSCRM_CONFIG database");
            ErrorMessages.Add(ConfigDbCannotDeleteObjectDueState, "Cannot delete '{0}' with Value = ({1}) in this State = ({2}) from MSCRM_CONFIG database");
            ErrorMessages.Add(ConfigDbCascadeDeleteNotAllowDelete, "Cannot delete '{0}' with Value = ({1}) due to child '{2}' references from MSCRM_CONFIG database");
            ErrorMessages.Add(MoveBothWebStoreToPrimary, "Move operation would put both instances on the same server:  Database = {0}  Old Primary = {1}  Old Secondary = {2}  New Secondary = {3}");
            ErrorMessages.Add(MoveBothWebStoreToSecondary, "Move operation would put both instances on the same server:  Database = {0}  Old Primary = {1}  Old Secondary = {2}  New Secondary = {3}");
            ErrorMessages.Add(MoveOrganizationFailedNotDisabled, "Move operation failed because organization {0} is not disabled");
            ErrorMessages.Add(ConfigDbCannotUpdateObjectDueState, "Cannot update '{0}' with Value = ({1}) in this State = ({2}) from MSCRM_CONFIG database");
            ErrorMessages.Add(LiveAdminUnknownObject, "Unknown administration target {0}");
            ErrorMessages.Add(LiveAdminUnknownCommand, "Unknown administration command {0}");
            ErrorMessages.Add(OperationOrganizationNotFullyDisabled, "The {1} operation failed because organization {0} is not fully disabled yet.  Use FORCE to override");
            ErrorMessages.Add(ConfigDbCannotDeleteDefaultOrganization, "The default {0} organization cannot be deleted from the MSCRM_CONFIG database.");
            ErrorMessages.Add(LicenseNotEnoughToActivate, "There are not enough licenses available for the number of users being activated.");
            ErrorMessages.Add(UserNotAssignedRoles, "The user has not been assigned any roles.");
            ErrorMessages.Add(TeamNotAssignedRoles, "The team has not been assigned any roles.");
            ErrorMessages.Add(InvalidLicenseKey, "Invalid license key ({0}).");
            ErrorMessages.Add(NoLicenseInConfigDb, "No license exists in MSCRM_CONFIG database.");
            ErrorMessages.Add(InvalidLicensePid, "Invalid license. Invalid PID (Product Id) ({0}).");
            ErrorMessages.Add(InvalidLicensePidGenCannotLoad, "Invalid license. PidGen.dll cannot be loaded from this path {0}");
            ErrorMessages.Add(InvalidLicensePidGenOtherError, "Invalid license. Cannot generate PID (Product Id) from License key. PidGen error code ({0}).");
            ErrorMessages.Add(InvalidLicenseCannotReadMpcFile, "Invalid license. MPC code cannot be read from MPC.txt file with this path {0}.");
            ErrorMessages.Add(InvalidLicenseMpcCode, "Invalid license. Invalid MPC code ({0}).");
            ErrorMessages.Add(LicenseUpgradePathNotAllowed, "Cannot upgrade to specified license type.");
            ErrorMessages.Add(OrgsInaccessible, "The client access license (CAL) results were not returned because one or more organizations in the deployment cannot be accessed.");
            ErrorMessages.Add(LicenseConfigFileInvalid, "The provided configuration file {0} has invalid formatting.");
            ErrorMessages.Add(LicenseTrialExpired, "The trial installation of Microsoft Dynamics CRM has expired.");
            ErrorMessages.Add(LicenseRegistrationExpired, "The registration period for Microsoft Dynamics CRM has expired.");
            ErrorMessages.Add(LicenseTampered, "The licensing for this installation of Microsoft Dynamics CRM has been tampered with. The system is unusable. Please contact Microsoft Product Support Services.");
            ErrorMessages.Add(NonInteractiveUserCannotAccessUi, "Non-interactive users cannot access the web user interface. Contact your organization system administrator.");
            ErrorMessages.Add(InvalidOrganizationUniqueName, "Invalid organization unique name ({0}). Reason: ({1})");
            ErrorMessages.Add(InvalidOrganizationFriendlyName, "Invalid organization friendly name ({0}). Reason: ({1})");
            ErrorMessages.Add(DeploymentServiceNotAllowSetToThisState, "Deployment Service for {0} allows the state Enabled or Disabled. Cannot set state to {1}.");
            ErrorMessages.Add(DeploymentServiceNotAllowOperation, "Deployment Service for {0} does not allow {1} operation.");
            ErrorMessages.Add(DeploymentServiceCannotChangeStateForDeploymentService, "You cannot change the state of this server because it contains the Deployment Service server role.");
            ErrorMessages.Add(DeploymentServiceRequestValidationFailure, "The Deployment Service cannot process the request because one or more validation checks failed.");
            ErrorMessages.Add(DeploymentServiceOperationIdentifierNotFound, "The Deployment Service could not find a deferred operation having the specified identifier.");
            ErrorMessages.Add(DeploymentServiceCannotDeleteOperationInProgress, "The Deployment Service cannot delete the specified operation because it is currently in progress.");
            ErrorMessages.Add(ConfigureClaimsBeforeIfd, "You must configure claims-based authentication before you can configure an Internet-facing deployment.");
            ErrorMessages.Add(EndUserNotificationTypeNotValidForEmail, "Cannot send Email for EndUserNotification Type: {0}.");
            ErrorMessages.Add(InvalidRecurrenceRuleForBulkDeleteAndDuplicateDetection, "Bulk Delete and Duplicate Detection recurrence must be specified as daily.");
            ErrorMessages.Add(InvalidRecurrenceInterval, "To set recurrence, you must specify an interval that is between 1 and 365.");
            ErrorMessages.Add(QueriesForDifferentEntities, "The Inner and Outer Queries must be for the same entity.");
            ErrorMessages.Add(AggregateInnerQuery, "The Inner Query must not be an aggregate query.");
            ErrorMessages.Add(InvalidDataDescription, "The data description for the visualization is invalid.");
            ErrorMessages.Add(NonPrimaryEntityDataDescriptionFound, "The data description for the visualization is invalid .The data description for the visualization can only have attributes either from the primary entity of the view or the linked entities.");
            ErrorMessages.Add(InvalidPresentationDescription, "The presentation description is invalid.");
            ErrorMessages.Add(SeriesMeasureCollectionMismatch, "Number of series for chart area and number of measure collections for category should be same.");
            ErrorMessages.Add(YValuesPerPointMeasureMismatch, "Number of YValuesPerPoint for series and number of measures for measure collection for category should be same.");
            ErrorMessages.Add(ChartAreaCategoryMismatch, "Number of chart areas and number of categories should be same.");
            ErrorMessages.Add(MultipleSubcategoriesFound, "The data XML for the visualization cannot contain more than two Group By clauses.");
            ErrorMessages.Add(MultipleMeasuresFound, "More than one measure is not supported for charts with subcategory i.e. comparison charts");
            ErrorMessages.Add(MultipleChartAreasFound, "Multiple Chart Areas are not supported.");
            ErrorMessages.Add(InvalidCategory, "Category is invalid. All the measures in the category either do not have same primary group by or are a mix of aggregate and non-aggregate data.");
            ErrorMessages.Add(InvalidMeasureCollection, "Measure collection is invalid. Not all the measures in the measure collection have the same group bys.");
            ErrorMessages.Add(DuplicateAliasFound, "Data Description is invalid. Duplicate alias found.");
            ErrorMessages.Add(EntityNotEnabledForCharts, "Charts are not enabled on the specified primary entity type code: {0}.");
            ErrorMessages.Add(InvalidPageResponse, "Invalid Page Response generated.");
            ErrorMessages.Add(VisualizationRenderingError, "An error occurred while the chart was rendering");
            ErrorMessages.Add(InvalidGroupByAlias, "Data Description is invalid. Same group by alias cannot be used for different attributes.");
            ErrorMessages.Add(MeasureDataTypeInvalid, "The Data Description for the visualization is invalid. The attribute type for one of the non aggregate measures is invalid. Correct the Data Description.");
            ErrorMessages.Add(NoDataForVisualization, "There is no data to create this visualization.");
            ErrorMessages.Add(VisualizationModuleNotFound, "No visualization module found with the given name.");
            ErrorMessages.Add(ImportVisualizationDeletedError, "A saved query visualization with id {0} is marked for deletion in the system. Please publish the customized entity first and then import again.");
            ErrorMessages.Add(ImportVisualizationExistingError, "A saved query visualization with id {0} already exists in the system, and cannot be resused by a new custom entity.");
            ErrorMessages.Add(VisualizationOtcNotFoundError, "Object type code is not specified for the visualization.");
            ErrorMessages.Add(InvalidDundasPresentationDescription, "The presentation description is not valid for dundas chart.");
            ErrorMessages.Add(InvalidWebResourceForVisualization, "The web resource type {0} is not supported for visualizations.");
            ErrorMessages.Add(ChartTypeNotSupportedForComparisonChart, "This chart type is not supported for comparison charts.");
            ErrorMessages.Add(InvalidFetchCollection, "The fetch collection for the visualization is invalid.");
            ErrorMessages.Add(CategoryDataTypeInvalid, "The Data Description for the visualization is invalid. The attribute type for the group by of one of the categories is invalid. Correct the Data Description.");
            ErrorMessages.Add(DuplicateGroupByFound, "Data Description is invalid. Same attribute cannot be used as a group by more than once.");
            ErrorMessages.Add(MultipleMeasureCollectionsFound, "More than one measure collection is not supported for charts with subcategory i.e. comparison charts");
            ErrorMessages.Add(InvalidGroupByColumn, "Group by not allowed on the attribute.");
            ErrorMessages.Add(InvalidFilterCriteriaForVisualization, "The visualization cannot be rendered for the given filter criteria.");
            ErrorMessages.Add(CountSpecifiedWithoutOrder, "The Data Description for the visualization is invalid as it does not specify an order node for the count attribute.");
            ErrorMessages.Add(NoPreviewForCustomWebResource, "This chart uses a custom Web resource. You cannot preview this chart.");
            ErrorMessages.Add(ChartTypeNotSupportedForMultipleSeriesChart, "Series of chart type {0} is not supported for multi-series charts.");
            ErrorMessages.Add(InsufficientColumnsInSubQuery, "One or more columns required by the outer query are not available from the sub-query.");
            ErrorMessages.Add(AggregateQueryRecordLimitExceeded, "AggregateQueryRecordLimit exceeded. Cannot perform this operation.");
            ErrorMessages.Add(CannotAddOrActonBehalfAnotherUserPrivilege, "Act on Behalf of Another User privilege cannot be added or removed.");
            ErrorMessages.Add(HipNoSettingError, "No Hip application configuration setting [{0}] was found.");
            ErrorMessages.Add(HipInvalidCertificate, "Invalid Certificate for using HIP.");
            ErrorMessages.Add(NoSettingError, "No configdb configuration setting [{0}] was found.");
            ErrorMessages.Add(InvalidRecurrencePattern, "Invalid recurrence pattern.");
            ErrorMessages.Add(CreateRecurrenceRuleFailed, "Cannot create the recurrence rule.");
            ErrorMessages.Add(PartialExpansionSettingLoadError, "Failed to retrieve partial expansion settings from the configuration database.");
            ErrorMessages.Add(InvalidCrmDateTime, "Invalid CrmDateTime.");
            ErrorMessages.Add(InvalidAppointmentInstance, "Invalid appointment entity instance.");
            ErrorMessages.Add(InvalidSeriesId, "SeriesId is null or invalid.");
            ErrorMessages.Add(AppointmentDeleted, "The appointment entity instance is already deleted.");
            ErrorMessages.Add(InvalidInstanceTypeCode, "Invalid instance type code.");
            ErrorMessages.Add(OverlappingInstances, "Two instances of the series cannot overlap.");
            ErrorMessages.Add(InvalidSeriesIdOriginalStart, "Invalid seriesid or original start date.");
            ErrorMessages.Add(ValidateNotSupported, "Validate method is not supported for recurring appointment master.");
            ErrorMessages.Add(RecurringSeriesCompleted, "The series has invalid ExpansionStateCode.");
            ErrorMessages.Add(ExpansionRequestIsOutsideExpansionWindow, "The series is already expanded for CutOffWindow.");
            ErrorMessages.Add(InvalidInstanceEntityName, "Invalid instance entity name.");
            ErrorMessages.Add(BookFirstInstanceFailed, "Failed to book first instance.");
            ErrorMessages.Add(InvalidSeriesStatus, "Invalid series status.");
            ErrorMessages.Add(RecurrenceRuleUpdateFailure, "Cannot update a rule that is attached to an existing rule master. Update the rule by using the parent entity.");
            ErrorMessages.Add(RecurrenceRuleDeleteFailure, "Cannot delete a rule that is attached to an existing rule master. Delete the rule by using the parent entity.");
            ErrorMessages.Add(EntityNotRule, "The collection name is not a recurrence rule.");
            ErrorMessages.Add(RecurringSeriesMasterIsLocked, "The recurring series master record is locked by some other process.");
            ErrorMessages.Add(UpdateRecurrenceRuleFailed, "Failed to update the recurrence rule. A corresponding recurrence rule cannot be found.");
            ErrorMessages.Add(InstanceOutsideEffectiveRange, "Cannot perform the operation. An instance is outside of series effective expansion range.");
            ErrorMessages.Add(RecurrenceCalendarTypeNotSupported, "The calendar type is not supported.");
            ErrorMessages.Add(RecurrenceHasNoOccurrence, "The recurrence pattern has no occurrences.");
            ErrorMessages.Add(RecurrenceStartDateTooSmall, "The recurrence pattern start date is invalid.");
            ErrorMessages.Add(RecurrenceEndDateTooBig, "The recurrence pattern end date is invalid.");
            ErrorMessages.Add(OccurrenceCrossingBoundary, "Two occurrences cannot overlap.");
            ErrorMessages.Add(OccurrenceTimeSpanTooBig, "Cannot perform the operation. An instance is outside of series effective expansion range.");
            ErrorMessages.Add(OccurrenceSkipsOverForward, "Cannot reschedule an occurrence of the recurring appointment if it skips over a later occurrence of the same appointment.");
            ErrorMessages.Add(OccurrenceSkipsOverBackward, "Cannot reschedule an occurrence of the recurring appointment if it skips over an earlier occurrence of the same appointment.");
            ErrorMessages.Add(InvalidDaysInFebruary, "February 29 can occur only when pattern start date is in a leap year.");
            ErrorMessages.Add(InvalidOccurrenceNumber, "The effective end date of the series cannot be earlier than today. Select a valid occurrence number.");
            ErrorMessages.Add(InvalidNumberOfPartitions, "You cannot delete audit data in the partitions that are currently in use, or delete the partitions that are created for storing future audit data.");
            ErrorMessages.Add(InvalidElementFound, "A dashboard Form XML cannot contain element: {0}.");
            ErrorMessages.Add(MaximumControlsLimitExceeded, "The dashboard Form XML contains more than the maximum allowed number of control elements: {0}.");
            ErrorMessages.Add(UserViewsOrVisualizationsFound, "A system dashboard cannot contain user views and visualizations.");
            ErrorMessages.Add(InvalidAttributeFound, "A dashboard Form XML cannot contain attribute: {0}.");
            ErrorMessages.Add(MultipleFormElementsFound, "A dashboard Form XML can contain only one form element.");
            ErrorMessages.Add(NullDashboardName, "The name of a dashboard cannot be null.");
            ErrorMessages.Add(InvalidFormType, "The type of the form must be set to {0} in the Form XML.");
            ErrorMessages.Add(InvalidControlClass, "The dashboard Form XML cannot contain controls elements with class id: {0}.");
            ErrorMessages.Add(ImportDashboardDeletedError, "A dashboard with the same id is marked as deleted in the system. Please first publish the system form entity and import again.");
            ErrorMessages.Add(PersonalReportFound, "A system dashboard cannot contain personal reports.");
            ErrorMessages.Add(ObjectAlreadyExists, "An object with id {0} already exists. Please change the id and try again.");
            ErrorMessages.Add(EntityTypeSpecifiedForDashboard, "An entity type cannot be specified for a dashboard.");
            ErrorMessages.Add(UnrestrictedIFrameInUserDashboard, "A user dashboard Form XML cannot have Security = false.");
            ErrorMessages.Add(MultipleLabelsInUserDashboard, "A user dashboard can have at most one label for a form element.");
            ErrorMessages.Add(UnsupportedDashboardInEditor, "The dashboard could not be opened.");
            ErrorMessages.Add(CannotRemoveComponentFromDefaultSolution, "A Solution Component cannot be removed from the Default Solution.");
            ErrorMessages.Add(InvalidSolutionUniqueName, "Invalid character specified for solution unique name. Only characters within the ranges [A-Z], [a-z], [0-9] or _ are allowed. The first character may only be in the ranges [A-Z], [a-z] or _.");
            ErrorMessages.Add(CannotUndeleteLabel, "Attempting to undelete a label that is not marked as delete.");
            ErrorMessages.Add(ErrorReactivatingComponentInstance, "After undeleting a label, there is no underlying label to reactivate.");
            ErrorMessages.Add(CannotDeleteRestrictedSolution, "Attempting to delete a restricted solution.");
            ErrorMessages.Add(CannotDeleteRestrictedPublisher, "Attempting to delete a restricted publisher.");
            ErrorMessages.Add(ImportRestrictedSolutionError, "Solution ID provided is restricted and cannot be imported.");
            ErrorMessages.Add(CannotSetSolutionSystemAttributes, "System attributes ({0}) cannot be set outside of installation or upgrade.");
            ErrorMessages.Add(CannotUpdateDefaultSolution, "Default solution attribute{0} {1} can only be set on installation or upgrade.  The value{0} cannot be modified.");
            ErrorMessages.Add(CannotUpdateRestrictedSolution, "Restricted solution ({0}) cannot be updated.");
            ErrorMessages.Add(CannotAddWorkflowActivationToSolution, "Cannot add Workflow Activation to solution ");
            ErrorMessages.Add(CannotQueryBaseTableWithAggregates, "Invalid query on base table.  Aggregates cannot be included in base table query.");
            ErrorMessages.Add(InvalidStateTransition, "The {0} entity or component has attempted to transition from an invalid state: {1}.");
            ErrorMessages.Add(CannotUpdateUnpublishedDeleteInstance, "The component that you are trying to update has been deleted.");
            ErrorMessages.Add(UnsupportedComponentOperation, "{0} is not recognized as a supported operation.");
            ErrorMessages.Add(InvalidCreateOnProtectedComponent, "You cannot create {0} {1}. Creation cannot be performed when {0} is managed.");
            ErrorMessages.Add(InvalidUpdateOnProtectedComponent, "You cannot update {0} {1}. Updates cannot be performed when {0} is managed.");
            ErrorMessages.Add(InvalidDeleteOnProtectedComponent, "You cannot delete {0} {1}. Deletion cannot be performed when {0} is managed.");
            ErrorMessages.Add(InvalidPublishOnProtectedComponent, "You cannot publish {0} {1}. Publish cannot be performed when {0} is managed.");
            ErrorMessages.Add(CannotAddNonCustomizableComponent, "The component {0} {1} cannot be added to the solution because it is not customizable");
            ErrorMessages.Add(CannotOverwriteActiveComponent, "A managed solution cannot overwrite the {0} component with Id={1} which has an unmanaged base instance.  The most likely scenario for this error is that an unmanaged solution has installed a new unmanaged {0} component on the target system, and now a managed solution from the same publisher is trying to install that same {0} component as managed.  This will cause an invalid layering of solutions on the target system and is not allowed.");
            ErrorMessages.Add(CannotUpdateRestrictedPublisher, "Restricted publisher ({0}) cannot be updated.");
            ErrorMessages.Add(CannotAddSolutionComponentWithoutRoots, "This item is not a valid solution component. For more information about solution components, see the Microsoft Dynamics CRM SDK documentation.");
            ErrorMessages.Add(ComponentDefinitionDoesNotExists, "No component definition exists for the component type {0}.");
            ErrorMessages.Add(DependencyAlreadyExists, "A {0} dependency already exists between {1}({2}) and {3}({4}).  Cannot also create {5} dependency.");
            ErrorMessages.Add(DependencyTableNotEmpty, "The dependency table must be empty for initialization to complete successfully.");
            ErrorMessages.Add(InvalidPublisherUniqueName, "Publisher uniquename is required.");
            ErrorMessages.Add(CannotUninstallWithDependencies, "Solution dependencies exist, cannot uninstall.");
            ErrorMessages.Add(InvalidSolutionVersion, "An invalid solution version was specified.");
            ErrorMessages.Add(CannotDeleteInUseComponent, "The {0}({1}) component cannot be deleted because it is referenced by {2} other components. For a list of referenced components, use the RetrieveDependenciesForDeleteRequest.");
            ErrorMessages.Add(CannotUninstallReferencedProtectedSolution, "This solution cannot be uninstalled because the '{0}' with id '{1}'  is required by the '{2}' solution. Uninstall the {2} solution and try again.");
            ErrorMessages.Add(CannotRemoveComponentFromSolution, "Cannot find solution component {0} {1} in solution {2}.");
            ErrorMessages.Add(RestrictedSolutionName, "The solution unique name '{0}' is restricted and can only be used by internal solutions.");
            ErrorMessages.Add(SolutionUniqueNameViolation, "The solution unique name '{0}' is already being used and cannot be used again.");
            ErrorMessages.Add(CannotUpdateManagedSolution, "Cannot update solution '{0}' because it is a managed solution.");
            ErrorMessages.Add(DependencyTrackingClosed, "Invalid attempt to process a dependency after the current transaction context has been closed.");
            ErrorMessages.Add(GenericManagedPropertyFailure, "The evaluation of the current component(name={0}, id={1}) in the current operation ({2}) failed during managed property evaluation of condition: {3}");
            ErrorMessages.Add(CombinedManagedPropertyFailure, "The evaluation of the current component(name={0}, id={1}) in the current operation ({2}) failed during at least one managed property evaluations: {3}");
            ErrorMessages.Add(ReportImportCategoryOptionNotFound, "A category option for the reports was not found.");
            ErrorMessages.Add(RequiredChildReportHasOtherParent, "A category option for the reports was not found.");
            ErrorMessages.Add(InvalidManagedPropertyException, "Managed property {0} does not contain enough information to be created.  Please provide (assembly, class), or (entity, attribute) or set the managed property to custom.");
            ErrorMessages.Add(OnlyOwnerCanSetManagedProperties, "Cannot import component {0}: {1}. The publisher of the solution that is being imported does not match the publisher of the solution that installed this component.");
            ErrorMessages.Add(CannotDeleteMetadata, "The '{2}' operation on the current component(name='{0}', id='{1}') failed during managed property evaluation of condition: '{3}'");
            ErrorMessages.Add(CannotUpdateReadOnlyPublisher, "Attempting to update a readonly publisher.");
            ErrorMessages.Add(CannotSelectReadOnlyPublisher, "Attempting to  select a readonly publisher for solution.");
            ErrorMessages.Add(CannotRemoveComponentFromSystemSolution, "A Solution Component cannot be removed from the System Solution.");
            ErrorMessages.Add(InvalidDependency, "The {2} component {1} (Id={0}) does not exist.  Failure trying to associate it with {3} (Id={4}) as a dependency. Missing dependency lookup type = {5}.");
            ErrorMessages.Add(InvalidDependencyFetchXml, "The FetchXml ({2}) is invalid.  Failure while calculating dependencies for {1} (Id={0}).");
            ErrorMessages.Add(CannotModifyReportOutsideSolutionIfManaged, "Managed solution cannot update reports which are not present in solution package.");
            ErrorMessages.Add(SharePointUnableToAddUserToGroup, "Microsoft Dynamics CRM cannot add this user {0} to the group {1} in SharePoint. Verify that the information for this user and group are correct and that the group exists in SharePoint, and then try again.");
            ErrorMessages.Add(SharePointUnableToRemoveUserFromGroup, "Unable to remove user {0} from group {1} in SharePoint.");
            ErrorMessages.Add(SharePointSiteNotPresentInSharePoint, "Site {0} does not exists in SharePoint.");
            ErrorMessages.Add(SharePointUnableToRetrieveGroup, "Unable to retrieve the group {0} from SharePoint.");
            ErrorMessages.Add(SharePointUnableToAclSiteWithPrivilege, "Unable to ACL site {0} with privilege {1} in SharePoint.");
            ErrorMessages.Add(SharePointUnableToAclSite, "Unable to ACL site {0} in SharePoint.");
            ErrorMessages.Add(SharePointUnableToCreateSiteGroup, "Unable to create site group {0} in SharePoint.");
            ErrorMessages.Add(SharePointSiteCreationFailure, "Failed to create the site {0} in SharePoint.");
            ErrorMessages.Add(SharePointTeamProvisionJobAlreadyExists, "A system job to provision the selected team is pending. Any changes made to the team record before this system job starts will be applied to this system job.");
            ErrorMessages.Add(SharePointRoleProvisionJobAlreadyExists, "A system job to provision the selected security role is pending. Any changes made to the security role record before this system job starts will be applied to this system job.");
            ErrorMessages.Add(SharePointSiteWideProvisioningJobFailed, "SharePoint provisioning job has failed.");
            ErrorMessages.Add(DataTypeMismatchForLinkedAttribute, "Data type mismatch found for linked attribute.");
            ErrorMessages.Add(InvalidEntityForLinkedAttribute, "Not a valid entity for linked attribute.");
            ErrorMessages.Add(AlreadyLinkedToAnotherAttribute, "Given linked attribute is alreadly linked to other attribute.");
            ErrorMessages.Add(DocumentManagementDisabled, "Document Management has been disabled for this organization.");
            ErrorMessages.Add(DefaultSiteCollectionUrlChanged, "Default site collection url has been changed this organization after this operation was created.");
            ErrorMessages.Add(RibbonImportHidingBasicHomeTab, "The definition of the ribbon being imported will remove the Microsoft Dynamics CRM home tab. Include a home tab definition, or a ribbon will not be displayed in areas of the application that display the home tab.");
            ErrorMessages.Add(RibbonImportInvalidPrivilegeName, "The RibbonDiffXml in this solution contains a reference to an invalid privilege: {0}. Update the RibbonDiffXml to reference a valid privilege and try importing again.");
            ErrorMessages.Add(RibbonImportEntityNotSupported, "The solution cannot be imported because the {0} entity contains a Ribbon definition, which is not supported for that entity. Remove the RibbonDiffXml node from the entity definition and try to import again.");
            ErrorMessages.Add(RibbonImportDependencyMissingEntity, "The ribbon item '{0}' is dependent on entity {1}.");
            ErrorMessages.Add(RibbonImportDependencyMissingRibbonElement, "The ribbon item '{0}' is dependent on <{1} Id=\"{2}\" />.");
            ErrorMessages.Add(RibbonImportDependencyMissingWebResource, "The ribbon item '{0}' is dependent on Web resource id='{1}'.");
            ErrorMessages.Add(RibbonImportDependencyMissingRibbonControl, "The ribbon item '{0}' is dependent on ribbon control id='{1}'.");
            ErrorMessages.Add(RibbonImportModifyingTopLevelNode, "Ribbon customizations cannot be made to the following top-level ribbon nodes: <Ribbon>, <ContextualGroups>, and <Tabs>.");
            ErrorMessages.Add(RibbonImportLocationAndIdDoNotMatch, "CustomAction Id '{0}' cannot override '{1}' because '{2}' does not match the CustomAction Location value.");
            ErrorMessages.Add(RibbonImportHidingJewel, "Ribbon customizations cannot hide the <Jewel> node. Any ribbon customization that hides this node is ignored during import and will not be exported.");
            ErrorMessages.Add(RibbonImportDuplicateElementId, "The ribbon element with the Id:{0} cannot be imported because an existing ribbon element with the same Id already exists.");
            ErrorMessages.Add(WebResourceInvalidType, "Invalid web resource type specified.");
            ErrorMessages.Add(WebResourceEmptySilverlightVersion, "Silverlight version cannot be empty for silverlight web resources.");
            ErrorMessages.Add(WebResourceInvalidSilverlightVersion, "Silverlight version can only be of the format xx.xx[.xx.xx].");
            ErrorMessages.Add(WebResourceContentSizeExceeded, "Webresource content size is too big.");
            ErrorMessages.Add(WebResourceDuplicateName, "A webresource with the same name already exists. Use a different name.");
            ErrorMessages.Add(WebResourceEmptyName, "Webresource name cannot be null or empty.");
            ErrorMessages.Add(WebResourceNameInvalidCharacters, "Web resource names may only include letters, numbers, periods, and nonconsecutive forward slash characters.");
            ErrorMessages.Add(WebResourceNameInvalidPrefix, "Webresource name does not contain a valid prefix.");
            ErrorMessages.Add(WebResourceNameInvalidFileExtension, "A Web resource cannot have the following file extensions: .aspx, .ascx, .asmx or .ashx.");
            ErrorMessages.Add(WebResourceImportMissingFile, "The file for this Web resource does not exist in the solution file.");
            ErrorMessages.Add(WebResourceImportError, "An error occurred while importing a Web resource. Try importing this solution again. For further assistance, contact Microsoft Dynamics CRM technical support.");
            ErrorMessages.Add(InvalidActivityOwnershipTypeMask, "A custom entity defined as an activity must be user or team owned.");
            ErrorMessages.Add(ActivityCannotHaveRelatedActivities, "A custom entity defined as an activity must not have a relationship with Activities.");
            ErrorMessages.Add(CustomActivityMustHaveOfflineAvailability, "A custom entity defined as an activity must have Offline Availability.");
            ErrorMessages.Add(ActivityMustHaveRelatedNotes, "A custom entity defined as an activity must have a relationship to Notes by default.");
            ErrorMessages.Add(CustomActivityCannotBeMailMergeEnabled, "A custom entity defined as an activity already cannot have MailMerge enabled.");
            ErrorMessages.Add(InvalidCustomActivityType, "A custom entity defined as an activity must be of communicaton activity type.");
            ErrorMessages.Add(ActivityMetadataUpdate, "The metadata specified for activity is invalid.");
            ErrorMessages.Add(InvalidPrimaryFieldForActivity, "A custom entity defined as an activity cannot have primary attribute other than subject.");
            ErrorMessages.Add(CannotDeleteNonLeafNode, "Only a leaf statement can be deleted. This statement is parenting some other statement.");
            ErrorMessages.Add(DuplicateUiStatementRootsFound, "There can be only one root statement for a given uiscript.");
            ErrorMessages.Add(ErrorUpdateStatementTextIsReferenced, "You cannot update this UI script statement text because it is being referred to by one or more published ui scripts.");
            ErrorMessages.Add(ErrorDeleteStatementTextIsReferenced, "You cannot delete the UI script statement text because it is being referred by one or more ui script statements.");
            ErrorMessages.Add(ErrorScriptSessionCannotCreateForDraftScript, "You cannot create a UI script session for a UI script which is not published.");
            ErrorMessages.Add(ErrorScriptSessionCannotUpdateForDraftScript, "You cannot update a UI script session for a UI script which is not published.");
            ErrorMessages.Add(ErrorScriptLanguageNotInstalled, "The language specified is not supported in your CRM install. Please check with your system administrator on the list of \"enabled\" languages.");
            ErrorMessages.Add(ErrorScriptInitialStatementNotInScript, "The initial statement for this script does not belong to this script.");
            ErrorMessages.Add(ErrorScriptInitialStatementNotRoot, "The initial statement should the root statement and cannot have a previous statement set.");
            ErrorMessages.Add(ErrorScriptCannotDeletePublishedScript, "You cannot delete a UI script that is published. You must unpublish it first.");
            ErrorMessages.Add(ErrorScriptPublishMissingInitialStatement, "The selected UI script cannot be published. Provide a value for \"First statement number\" and try to publish again.");
            ErrorMessages.Add(ErrorScriptPublishMalformedScript, "The selected UI script cannot be published. The UI script contains one or more paths which do not end in an end-script or next-script action node. Correct the paths and try to publish again.");
            ErrorMessages.Add(ErrorScriptUnpublishActiveScript, "This script is in use and has active sessions (status-reason=incomplete). Please terminate the active sessions (i.e. status-reason=cancelled) and try to unpublish again.");
            ErrorMessages.Add(ErrorScriptSessionCannotSetStateForDraftScript, "You cannot set the state of a UI script session for a UI script which is not published.");
            ErrorMessages.Add(ErrorScriptStatementResponseTypeOnlyForPrompt, "You cannot associate the response control type for a statement which is not a prompt.");
            ErrorMessages.Add(ErrorStatementOnlyForDraftScript, "You cannot create a UI script statement for a UI script which is not draft.");
            ErrorMessages.Add(ErrorStatementDeleteOnlyForDraftScript, "You cannot delete a UI script statement for a UI script which is not draft.");
            ErrorMessages.Add(ErrorInvalidUiScriptImportFile, "File type is not supported. Select an xml file for import.");
            ErrorMessages.Add(ErrorScriptFileParse, "Error occurred while parsing the XML file.");
            ErrorMessages.Add(ErrorScriptCannotUpdatePublishedScript, "You cannot update a UI script that is published. You must unpublish it first.");
            ErrorMessages.Add(ErrorInvalidFileNameChars, "The Microsoft Excel file name cannot contain the following characters: *  \\ : > < | ? \" /. Rename the file using valid characters, and try again.");
            ErrorMessages.Add(ErrorMimeTypeNullOrEmpty, "The MimeType property value of the UploadFromBase64DataUIScriptRequest method is null or empty. Specify a valid property value, and try again.");
            ErrorMessages.Add(ErrorImportInvalidForPublishedScript, "You cannot save data to a published UI script. Unpublish the UI script, and try again.");
            ErrorMessages.Add(UiScriptIdentifierDuplicate, "A variable or input argument with the same name already exists. Choose a different name, and try again.");
            ErrorMessages.Add(UiScriptIdentifierInvalid, "The variable or input argument name is invalid. The name can only contain '_', numerical, and alphabetical characters. Choose a different name, and try again.");
            ErrorMessages.Add(UiScriptIdentifierInvalidLength, "The variable or input argument name is too long. Choose a smaller name, and try again.");
            ErrorMessages.Add(ErrorNoQueryData, "An error has occurred. Either the data does not exist or you do not have sufficient privileges to view the data. Contact your system administrator for help.");
            ErrorMessages.Add(ErrorUiScriptPromptMissing, "The dialog that is being activated has no prompt/response.");
            ErrorMessages.Add(SharePointUrlHostValidator, "The URL cannot be resolved into an IP.");
            ErrorMessages.Add(SharePointCrmDomainValidator, "The SharePoint and Microsoft Dynamics CRM Servers are on different domains. Please ensure a trust relationship between the two domains.");
            ErrorMessages.Add(SharePointServerDiscoveryValidator, "The URL is incorrect or the site is not running.");
            ErrorMessages.Add(SharePointServerVersionValidator, "The SharePoint Site Collection must be running a supported version of Microsoft Office SharePoint Server or Microsoft Windows SharePoint Services. Please refer the implementation guide.");
            ErrorMessages.Add(SharePointSiteCollectionIsAccessibleValidator, "The URL is incorrect or the site is not running.");
            ErrorMessages.Add(SharePointUrlIsRootWebValidator, "The URL is not valid. The URL must be a valid site collection and cannot include a subsite. The URL must be in a valid form, such as http://SharePointServer/sites/CrmSite.");
            ErrorMessages.Add(SharePointSitePermissionsValidator, "The current user does not have the appropriate privileges. You must be a SharePoint site administrator on the SharePoint site.");
            ErrorMessages.Add(SharePointServerLanguageValidator, "Microsoft Dynamics CRM and Microsoft Office SharePoint Server must have the same base language.");
            ErrorMessages.Add(SharePointCrmGridIsInstalledValidator, "The Microsoft Dynamics CRM Grid component must be installed on the SharePoint server. This component is required for SharePoint integration to work correctly.");
            ErrorMessages.Add(SharePointErrorRetrieveAbsoluteUrl, "An error occurred while retrieving the absolute and site collection url for a SharePoint object.");
            ErrorMessages.Add(SharePointInvalidEntityForValidation, "Entity Does not support SharePoint Url Validation.");
            ErrorMessages.Add(DocumentManagementIsDisabled, "Document Management is not enabled for this Organization.");
            ErrorMessages.Add(DocumentManagementNotEnabledNoPrimaryField, "Document management could not be enabled because a primary field is not defined for this entity.");
            ErrorMessages.Add(SharePointErrorAbsoluteUrlClipped, "The URL exceeds the maximum number of 256 characters. Use shorter names for sites and folders, and try again.");
            ErrorMessages.Add(SiteMapXsdValidationError, "Sitemap xml failed XSD validation with the following error: '{0}' at line {1} position {2}.");
            ErrorMessages.Add(LinkedAttributeCannotBeSecured, "The linked attribute cannot be a secured attribute.");
            ErrorMessages.Add(CannotSecureAttribute, "This field is not securable");
            ErrorMessages.Add(AttributePrivilegeCreateIsMissing, "The user does not have create permissions to a secured field. The requested operation could not be completed.");
            ErrorMessages.Add(AttributePermissionUpdateIsMissingDuringShare, "The user does not have update permissions to a secured field. The requested operation could not be completed.");
            ErrorMessages.Add(AttributePermissionReadIsMissing, "The user does not have read permissions to a secured field. The requested operation could not be completed.");
            ErrorMessages.Add(CannotRemoveSysAdminProfileFromSysAdminUser, "The Sys Admin Profile cannot be removed from a user with a Sys Admin Role");
            ErrorMessages.Add(QueryContainedSecuredAttributeWithoutAccess, "The Query contained a secured attribute to which the caller does not have access");
            ErrorMessages.Add(AttributePermissionUpdateIsMissingDuringUpdate, "The user doesn't have AttributePrivilegeUpdate and not granted shared access for a secured attribute during update operation");
            ErrorMessages.Add(AttributeNotSecured, "One or more fields are not enabled for field level security. Field level security is not enabled until you publish the customizations.");
            ErrorMessages.Add(AttributeSharingCreateShouldSetReadOrAndUpdateAccess, "You must set read and/or update access when you share a secured attribute. Attribute ID: {0}");
            ErrorMessages.Add(AttributeSharingUpdateInvalid, "Both readAccess and updateAccess are false: call Delete instead of Update.");
            ErrorMessages.Add(AttributeSharingCreateDuplicate, "Attribute has already been shared.");
            ErrorMessages.Add(AdminProfileCannotBeEditedOrDeleted, "The System Administrator field security profile cannot be modified or deleted.");
            ErrorMessages.Add(AttributePrivilegeInvalidToUnsecure, "You must have sufficient permissions for a secured field before you can change its field level security.");
            ErrorMessages.Add(RequireValidImportMapForUpdate, "The update operation cannot be completed because the import map used for the update is invalid.");
            ErrorMessages.Add(InvalidFormatForUpdateMode, "The file that you uploaded is invalid and cannot be used for updating records.");
            ErrorMessages.Add(MaximumCountForUpdateModeExceeded, "In an update operation, you can import only one file at a time.");
            ErrorMessages.Add(RecordResolutionFailed, "The record could not be updated because the original record no longer exists in Microsoft Dynamics CRM.");
            ErrorMessages.Add(InvalidOperationForDynamicList, "This action is not available for a dynamic marketing list.");
            ErrorMessages.Add(QueryNotValidForStaticList, "Query cannot be specified for a static list.");
            ErrorMessages.Add(LockStatusNotValidForDynamicList, "Lock Status cannot be specified for a dynamic list.");
            ErrorMessages.Add(CannotCopyStaticList, "This action is valid only for dynamic list.");
            ErrorMessages.Add(CannotDeleteSystemForm, "System forms cannot be deleted.");
            ErrorMessages.Add(CannotUpdateSystemEntityIcons, "System entity icons cannot be updated.");
            ErrorMessages.Add(FallbackFormDeletion, "You cannot delete this form because it is the only fallback form of type {0} for the {1} entity. Each entity must have at least one fallback form for each form type.");
            ErrorMessages.Add(SystemFormImportMissingRoles, "The unmanaged solution you are importing has displaycondition XML attributes that refer to security roles that are missing from the target system. Any displaycondition attributes that refer to these security roles will be removed.");
            ErrorMessages.Add(SystemFormCopyUnmatchedEntity, "The entity for the Target and the SourceId must match.");
            ErrorMessages.Add(SystemFormCopyUnmatchedFormType, "The form type of the SourceId is not valid for the Target entity.");
            ErrorMessages.Add(SystemFormCreateWithExistingLabel, "The label '{0}', id: '{1}' already exists. Supply unique labelid values.");
            ErrorMessages.Add(RuntimeRibbonXmlValidation, "The most recent customized ribbon for a tab on this page cannot be generated. The out-of-box version of the ribbon is displayed instead.");
            ErrorMessages.Add(InitializeErrorNoReadOnSource, "The operation could not be completed because you donot have read access on some of the fields in source record.");
            ErrorMessages.Add(NoRollupAttributesDefined, "For rollup to succeed atleast one rollup attribute needs to be associated with the goal metric");
            ErrorMessages.Add(GoalPercentageAchievedValueOutOfRange, "The percentage achieved value has been set to 0 because the calculated value is not in the allowed range.");
            ErrorMessages.Add(InvalidRollupQueryAttributeSet, "A Rollup Query cannot be set for a Rollup Field that is not defined in the Goal Metric.");
            ErrorMessages.Add(InvalidGoalManager, "The manager of a goal can only be a user and not a team.");
            ErrorMessages.Add(InactiveRollupQuerySetOnGoal, "An inactive rollup query cannot be set on a goal.");
            ErrorMessages.Add(InactiveMetricSetOnGoal, "An inactive metric cannot be set on a goal.");
            ErrorMessages.Add(MetricEntityOrFieldDeleted, "The entity or field that is referenced in the goal metric is not valid");
            ErrorMessages.Add(LanguageProvisioningSrsDataConnectorNotInstalled, "The Microsoft Dynamics CRM Reporting Extensions must be installed before the language can be provisioned for this organization.");
            ErrorMessages.Add(BidsInvalidConnectionString, "Input connection string is invalid. Usage: ServerUrl[;OrganizationName][;HomeRealmUrl]");
            ErrorMessages.Add(BidsInvalidUrl, "Input url {0} is invalid.");
            ErrorMessages.Add(BidsServerConnectionFailed, "Failed to connect to server {0}.");
            ErrorMessages.Add(BidsAuthenticationError, "An error occured while authenticating with server {0}.");
            ErrorMessages.Add(BidsNoOrganizationsFound, "No organizations found for the user.");
            ErrorMessages.Add(BidsOrganizationNotFound, "Organization {0} cannot be found for the user.");
            ErrorMessages.Add(BidsAuthenticationFailed, "Authentication failed when trying to connect to server {0}. The username or password is incorrect.");
            ErrorMessages.Add(TransactionNotSupported, "The operation that you are trying to perform does not support transactions.");
            ErrorMessages.Add(IndexOutOfRange, "The index {0} is out of range for {1}. Number of elements present are {2}.");
            ErrorMessages.Add(InvalidAttribute, "Attribute {0} cannot be found for entity {1}.");
            ErrorMessages.Add(MultiValueParameterFound, "Fetch xml parameter {0} cannot obtain multiple values. Change report parameter {0} to single value parameter and try again.");
            ErrorMessages.Add(QueryParameterNotUnique, "Query parameter {0} must be defined only once within the data set.");
            ErrorMessages.Add(InvalidEntity, "Entity {0} cannot be found.");
            ErrorMessages.Add(UnsupportedAttributeType, "Attribute type {0} is not supported. Remove attribute {1} from the query and try again.");
            ErrorMessages.Add(FetchDataSetQueryTimeout, "The fetch data set query timed out after {0} seconds. Increase the query timeout, and try again.");
        }

        public static string GetErrorMessage(int hResult)
        {
            var errorMessage = ErrorMessages[hResult] as string;
            if (string.IsNullOrEmpty(errorMessage))
            {
                errorMessage = "Server was unable to process request.";
            }

            return errorMessage;
        }
    }
}