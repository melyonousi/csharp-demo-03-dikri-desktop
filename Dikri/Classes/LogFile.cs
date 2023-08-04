﻿using System;
using System.IO;

namespace Dikri
{
    static class LogFile
    {

        /// <summary>
        /// log file method
        /// </summary>
        /// <param name="ex"></param>
        static public void Message(Exception ex)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += "<br>";
            message += "-----------------------------------------------------------";
            message += "<br>";
            message += "<pre>" + string.Format("Message: {0}", ex.Message);
            message += "<br>";
            message += "<pre>" + string.Format("StackTrace: {0}", ex.StackTrace);
            message += "<br>";
            message += "<pre>" + string.Format("Source: {0}", ex.Source);
            message += "<br>";
            message += "<pre>" + string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += "<br>";
            message += "-----------------------------------------------------------";
            message += "<br>";

            String format = @"
                            <!DOCTYPE html>
                                <html>
                                    <head>
                                        <title>Log File Error</title>
                                        <style>
                                            @import url('https://fonts.googleapis.com/css2?family=Ubuntu&display=swap');
                                            *
                                            {
                                                box-sizing: border-box;
                                                margin: 0;
                                                padding: 0;
                                            }
                                            body
                                            {
                                                width: 90%;
                                                margin: auto;
                                                background-color: #1f1f1f;
                                                color: #efefef;
                                                font-family: 'Ubuntu', sans-serif;
                                            }

                                            div
                                            {
                                                font-family: 'Ubuntu', sans-serif;
                                                padding: 10px;
                                                font-size: meduim;
                                                margin: auto;
                                            }
                                        </style>
                                    </head>
                                    <body>
                                        <div>
                                            " + message + @"
                                        </div>
                                    </body>
                                </html>";

            using (StreamWriter writer = new StreamWriter("ErrorLog.html", true))
            {
                writer.WriteLine(format);
                writer.Close();
            }
        }
    }
}
