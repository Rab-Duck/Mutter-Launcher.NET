using Microsoft.VisualStudio.TestTools.UnitTesting;
using MutterLauncher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MutterLauncher.Tests
{
    [TestClass()]
    public class FileCollectorTests
    {
        [TestMethod()]
        public void FileCollectorTest()
        {
            new FileCollector(@"c:\windows");

            try
            {
                new FileCollector(@"c:\ho:ge");
            }
            catch (System.IO.IOException)
            {
                // OK
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void FileCollectorTest1()
        {
            new FileCollector(@"c:\windows", true, ".EXE;.LNK");
            new FileCollector(@"c:\windows", false, ".EXE;.LNK");
            new FileCollector(@"c:\windows", true, "");
            new FileCollector(@"c:\windows", true, null);
            new FileCollector(@"c:\windows", true, "hogehoge");

            try
            {
                new FileCollector(@"c:\ho:ge", false, ".EXE;.LNK");
            }
            catch (System.IO.IOException)
            {
                // OK
            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        public void collectTest()
        {
            (new FileCollector(@"c:\windows")).collect();
            (new FileCollector(@"c:\windows", true, ".EXE;.LNK;.ZZZ")).collect();
            (new FileCollector(@"c:\windows", true, "")).collect();
            (new FileCollector(@"c:\windows", true, null)).collect();
            (new FileCollector(@"c:\windows", true, "hogehoge;.exe")).collect();

        }

        [TestMethod()]
        public void getItemListTest()
        {
            FileCollector fc;
            List<Item> items, items2;

            fc = new FileCollector(@"c:\windows");
            fc.collect();
            items = fc.getItemList();

            fc = new FileCollector(@"c:\windows", true, ".com;.exe;.bat;.cmd;.vbs;.vbe;.js;.jse;.wsf;.wsh;.msc");
            fc.collect();
            items2 = fc.getItemList();

            if (items.Count != items2.Count)
            {
                Assert.Fail("item count error");
            }

            if (!checkFiles(items, "explorer.exe;rundll32.exe"))
            {
                Assert.Fail("Not found: explorer.exe;rundll32.exe");
            }
            if (checkFiles(items, "hogehoge.exe"))
            {
                Assert.Fail("Found error: hogehoge.exe");
            }

            fc = new FileCollector(@"c:\windows", false, ".exe;.lnk;.zzz");
            fc.collect();
            items = fc.getItemList();

            if (!checkFiles(items, "explorer.exe"))
            {
                Assert.Fail("Not found: explorer.exe");
            }
            if (checkFiles(items, "rundll32.exe"))
            {
                Assert.Fail("Found error: rundll32.exe");
            }

            fc = new FileCollector(@"c:\windows", true, "hogehoge");
            fc.collect();
            items = fc.getItemList();

            if (items.Count() > 0)
            {
                Assert.Fail("Found error: hogehoge");
            }


        }

        private bool checkFiles(List<Item> items, string files)
        {
            string[] filearry = files.Split(new char[] { ';' });

            foreach (string file in filearry)
            {
                int count = 0;
                foreach (var item in items)
                {
                    if (file.Equals(item.getItemName(),StringComparison.OrdinalIgnoreCase))
                    {
                        count++;
                    }
                }
                if (count<1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}