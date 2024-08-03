﻿using System;
using AzDoBackup.DependencyInjection;
using AzDoBackup.Logging;
using AzDoBackup.Services;

namespace AzDoBackupTool
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var bootstrapper = new Bootstrapper().BootstrapContainer();
            var backupService = bootstrapper.Resolve<ISourceControlBackupService>();
            var logger = bootstrapper.Resolve<ILogger>();

            try
            {
                backupService.Backup();
                logger.WriteLog("DONE");
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex.ToString());
                throw;
            }
        }
    }
}