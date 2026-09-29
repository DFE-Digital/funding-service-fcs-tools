
param
(
    [Parameter(Mandatory=$True)]
    [string]$CRMServiceUrl,
    [Parameter(Mandatory=$True)]
    [string]$Username,
    [Parameter(Mandatory=$True)]
    [string]$Password
)

Add-Type -Path "$PSScriptRoot\Microsoft.Xrm.Sdk.dll";
Add-Type -Path "$PSScriptRoot\Microsoft.Crm.Sdk.Proxy.dll";

function RetrieveMultiple
{
    PARAM
    (
        [parameter(Mandatory=$true)]$service,
        [parameter(Mandatory=$true)]$query
    )

    $pageNumber = 1;

    $query.PageInfo = New-Object -TypeName Microsoft.Xrm.Sdk.Query.PagingInfo;
    $query.PageInfo.PageNumber = $pageNumber;
    $query.PageInfo.Count = 1000;
    $query.PageInfo.PagingCookie = $null;

    $records = $null;
    while($true)
    {
        $results = $service.RetrieveMultiple($query);
                
        Write-Progress -Activity "Retrieve data from CRM" -Status "Processing record page : $pageNumber" -PercentComplete -1;
        if($results.Entities.Count -gt 0)
        {
            if($records -eq $null)
            {
                $records = $results.Entities;
            }
            else
            {
                $records.AddRange($results.Entities);
            }
        }
        if($results.MoreRecords)
        {
            $pageNumber++;
            $query.PageInfo.PageNumber = $pageNumber;
            $query.PageInfo.PagingCookie = $results.PagingCookie;
        }
        else
        {
            break;
        }
    }
    return $records;
}


function Get-FailedWorkflows
{
    $query = New-Object -TypeName Microsoft.Xrm.Sdk.Query.QueryExpression -ArgumentList "asyncoperation";
    $query.ColumnSet.AddColumn("asyncoperationid");
    $query.ColumnSet.AddColumn("name");
    $query.ColumnSet.AddColumn("regardingobjectid");
    $query.ColumnSet.AddColumn("message");
    $query.Criteria.AddFilter([Microsoft.Xrm.Sdk.Query.LogicalOperator]::And);
    $query.Criteria.AddCondition("operationtype", [Microsoft.Xrm.Sdk.Query.ConditionOperator]::Equal, 10);
    $query.Criteria.AddCondition("statuscode", [Microsoft.Xrm.Sdk.Query.ConditionOperator]::Equal, 31);
    $query.AddOrder("startedon", [Microsoft.Xrm.Sdk.Query.OrderType]::Descending);

    $records = RetrieveMultiple $service $query;
    return $records;
}


$crmServiceUrl = $CRMServiceUrl
$clientCredentials = new-object System.ServiceModel.Description.ClientCredentials
$clientCredentials.UserName.UserName = $Username
$clientCredentials.UserName.Password = $Password
$service = new-object Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy($crmServiceUrl, $null, $clientCredentials, $null)
$service.Timeout = new-object System.Timespan(0, 10, 0)

$failedWorkflows =  Get-FailedWorkflows;


foreach($workflow in $failedWorkflows)
{    
        $workflowId = $workflow.Attributes["asyncoperationid"].Guid;
        $message = $workflow.Attributes["message"];
        $workflowName = $workflow.Attributes["name"];   
        $regarding = $workflow.Attributes["regardingobjectid"].Name;
        $regardingObjectId = $workflow.Attributes["regardingobjectid"].Id;
        Write-Host "Workflow Id : $workflowId Workflow Name: $workflowName Regarding: $regarding Message: $message" -ForegroundColor Yellow;     
        #Write-Output "Hello World";
    }



