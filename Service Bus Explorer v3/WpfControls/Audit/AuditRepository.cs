namespace WpfControls.Audit
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
    using Dapper;

    public static class AuditRepository
    {
        public static IReadOnlyCollection<AuditMessage> GetAuditMessages(
            string environment,
            DateTime startDate,
            DateTime endDate,
            string messageType, 
            string businessKey)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[environment].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                const string sql = @"SELECT [MessageId]
                                            ,[MessageType]
                                            ,[SentTime]
                                            ,[OriginatingEndpoint]
                                            ,[ProcessingEndpoint]
                                            ,[BusinessKey]
                                            ,[MessageBytes]
                                            ,[PropertiesBytes]
                                    FROM [Operations].[AuditMessage] 
                                    where SentTime between @startDate and @enddate 
                                    and MessageType = @messageType
                                    and BusinessKey like  @businessKey 
                                    order by SentTime asc";

                string businessKeyWildCard = $"%{businessKey}%";

                return connection.Query<AuditMessage>(sql: sql, commandTimeout: 600, param:new
                {
                    startDate,
                    endDate,
                    messageType,
                    businessKey = businessKeyWildCard
                }).ToList();
            }
        }
    }
}
