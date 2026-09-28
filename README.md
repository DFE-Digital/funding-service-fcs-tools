# funding-service-fcs-tools


## Introduction

This repository contains a collection of utilities, helper applications, scripts, and development tools used by the Calculate Funding team.

The tools within this repository support various engineering, release management, diagnostics, reporting, CRM integration, Service Bus operations, and development productivity activities.

This repository was migrated from TFVC on 05-Nov-2019 and is maintained as a central location for internally developed tools.

---

## Repository Structure

| Folder | Purpose |
|----------|----------|
| BuildLogReader | Analyse and review build logs |
| ConfigManagement | Configuration management utilities |
| FeatureFileParser | Parse and process feature files |
| ReleaseBranchUtility | Release branch creation and management |
| VelocityCalculator | Agile velocity reporting |
| ServiceBusExplorer | Azure Service Bus inspection and troubleshooting |
| AzureDiagnosticLogReaderUtil | Azure diagnostic log analysis |
| CRMOnlineHelper | CRM connectivity and administration utilities |
| PopulateFSPDDisplayOrder | Data maintenance utility |
| Operations | Operational support tools |

---

## Prerequisites

Depending on the tool being used, you may require:

- .NET Framework /.NET SDK
- Visual Studio
- Azure access
- CRM access
- Service Bus permissions
- Appropriate environment configuration

Refer to the individual tool folder for specific requirements.

---

## Getting Started

1. Clone the repository:

```bash
git clone https://sfa-fcs.visualstudio.com/FCT/_git/Tools

