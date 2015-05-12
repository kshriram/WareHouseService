using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace KrausWarehouseServices.DBLogics.RMA
{
    class cmdEDIFileHandling
    {

        static string fullname;
        public string[] filename()
        {

            string[] arrfilenames = new string[100];
            string[] arrfiles = new string[arrfilenames.Length];


            try
            {

                arrfilenames = Directory.GetFiles("//192.168.1.6/edierror$", "*", SearchOption.AllDirectories);

                // arrfilenames = Directory.GetFiles("//192.168.1.9/edierrorin/", "*", SearchOption.AllDirectories);
                int ii = 0;
                foreach (string files in arrfilenames)
                {
                    string[] val = files.Split('\\');
                    string newFileName = val[val.Length - 1];
                    arrfiles[ii] = newFileName;
                    ii++;
                }


            }
            catch (Exception)
            {
            }

            var temp = new List<string>();
            foreach (var s in arrfiles)
            {
                if (!string.IsNullOrEmpty(s))
                    temp.Add(s);
            }
            arrfiles = temp.ToArray();

            return arrfiles;

        }


        /// <summary>
        /// For Delete File 
        /// </summary>
        /// <param name="flnm"></param>
        /// <returns></returns>
        public string fileDelete(string flnm)
        {
            string contents3 = "3";
            string contents = "";// new string[1000];
            // string path = "//192.168.1.6/Sage/X3V6/Folders/Production/Import/Error/" + flnm;
            string path = "//192.168.1.6/edierror$" + flnm;
            System.IO.StreamReader objReader;
            string[] ee = new string[100];
            try
            {
                contents = File.ReadAllText(path);


                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    /// return true;
                    contents3 = "1";
                    return contents3;
                }
                else
                {
                    // return false;
                    contents3 = "2";
                    return contents3;
                }



                return contents3;

            }
            catch (Exception)
            {
            }

            return contents3;


        }

        /// <summary>
        /// End of Delete File
        /// </summary>
        /// <param name="flnm"></param>
        /// <returns></returns>

        public string fileData(string flnm)
        {

            string contents = "";// new string[1000];
            //  string path = "//192.168.1.9/edierrorin/"+flnm;
            string path = "//192.168.1.6/edierror$/" + flnm;
            ///  string path = "//192.168.1.9/edierrorin/" + flnm;

            string[] ee = new string[500];
            try
            {
                contents = File.ReadAllText(path);
            }
            catch (Exception)
            {
            }

            return contents;


        }
        public string sample(string fnm)
        {
            string path = "//192.168.1.6/edierror$" + fnm;
            //// System.IO.StreamReader objReader;
            string contents = "";
            string[] ee = new string[100];
            try
            {
                contents = File.ReadAllText(path);
            }
            catch (Exception)
            {
            }

            return contents;

        }


        public int MoveFiles(string filename)
        {
            int flag = 0;

            try
            {
                File.Copy(@"//192.168.1.6/edierror$/" + filename, @"//192.168.1.6/edierror$/Cancellationfiles/" + filename);
                File.Delete(@"//192.168.1.6/edierror$/" + filename);
                flag = 1;

            }
            catch (Exception)
            {
            }


            return flag;
        }


        public int Move850Files()
        {
            int flag = 0;
            try
            {
                string rootFolderPath = @"//192.168.1.6/850$/";
                string destinationPath = @"//192.168.1.6/850Archive$/";
                string filesToDelete = @"*.*";


                string[] fileList = System.IO.Directory.GetFiles(rootFolderPath, filesToDelete);
                foreach (string file in fileList)
                {
                    string strsplit = file.Split(new char[] { '/' }).Last().ToString();

                    string fileToMove = rootFolderPath + strsplit;
                    string moveTo = destinationPath + strsplit;
                    //moving file
                    File.Copy(fileToMove, moveTo);
                }
                flag = 1;
            }
            catch (Exception)
            {
            }
            return flag;
        }


        public string[] FileNames850archive()
        {

            // string[] arrfilenames = new string[100];
            string[] arrfiles = { };


            try
            {

                arrfiles = Directory.GetFiles("//192.168.1.6/850archive$", "*", SearchOption.AllDirectories);

                List<String> tmpList = new List<string>();

                // arrfilenames = Directory.GetFiles("//192.168.1.9/edierrorin/", "*", SearchOption.AllDirectories);
                int ii = 0;
                foreach (string files in arrfiles)
                {
                    string[] val = files.Split('\\');
                    string newFileName = val[val.Length - 1];
                    arrfiles[ii] = newFileName;

                    tmpList.Add(newFileName);

                    ii++;
                }

                arrfiles = tmpList.ToArray();
            }
            catch (Exception)
            {
            }

            //var temp = new List<string>();
            //foreach (var s in arrfiles)
            //{
            //    if (!string.IsNullOrEmpty(s))
            //        temp.Add(s);
            //}


            return arrfiles;

        }


        public string FileDataFrom850archive(string flnm)
        {
            string contents = "";// new string[1000];
            //  string path = "//192.168.1.9/edierrorin/"+flnm;
            string path = "//192.168.1.6/850archive$/" + flnm;
            ///  string path = "//192.168.1.9/edierrorin/" + flnm;

            string[] ee = new string[500];
            try
            {
                contents = File.ReadAllText(path);
            }
            catch (Exception)
            {
            }

            return contents;

        }


        public string[] FilesNameFrom856Export()
        {

            //string[] arrfiles = new string[100];
            string[] arrfiles = { };


            try
            {

                arrfiles = Directory.GetFiles(@"//192.168.1.6/856export$/", "*", SearchOption.TopDirectoryOnly);

                //string filepath = "//192.168.1.6/export_archive$/10235856_265986.out";

                //string val5 = filepath.Split(new char[] { '/' }).Last().ToString();FilesNameFrom856Export

                //string[] check856Arrayas = val5.Split(new char[] { '_' });

                //List<String> tmpList = new List<string>();


                //// arrfilenames = Directory.GetFiles("//192.168.1.9/edierrorin/", "*", SearchOption.AllDirectories);
                //int ii = 0;
                //foreach (string files in arrfiles)
                //{


                //    string val = files.Split(new char[] { '/' }).Last().ToString();
                //    //string newFileName = val[val.Length - 1];//.Split(new char[] { '_' }).First().ToString();

                //    string[] check856Array = val.Split(new char[] { '_' });

                //    if (check856Array.Length == 2)
                //    {
                //        string check856 = val.Split(new char[] { '_' }).First().ToString();

                //        string mystring = check856.Substring(check856.Length - 3);

                //        if (mystring == "856")
                //        {
                //            tmpList.Add(val); // arrfiles[ii] = val;
                //        }
                //    }

                //    ii++;
                //}
                //arrfiles = tmpList.ToArray();

            }
            catch (Exception)
            {
            }

            //var temp = new List<string>();
            //foreach (var s in arrfiles)
            //{
            //    if (!string.IsNullOrEmpty(s))
            //        temp.Add(s);
            //}


            return arrfiles;

        }

        public string FileDataFrom856Export(string flnm)
        {
            string contents = "";// new string[1000];
            //  string path = "//192.168.1.9/edierrorin/"+flnm;
            string path = "//192.168.1.6/856export$/" + flnm;
            ///  string path = "//192.168.1.9/edierrorin/" + flnm;

            string[] ee = new string[500];
            try
            {
                contents = File.ReadAllText(path);
            }
            catch (Exception)
            {
            }

            return contents;

        }

        public int CreateFiles(String FileName, string FileData)
        {
            int flag = 0;
            try
            {

                System.IO.File.WriteAllText(@"//192.168.1.6/856export$/TC_Outbox/" + FileName + ".out", FileData);
                //System.IO.File.WriteAllText(@"//192.168.1.6/850HomeDepotArchive$/" + FileName + ".out", FileData);

                flag = 1;
            }
            catch (Exception)
            {
            }
            return flag;
        }

        public int CreateHomeDepotFilesFrom850(String FileName, string FileData)
        {
            int flag = 0;
            try
            {

                System.IO.File.WriteAllText(@"//192.168.1.6/850HomeDepotArchive$/" + FileName + ".txt", FileData);

                flag = 1;
            }
            catch (Exception)
            {
            }
            return flag;
        }

        public int CreateHomeDepotFilesFrom856(String FileName, string FileData)
        {
            int flag = 0;
            try
            {
                System.IO.File.WriteAllText(@"//192.168.1.6/856HomeDepotArchive$/" + FileName + ".txt", FileData);

                flag = 1;
            }
            catch (Exception)
            {
            }
            return flag;
        }

        public string FileDataFromHomeDepot850(string flnm)
        {
            string contents = "";// new string[1000];
            //  string path = "//192.168.1.9/edierrorin/"+flnm;
            string path = "//192.168.1.6/850HomeDepotArchive$/" + flnm;
            ///  string path = "//192.168.1.9/edierrorin/" + flnm;

            string[] ee = new string[500];
            try
            {
                contents = File.ReadAllText(path);
            }
            catch (Exception)
            {
            }

            return contents;

        }

        public string FileDataFromHomeDepot856(string flnm)
        {
            string contents = "";// new string[1000];
            //  string path = "//192.168.1.9/edierrorin/"+flnm;
            string path = "//192.168.1.6/856HomeDepotArchive$/" + flnm;
            ///  string path = "//192.168.1.9/edierrorin/" + flnm;

            string[] ee = new string[500];
            try
            {
                contents = File.ReadAllText(path);
            }
            catch (Exception)
            {
            }

            return contents;

        }

        public string[] FilenamesFromHomeDepot850()
        {
            //string[] arrfiles = { };
            // string[] arrfilenames = new string[200];
            string[] arrfiles = { };//new string[arrfilenames.Length];


            try
            {

                arrfiles = Directory.GetFiles("//192.168.1.6/850HomeDepotArchive$", "*", SearchOption.AllDirectories);

                // arrfilenames = Directory.GetFiles("//192.168.1.9/edierrorin/", "*", SearchOption.AllDirectories);
                int ii = 0;
                foreach (string files in arrfiles)
                {
                    string[] val = files.Split('\\');
                    string newFileName = val[val.Length - 1];
                    arrfiles[ii] = newFileName;
                    ii++;
                }


            }
            catch (Exception)
            {
            }

            var temp = new List<string>();
            foreach (var s in arrfiles)
            {
                if (!string.IsNullOrEmpty(s))
                    temp.Add(s);
            }
            arrfiles = temp.ToArray();

            return arrfiles;

        }

        public string[] FilenamesFromHomeDepot856()
        {

            //string[] arrfilenames = new string[200];
            string[] arrfiles = { };//new string[arrfilenames.Length];


            try
            {

                arrfiles = Directory.GetFiles("//192.168.1.6/856HomeDepotArchive$", "*", SearchOption.AllDirectories);

                // arrfilenames = Directory.GetFiles("//192.168.1.9/edierrorin/", "*", SearchOption.AllDirectories);
                int ii = 0;
                foreach (string files in arrfiles)
                {
                    string[] val = files.Split('\\');
                    string newFileName = val[val.Length - 1];
                    arrfiles[ii] = newFileName;
                    ii++;
                }


            }
            catch (Exception)
            {
            }

            var temp = new List<string>();
            foreach (var s in arrfiles)
            {
                if (!string.IsNullOrEmpty(s))
                    temp.Add(s);
            }
            arrfiles = temp.ToArray();

            return arrfiles;

        }

        public int OverwriteOriginalFile(String FileName, string FileData)
        {
            int flag = 0;
            try
            {

                System.IO.File.WriteAllText(@"//192.168.1.6/856export$/" + FileName, FileData);
                //System.IO.File.WriteAllText(@"//192.168.1.6/850HomeDepotArchive$/" + FileName + ".out", FileData);

                // System.IO.File.WriteAllText(@"D:\\Test\\" + FileName, FileData);

                flag = 1;
            }
            catch (Exception)
            {
            }
            return flag;
        }

        public int Overwrite856HomeDepotFile(String FileName, string FileData)
        {
            int flag = 0;
            try
            {

                System.IO.File.WriteAllText(@"//192.168.1.6/856HomeDepotArchive$/" + FileName, FileData);
                //System.IO.File.WriteAllText(@"//192.168.1.6/850HomeDepotArchive$/" + FileName + ".out", FileData);

                // System.IO.File.WriteAllText(@"D:\\Test\\" + FileName, FileData);

                flag = 1;
            }
            catch (Exception)
            {
            }
            return flag;
        }





        public int MoveFilesToTC(string filename)
        {
            int flag = 0;

            try
            {



                //FileInfo file = new FileInfo(@"D:\\Test\\" + filename);

                FileInfo file = new FileInfo(@"//192.168.1.6/856export$/" + filename);

                if (file.Length > 0)
                {
                    File.Move(@"//192.168.1.6/856export$/" + filename, @"//192.168.1.6/856export$/TC_Outbox/" + filename);
                    // File.Delete(@"//192.168.1.6/856export$/" + filename);
                    flag = 1;
                }




            }
            catch (Exception)
            {
            }


            return flag;
        }

        public int MoveSingleTrackingFilesToTC(string filename)
        {
            int flag = 0;

            try
            {
                File.Move(@"//192.168.1.6/856HomeDepotArchive$/" + filename, @"//192.168.1.6/856export$/TC_Outbox/" + filename);
                // File.Delete(@"//192.168.1.6/856export$/" + filename);
                flag = 1;

            }
            catch (Exception)
            {
            }


            return flag;
        }

        public int CreateAndMoveTrackingFileToTC(String FileName, string FileData)
        {
            int flag = 0;
            try
            {

                System.IO.File.WriteAllText(@"//192.168.1.6/856export$/TC_Outbox/" + FileName + "_tracking.out", FileData);
                //System.IO.File.WriteAllText(@"//192.168.1.6/850HomeDepotArchive$/" + FileName + ".out", FileData);

                flag = 1;
            }
            catch (Exception)
            {
            }
            return flag;
        }


        public string[] FilesNameFrom856ExportTCOutboxError()
        {

            //string[] arrfiles = new string[100];
            string[] arrfiles = { };


            try
            {

                arrfiles = Directory.GetFiles(@"//192.168.1.6/856export$/TC_Outbox_Error/", "*", SearchOption.TopDirectoryOnly);


               // arrfiles = Directory.GetFiles(@"D:\\Test\\", "*", SearchOption.TopDirectoryOnly);

                //  System.IO.File.WriteAllText(@"D:\\Test\\" + FileName, FileData); Templates

            }
            catch (Exception)
            {
            }

            return arrfiles;

        }


        public int MoveFilesFromTCOErrToMenardErr(string filename)
        {
            int flag = 0;

            try
            {
               File.Copy(@"//192.168.1.6/856export$/TC_Outbox_Error/" + filename, @"//192.168.1.6/856export$/Menard_Error_870/" + filename);


               // File.Copy(@"D:\\Test\\" + filename, @"D:\\Test\\Templates\\" + filename);

                // File.Delete(@"//192.168.1.6/edierror$/" + filename);
                flag = 1;

            }
            catch (Exception)
            {
            }


            return flag;
        }


        public string FileDataFrom856exportTCOutboxError(string flnm)
        {
            string contents = "";// new string[1000];

            string path = "//192.168.1.6/856export$/TC_Outbox_Error/" + flnm;

            //string path = "D:\\Test\\" + flnm;

            string[] ee = new string[500];
            try
            {
                contents = File.ReadAllText(path);
            }
            catch (Exception)
            {
            }

            return contents;

        }


        public int CreateFilesFrom856ExportTCOutboxError(String FileName, string FileData)
        {
            int flag = 0;
            try
            {

                System.IO.File.WriteAllText(@"//192.168.1.6/856export$/" + FileName + ".out", FileData);

              //  System.IO.File.WriteAllText(@"D:\\Test\\" + FileName + ".out", FileData);


                flag = 1;
            }
            catch (Exception)
            {
            }
            return flag;
        }




        public string[] FilesNameFromMenardExportTCOutboxError()
        {

            //string[] arrfiles = new string[100];
            string[] arrfiles = { };


            try
            {

                arrfiles = Directory.GetFiles(@"//192.168.1.6/856export$/Menard_Error_870/", "*", SearchOption.TopDirectoryOnly);


                // arrfiles = Directory.GetFiles(@"D:\\Test\\", "*", SearchOption.TopDirectoryOnly);

                //  System.IO.File.WriteAllText(@"D:\\Test\\" + FileName, FileData); Templates

            }
            catch (Exception)
            {
            }

            return arrfiles;

        }






    }
}
