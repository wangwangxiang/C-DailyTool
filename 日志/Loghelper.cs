using log4net;
using log4net.Config;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    public static class Loghelper
    {
        // 获取日志名称
        private const string ErrorLevel = "Error";
        private const string InfoLevel = "Info";

        static Loghelper()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @"log4net.config";
            log4net.Config.XmlConfigurator.Configure(new FileInfo(path));
        }

     

        /// <summary>
        /// 根据Log等级获得log
        /// </summary>
        /// <param name="logLevel">Log等级</param>
        /// <returns></returns>
        public static ILog GetLog(string logLevel)
        {
            var log = log4net.LogManager.GetLogger(logLevel);
            return log;
        }

        public static void Info(string message)
        {
            var log = GetLog(InfoLevel);
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
        }
        public static void Info(string message, Exception ex)
        {
            var log = GetLog(InfoLevel);
            if (log.IsInfoEnabled)
            {
                log.Info(message, ex);
            }
        }
        public static void Error(string message)
        {
            var log = GetLog(ErrorLevel);
            if (log.IsErrorEnabled)
            {
                log.Error(message);
            }
        }

        public static void Error(string message, Exception ex)
        {
            var log = GetLog(ErrorLevel);
            if (log.IsErrorEnabled)
            {
                log.Error(message, ex);
            }
        }
    }
}
