﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MutterLauncher
{
    public class FileCollector : AppCollector
    {
        private List<Item> items = new List<Item>();
        private string dirPath = null;
        private bool recursive = true;
        private string pathExt;
        private string extRegex;

        public FileCollector(string dirPath)
        {
            init(dirPath, true, null);
        }

        public FileCollector(string dirPath, bool recursive, string pathExt)
        {
            init(dirPath, recursive, pathExt);
        }

        private void init(string dirPath, bool recursive, string pathExt)
        {
            // Support such as %hoge%\bin
            dirPath = Environment.ExpandEnvironmentVariables(dirPath);
            Trace.WriteLine("Search Dir:" + dirPath);
            if (!Directory.Exists(dirPath))
            {
                throw new IOException();
            }
            this.dirPath = dirPath;
            this.recursive = recursive;

            if (String.IsNullOrEmpty(pathExt))
            {
                pathExt = Environment.GetEnvironmentVariable("PATHEXT");
                if (pathExt == null)
                {
                    // default value from https://en.wikipedia.org/wiki/Environment_variable#Default_values
                    pathExt = ".com;.exe;.bat;.cmd;.vbs;.vbe;.js;.jse;.wsf;.wsh;.msc";
                }
            }
            this.pathExt = pathExt;
            setExtRegex(pathExt);
        }

        private void setExtRegex(string pathExt)
        {
            if (String.IsNullOrEmpty(pathExt))
            {
                throw new System.ArgumentException("pathExt is " + pathExt);
            }
            string[] extlist = pathExt.Split(';');
            string regex = ".*\\.(";
            for (int i = 0; i < extlist.Length; i++)
            {
                regex += extlist[i].Replace(".", "");
                if (i < extlist.Length - 1)
                {
                    regex += "|";
                }
            }
            regex += ")$";
            this.extRegex = regex;
            return;
        }


        public void collect()
        {
            items.Clear();


            // reference: http://www.atmarkit.co.jp/fdotnet/dotnettips/053allfiles/allfiles.html
            Queue q = new Queue();
            q.Enqueue(dirPath);

            FileAttributes attr;
            while (q.Count > 0)
            {
                string dq = (string)q.Dequeue();

                attr = File.GetAttributes(dq);
                if((attr & FileAttributes.Directory) == 0 &&
                    (attr & (FileAttributes.System | FileAttributes.Hidden)) != 0)
                {
                    continue;
                }

                string[] files;
                try
                {
                    files = Directory.GetFiles(dq);
                }
                catch (UnauthorizedAccessException uaex)
                {
                    Trace.WriteLine(dq + ":" + uaex.Message);
                    continue;
                }
                foreach (string file in files)
                {
                    attr = File.GetAttributes(file);
                    if ((attr & (FileAttributes.System | FileAttributes.Hidden)) == 0)
                    {
                        try
                        {
                            if (pathExt == "*" ||
                                Regex.IsMatch(file, extRegex, RegexOptions.IgnoreCase /*| RegexOptions.Compiled*/))
                            {
                                items.Add(new FileItem(file));
                                // Debug.WriteLine("match file:" + file);
                            }
                        }
                        catch (ArgumentException ae)
                        {
                            Trace.WriteLine("Regex error:" + extRegex + ", " + ae.Message);
                            return;
                        }
                    }
                }
                if (!recursive)
                {
                    return;
                }

                string[] dirs;
                try
                {
                    dirs = Directory.GetDirectories(dq);
                }
                catch (UnauthorizedAccessException uaex)
                {
                    Trace.WriteLine(dq + ":" + uaex.Message);
                    continue;
                }
                foreach (string dir in dirs)
                {
                    q.Enqueue(dir);
                }
            }
        }

        public List<Item> getItemList()
        {
            return items;
        }
    }
}
