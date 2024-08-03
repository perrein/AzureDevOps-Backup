# Azure DevOps Backup Tool

This tool is a fork of the Azure DevOps Backup Tool from OrbitOne/VSOBackup. It supports Personal Access Tokens, as Alternate Credentials have been removed by Microsoft.

## Overview

The tool utilizes the Azure DevOps REST API to query an Azure DevOps account and gather all necessary data. Since Azure DevOps allows only one Team Project Collection per organization, the tool retrieves all team projects from the default collection. Each team project can have multiple repositories that require backup. A folder is created for each team project and saved to a configurable location on disk. The tool then iterates over each repository in the team project, creating folders for each repository.

![Azure DevOps Backup](https://pbs.twimg.com/media/CEeHrndVIAAnREj.png)

## Features

### Repository Backup

The backup process uses a clone URL obtained from the Azure DevOps REST API, similar to those used on GitHub. To clone the repositories, the tool uses the libGit2Sharp library, which simplifies the process to calling `Repository.Clone()` with the clone URL and destination path.

### Personal Access Tokens

Personal Access Tokens are necessary to access the Azure DevOps REST API and clone repositories using the libGit2Sharp library. These tokens can be generated from your Azure DevOps profile.

### Configurable Retention

A configurable key, "RemoveBackupAfterHowManyDays", allows you to set the retention period for the oldest backups. Currently set to 10 days, this means a complete repository backup is stored for only 10 days before being deleted from disk.

### Configurable Paths and URLs

Both the backup location and the REST URLs required to query Azure DevOps accounts are configurable. This allows flexibility and convenience, ensuring the tool can adapt to changes such as API function name modifications or account updates.

By configuring these settings, the task can serve as a backup tool for different Azure DevOps accounts. Schedule another instance of the task with different settings, and it’s ready to go. These app settings enable quick changes without the need to recompile or redeploy the application.