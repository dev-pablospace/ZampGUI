using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using ZampLib.Business;
using System.Net.NetworkInformation;
using System.Net;
using System.Security.Principal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ZampLib
{
    public class ZampGUILib
    {
        public static string getval_from_appsetting(string pathprog)
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;

            for (int i = 0; i < appSettings.Count; i++)
            {
                if (pathprog.Equals(appSettings.GetKey(i)))
                {
                    return appSettings[i];
                }
                //Console.WriteLine("#{0} Key: {1} Value: {2}", i, appSettings.GetKey(i), appSettings[i]);
            }
            return null;
        }

        public static void printMsg_and_exit(string msg = "", bool bexit = false, System.Windows.Forms.Form f = null)
        {
            if(!string.IsNullOrEmpty(msg))
            {
                System.Windows.Forms.MessageBox.Show(msg);
            }

            if(bexit)
            {
                if(f != null)
                {
                    f.Close();
                }
                System.Windows.Forms.Application.Exit();
            }
        }

        public static List<string> getAllDB(string port)
        {
            List<string> tempList = new List<string>();

            var connString = "Server=127.0.0.1;User ID=root;Password=root;Database=mysql;port=" + port;

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();

                // Insert some data
                /*using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO data (some_field) VALUES (@p)";
                    cmd.Parameters.AddWithValue("p", "Hello world");
                    cmd.ExecuteNonQuery();
                }*/

                // Retrieve all rows
                using (var cmd = new MySqlCommand("SHOW DATABASES;", conn))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        tempList.Add(reader.GetString(0));
            }

            return tempList;
        }

        public static bool port_in_use(string _port, string _procid)
        {
            int port = Convert.ToInt32(_port);
            bool inUse = false;

            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    int proc_id = getProcessId_from_port(port);
                    if(proc_id.ToString() == _procid)
                    {
                        continue;
                    }
                    inUse = true;
                    break;
                }
            }

            return inUse;
        }

        public static string startProc(ConfigVar cv, typeProg tpg, string[] args)
        {
            string friendly_name = cv.get_friendly_name(tpg);
            string pid = cv.get_correct_pid(tpg);
            string pathProg = cv.get_correct_path_prog(tpg);
            string sout = "";

            if (!string.IsNullOrEmpty(pid) && Process.GetProcesses().Any(x => x.Id == Convert.ToInt32(pid)))
            {
                sout += "Process " + friendly_name + " is still running" + Environment.NewLine;
                return sout;
            }

            ProcessStartInfo psi = new ProcessStartInfo();
            if(tpg == typeProg.editor)
            {
                psi.WindowStyle = ProcessWindowStyle.Normal;
            }
            else
            {
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
            }
            psi.FileName = pathProg;
            psi.Arguments = "";
            foreach (string arg in args)
            {
                psi.Arguments += " \"" + arg + "\"";
            }
            
            var proc = Process.Start(psi);
            System.Threading.Thread.Sleep(500);


            if (tpg == typeProg.apache || tpg == typeProg.mariadb)
            {
                try
                {
                    if (checkRunningProc(proc.Id.ToString()))
                    {
                        //OK
                        sout += "Starting " + friendly_name + " with id " + proc.Id + Environment.NewLine;
                        cv.updatePID(tpg, typeStartorKill.start, proc.Id);
                    }
                    else
                    {
                        //string stdoutx = proc.StandardOutput.ReadToEnd();
                        string stderrx = proc.StandardError.ReadToEnd();

                        if (!string.IsNullOrEmpty(stderrx))
                        {
                            sout += "Error starting " + friendly_name + Environment.NewLine;
                            sout += "Error message " + stderrx;
                        }
                    }
                }
                catch(Exception ex)
                {
                    sout += "Error starting " + friendly_name + Environment.NewLine;
                    sout += ex.ToString();
                }
            }
            
            return sout;
        }

        public static string startProc_and_wait_output(string path_exe, string args, bool bhide = false, string working_dir = null)
        {
            string _outstring = "";
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            if(!string.IsNullOrEmpty(working_dir))
            {
                process.StartInfo.WorkingDirectory = working_dir;
            }
            process.StartInfo.Arguments = "/c \"" + path_exe + " " + args + "\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = bhide;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            //* Read the output (or the error)
            _outstring = process.StandardOutput.ReadToEnd();
            //Console.WriteLine(output);
            string err = process.StandardError.ReadToEnd();
            //Console.WriteLine(err);
            process.WaitForExit();
            return _outstring;
        }

        public static Tuple<string, string> startProc_and_wait_output2(string path_exe, string args, bool bhide = false, string working_dir = null, string enviromentPath = null, Dictionary<string,string> otherenvvars = null)
        {
            string _outstring = "";
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            if (!string.IsNullOrEmpty(working_dir))
            {
                process.StartInfo.WorkingDirectory = working_dir;
            }
            process.StartInfo.Arguments = "/c \"" + path_exe + " " + args + "\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = bhide;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            
            if(!string.IsNullOrEmpty(enviromentPath))
            {
                process.StartInfo.EnvironmentVariables["PATH"] = enviromentPath;
            }

            if(otherenvvars != null)
            {
                foreach(var arg in otherenvvars)
                {
                    process.StartInfo.EnvironmentVariables[arg.Key] = arg.Value;
                }
            }

                
            process.Start();
            //* Read the output (or the error)
            _outstring = process.StandardOutput.ReadToEnd();
            //Console.WriteLine(output);
            string err = process.StandardError.ReadToEnd();
            //Console.WriteLine(err);
            process.WaitForExit();
            return new Tuple<string, string>(_outstring, err);
        }

        public static void startProc_as_admin(string path_exe, string args)
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            //proc.FileName = path_exe;
            proc.FileName = "notepad.exe"; // qui devo per forza usare notepad perchè notepad++ o altro potrebbe non funzionare
            proc.Verb = "runas";
            proc.Arguments = args;

            try
            {
                Process.Start(proc);
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                // The user refused the elevation.
                // Do nothing and return directly ...
                return;
            }
            //System.Windows.Forms.Application.Exit();  // Quit itself
        }


        public static int getProcessId_from_port(int _port)
        {
            using (Process Proc = new Process())
            {
                ProcessStartInfo StartInfo = new ProcessStartInfo();
                StartInfo.FileName = "netstat.exe";
                StartInfo.Arguments = "-a -n -o";
                StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                StartInfo.UseShellExecute = false;
                StartInfo.RedirectStandardInput = true;
                StartInfo.RedirectStandardOutput = true;
                StartInfo.RedirectStandardError = true;
                StartInfo.CreateNoWindow = true;

                Proc.StartInfo = StartInfo;
                Proc.Start();

                StreamReader StandardOutput = Proc.StandardOutput;
                StreamReader StandardError = Proc.StandardError;

                string NetStatContent = StandardOutput.ReadToEnd() + StandardError.ReadToEnd();
                string NetStatExitStatus = Proc.ExitCode.ToString();

                if (NetStatExitStatus != "0")
                {
                    Console.WriteLine("NetStat command failed.   This may require elevated permissions.");
                }

                string[] NetStatRows = Regex.Split(NetStatContent, "\r\n");

                foreach (string NetStatRow in NetStatRows)
                {
                    string[] Tokens = Regex.Split(NetStatRow, "\\s+");
                    if (Tokens.Length > 4 && (Tokens[1].Equals("UDP") || Tokens[1].Equals("TCP")))
                    {
                        string IpAddress = Regex.Replace(Tokens[2], @"\[(.*?)\]", "1.1.1.1");
                        try
                        {
                            int port = Convert.ToInt32(IpAddress.Split(':')[1]);
                            string processname = Tokens[1] == "UDP" ? GetProcessName(Convert.ToInt16(Tokens[4])) : GetProcessName(Convert.ToInt16(Tokens[5]));
                            int ProcessId = Tokens[1] == "UDP" ? Convert.ToInt16(Tokens[4]) : Convert.ToInt16(Tokens[5]);
                            string Protocol = IpAddress.Contains("1.1.1.1") ? String.Format("{0}v6", Tokens[1]) : String.Format("{0}v4", Tokens[1]);
                            if(_port == port)
                            {
                                return ProcessId;
                            }
                            /*
                            ProcessPorts.Add(new ProcessPort(
                                Tokens[1] == "UDP" ? GetProcessName(Convert.ToInt16(Tokens[4])) : GetProcessName(Convert.ToInt16(Tokens[5])),
                                Tokens[1] == "UDP" ? Convert.ToInt16(Tokens[4]) : Convert.ToInt16(Tokens[5]),
                                IpAddress.Contains("1.1.1.1") ? String.Format("{0}v6", Tokens[1]) : String.Format("{0}v4", Tokens[1]),
                                Convert.ToInt32(IpAddress.Split(':')[1])
                            ));*/
                        }
                        catch
                        {
                            //Console.WriteLine("Could not convert the following NetStat row to a Process to Port mapping.");
                            //Console.WriteLine(NetStatRow);
                        }
                    }
                    else
                    {
                        if (!NetStatRow.Trim().StartsWith("Proto") && !NetStatRow.Trim().StartsWith("Active") && !String.IsNullOrWhiteSpace(NetStatRow))
                        {
                            //Console.WriteLine("Unrecognized NetStat row to a Process to Port mapping.");
                            //Console.WriteLine(NetStatRow);
                        }
                    }
                }
            }

            return 0;
        }

        private static string GetProcessName(int ProcessId)
        {
            string procName = "UNKNOWN";

            try
            {
                procName = Process.GetProcessById(ProcessId).ProcessName;
            }
            catch { }

            return procName;
        }

        public static bool checkRunningProc(string pid)
        {
            if (string.IsNullOrEmpty(pid))
            {
                return false;
            }

            Process proc = ZampGUILib.GetProcByID(pid);
            if (proc != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string getNameProc_fromPID(string pid)
        {
            if(string.IsNullOrEmpty(pid))
            {
                return "";
            }
            else
            {
                Process proc = ZampGUILib.GetProcByID(pid);
                return proc.ProcessName;
            }
            //return "";
        }

        public static string getStatusProc(ConfigVar cv, typeProg tpg)
        {
            string friendly_name = cv.get_friendly_name(tpg);
            string pid = cv.get_correct_pid(tpg);

            if (string.IsNullOrEmpty(pid))
            {
                return friendly_name + " not running" + Environment.NewLine;
            }

            Process proc = ZampGUILib.GetProcByID(pid);
            string sout = "";
            if (proc != null)
            {
                sout += string.Format(friendly_name + " {0}, Id: {1}", proc.ProcessName, proc.Id) + Environment.NewLine;
            }
            else
            {
                sout += friendly_name + " not running" + Environment.NewLine;
            }
            return sout;
        }
        public static string killproc(ConfigVar cv, typeProg tpg)
        {
            string friendly_name = cv.get_friendly_name(tpg);
            string pid = cv.get_correct_pid(tpg);
            string sout = "";


            if(string.IsNullOrEmpty(pid))
            {
                sout += friendly_name + " not running" + Environment.NewLine;
                return sout;
            }

            Process proc = null;
            try
            {
                proc = Process.GetProcessById(Convert.ToInt32(pid));
            }
            catch (Exception ex) { }

            if (proc != null)
            {
                sout += "killing proc " + friendly_name + " with id " + proc.Id + Environment.NewLine;
                proc.Kill();
            }
            else
            {
                sout += friendly_name + " not running" + Environment.NewLine;
            }
            cv.updatePID(tpg, typeStartorKill.kill, Convert.ToInt32(pid));
            return sout;
        }

        public static Process GetProcByID(string id)
        {
            Process[] processlist = Process.GetProcesses();
            return processlist.FirstOrDefault(pr => pr.Id == Convert.ToInt32(id));
        }

        public static string getJsonPath()
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path_json_config = Path.Combine(assemblyFolder, "config.json");
            return path_json_config;
        }

        public static JObject getJson_Env()
        {
            string path_json_config = getJsonPath();
            string temp = File.ReadAllText(path_json_config);
            JObject o1 = JObject.Parse(temp);
            return o1;
        }
        public static void setJson_Env(JObject jsonObj)
        {
            string path_json_config = getJsonPath();
            string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj,
                               Newtonsoft.Json.Formatting.Indented);
            if(System.IO.File.Exists(path_json_config))
            {
                System.IO.File.Delete(path_json_config);
            }
            File.WriteAllText(path_json_config, newJsonResult);
        }

        public static string replace_ignorecase(string text, string oldtext, string newtext)
        {
            return Regex.Replace(text, oldtext, newtext, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            //text.Replace(oldtext, newtext);
        }
        

        public static List<string> ExecuteBatchFile(string batchFileName, string[] argumentsToBatchFile)
        {
            string argumentsString = string.Empty;
            List<string> l_res = new List<string>();

            if (argumentsToBatchFile != null)
            {
                for (int count = 0; count < argumentsToBatchFile.Length; count++)
                {
                    argumentsString += " \"" + argumentsToBatchFile[count] + "\"";
                }
            }


            ProcessStartInfo ProcessInfo = new ProcessStartInfo(batchFileName, argumentsString);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;
            //ProcessInfo.WorkingDirectory = Application.StartupPath + "\\txtmanipulator";
            // *** Redirect the output ***
            ProcessInfo.RedirectStandardError = true;
            ProcessInfo.RedirectStandardOutput = true;

            Process process = Process.Start(ProcessInfo);
            process.WaitForExit();

            // *** Read the streams ***
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            int ExitCode = process.ExitCode;

            process.Close();

            l_res.Add(output);
            l_res.Add(error);
            l_res.Add(ExitCode.ToString());
            return l_res;
        }
        public static bool ExecuteBatchFile_dont_wait(string batchFileName, string[] argumentsToBatchFile, string AddToPath = "")
        {
            string argumentsString = string.Empty;
            try
            {
                //Add up all arguments as string with space separator between the arguments
                if (argumentsToBatchFile != null)
                {
                    for (int count = 0; count < argumentsToBatchFile.Length; count++)
                    {
                        argumentsString += " \"" + argumentsToBatchFile[count] + "\"";
                    }
                }


                //Create process start information
                ProcessStartInfo DBProcessStartInfo = new ProcessStartInfo(batchFileName, argumentsString);
                DBProcessStartInfo.UseShellExecute = false;
                DBProcessStartInfo.RedirectStandardOutput = false;
                DBProcessStartInfo.RedirectStandardError = false;

                if(string.IsNullOrEmpty(AddToPath))
                {
                    string PATH = Environment.GetEnvironmentVariable("PATH");
                    DBProcessStartInfo.EnvironmentVariables["PATH"] = AddToPath + ";" + PATH;
                }
                

                Process dbProcess = Process.Start(DBProcessStartInfo);
                return true;
            }
            // Catch the SQL exception and throw the customized exception made out of that
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                //throw new CustomizedException(ARCExceptionManager.ErrorCodeConstants.generalError, ex.Message);
                return false;
            }
        }


        public static string get_first_dir(string abs_main_path, string search)
        {
            string[] arrdir = Directory.GetDirectories(Path.Combine(abs_main_path, "Apps"));
            foreach(string s in arrdir)
            {
                string dir_name = Path.GetFileName(s);
                if(dir_name.Contains(search))
                {
                    return dir_name;
                }
            }
            throw new Exception(search + " folder not found");
        }
        public static string[] get_dirs(string abs_main_path, string search)
        {
            List<string> temp = new List<string>();
            string[] arrdir = Directory.GetDirectories(Path.Combine(abs_main_path, "Apps"));
            foreach (string s in arrdir)
            {
                string dir_name = Path.GetFileName(s);
                if (dir_name.Contains(search))
                {
                    temp.Add(dir_name);
                }
            }
            return temp.ToArray();
        }
        public static string get_first_file(string dir, string search)
        {
            string[] arr = Directory.GetFiles(dir);
            foreach (string s in arr)
            {
                string name = Path.GetFileName(s);
                if (s.Contains(search))
                {
                    return s;
                }
            }
            return "";
        }


        public static string getNameCurrent_user()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            return id.Name;
            //WindowsPrincipal principal = new WindowsPrincipal(id);
            //return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static List<string> getListSite(ConfigVar cv)
        {
            List<string> _list = new List<string>();
            string arrtest = ZampGUILib.startProc_and_wait_output(cv.Apache_exe, "-S", true);
            string pattern = @"\d*\snamevhost\s(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?";
            Regex rgx = new Regex(pattern);
            string sentence = arrtest;

            foreach (Match match in rgx.Matches(sentence))
            {
                string[] arr = match.Value.Split(' ');
                if (arr[0] == "80")
                {
                    _list.Add("http://" + arr[2].Trim());
                }
                else if (arr[0] == "443")
                {
                    _list.Add("https://" + arr[2].Trim());
                }
                else
                {
                    _list.Add("http://" + arr[2].Trim() + ":" + arr[0]);
                }

                //lista.Add(arr[1].Trim());

                //Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
            }
            _list = _list.OrderBy(s => s).ToList();
            return _list;
        }
        public static bool checkstatusProc_byName(string nameproc)
        {
            System.Threading.Thread.Sleep(1000);
            Process[] proc = Process.GetProcessesByName(nameproc);
            if (proc.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string killproc_byName(string nameproc)
        {
            string sout = "";
            System.Threading.Thread.Sleep(1000);
            Process[] proc = Process.GetProcessesByName(nameproc);

            if (proc.Count() > 0)
            {
                foreach (var p in proc)
                {
                    sout += "killing proc " + p.ProcessName + " with id " + p.Id + Environment.NewLine;
                    p.Kill();
                }
            }
            else
            {
                sout += nameproc + " not running" + Environment.NewLine;
            }
            return sout;
        }
        public static string getApplicationFolder()
        {
            string assemblyFolder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string root_folder = System.IO.Directory.GetParent(assemblyFolder).Parent.FullName;
            return root_folder;
        }
        public static string getRootFolder(System.Windows.Forms.Form f = null)
        {
            string root_folder = getApplicationFolder();
            string YN_DEBUG = getval_from_appsetting("YN_DEBUG");
            string temp_folder = getval_from_appsetting("temp_folder");
            if (YN_DEBUG.Equals("Y"))
            {
                if (!System.IO.Directory.Exists(temp_folder))
                {
                    ZampGUILib.printMsg_and_exit(temp_folder + " does not exists", true, f);
                }
                root_folder = temp_folder;
            }
            return root_folder;
        }

        public static string getRandomLorem()
        {
            Random rnd = new Random();
            string output = "";
            string[] arrAlltext =
            {
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In tempor aliquet enim at tempor. Aliquam ultricies blandit ante eu lacinia. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Duis tristique, augue non condimentum dictum, quam quam condimentum metus, id porttitor massa mi at turpis. Nulla pulvinar, lorem sed hendrerit molestie, nisl enim convallis urna, ac fringilla nunc nibh ut erat. Pellentesque fringilla at est et euismod. Aliquam bibendum magna dolor, quis dapibus justo dignissim pulvinar. Suspendisse potenti. Fusce fermentum est in pharetra accumsan. Integer convallis tortor vel lorem sollicitudin vestibulum. Aliquam turpis ligula, tempor ut sollicitudin et, dictum vitae augue. Donec maximus interdum dui, sed ultricies dolor malesuada ut."
                ,"Nulla facilisi. Sed in tortor ut dui convallis gravida. Proin elementum dui nunc, vel scelerisque ante egestas sit amet. Nunc rutrum elit leo, vitae condimentum ante rhoncus a. Aenean tristique mi et orci dapibus egestas. Nam scelerisque tellus vitae lorem suscipit, id hendrerit sem pulvinar. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Quisque nec felis non ex consequat fringilla. Maecenas mattis lacinia turpis, eu fermentum massa lobortis non."
                ,"In bibendum mauris ligula, sit amet viverra velit pulvinar ut. Phasellus felis tellus, aliquet quis ante a, gravida ultricies nulla. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec eu blandit libero. Proin velit sapien, pretium id suscipit vitae, blandit vel dolor. Sed sollicitudin lectus lacus, quis pretium diam pharetra ut. Proin mollis ligula a enim eleifend commodo. Proin efficitur urna ut libero congue laoreet. Etiam tempus vehicula lacus et gravida. Donec blandit purus et dignissim semper. Proin venenatis tincidunt neque in volutpat. Donec vulputate nisi eu interdum accumsan. Suspendisse sed feugiat justo, eu volutpat purus."
                ,"Sed quis justo cursus, aliquet justo sit amet, dignissim justo. Vivamus commodo leo nec felis volutpat, lacinia commodo dui ultrices. Sed sodales mauris sem, ac commodo nisl eleifend et. Donec ultrices nisi volutpat libero hendrerit, convallis euismod diam sodales. Aenean eleifend fringilla ipsum, ut commodo sapien tristique ut. Maecenas elementum, ipsum pharetra vestibulum elementum, turpis justo suscipit dolor, sed scelerisque lorem lacus id enim. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis elementum est. Vestibulum congue sed lectus varius pulvinar. Nulla sit amet sem orci. Curabitur hendrerit eros felis, ac pellentesque erat pulvinar et. Nullam fermentum urna nec justo vulputate dapibus. Aenean eget ultricies nisi, quis commodo risus."
                ,"Sed pellentesque, velit in maximus tristique, elit erat lobortis mauris, ut ultricies urna arcu id augue. Suspendisse ultricies, mauris ac ullamcorper consectetur, tortor urna tristique velit, in varius nunc dui eu metus. Nunc posuere eu arcu ac dignissim. Nullam aliquet odio id erat mattis vestibulum. Pellentesque malesuada eros ipsum, id interdum libero efficitur vel. Ut congue eget nisl sit amet pharetra. Mauris venenatis vel tortor at faucibus. Sed blandit, magna ac vehicula dignissim, dolor mauris ullamcorper nisi, nec pharetra quam elit sed ex. Vestibulum ut turpis fermentum risus pellentesque ultricies eget sit amet metus. Donec consequat nulla augue, sed auctor sapien eleifend et. Ut pellentesque, eros sit amet laoreet vulputate, eros erat scelerisque urna, non venenatis urna felis in massa. Maecenas congue aliquam sapien, nec scelerisque est porttitor non. Aliquam erat volutpat. Sed lectus velit, dapibus nec dolor quis, commodo imperdiet enim. Integer imperdiet aliquam nisi ac posuere. Nulla quis pretium sem, vitae rhoncus lorem."
                ,"Sed porta elit non arcu hendrerit, ut laoreet lorem tempor. Nam imperdiet dictum dui, in sagittis mi molestie nec. Donec congue imperdiet est id pharetra. Integer mollis dolor vitae commodo pulvinar. Aliquam in fermentum nibh. Curabitur ut turpis a nisi aliquam congue eu id lacus. Sed vehicula sodales nisl sit amet ultrices. Fusce vitae ligula varius arcu eleifend eleifend. Phasellus et euismod ante, sed efficitur arcu. Suspendisse ut leo eu metus gravida semper. Donec egestas eros quam, venenatis convallis dolor porttitor quis. Fusce vel laoreet augue. In interdum nibh ut augue luctus maximus. Vestibulum quis nibh in purus volutpat finibus. Fusce tincidunt sit amet diam eu bibendum. Ut ullamcorper et velit vel vestibulum."
                ,"Morbi metus elit, gravida id ultricies et, convallis sed nulla. Donec ut tellus ipsum. Nam varius dictum nisl at hendrerit. Donec porttitor dui sed risus pellentesque, tempor rutrum lectus commodo. In hac habitasse platea dictumst. Nulla pellentesque scelerisque eros eu gravida. Suspendisse ac posuere tellus. Donec vehicula arcu sed sodales fermentum. Nunc ut rutrum sem, a consequat dolor. Nullam at sollicitudin nisi. Phasellus rhoncus sem lorem, id fringilla magna efficitur nec. Vivamus mattis nisi vitae justo fermentum, a lobortis lacus ullamcorper. Morbi sed nisl sit amet mauris ullamcorper maximus ac quis dui. Praesent lorem quam, scelerisque at maximus vitae, imperdiet nec nulla. Mauris vulputate volutpat ipsum, quis sollicitudin ex rutrum dictum."
                ,"Suspendisse sed nisi metus. Praesent congue fermentum luctus. Fusce sagittis velit ligula, eu rutrum sapien pellentesque vel. Suspendisse posuere maximus euismod. Suspendisse porta tellus mauris, vitae accumsan dolor imperdiet sit amet. Morbi dapibus volutpat arcu quis condimentum. Morbi vestibulum sit amet ante id rutrum. Integer dolor dolor, varius eget erat ac, lobortis tincidunt sem. Praesent placerat est eu augue blandit sodales. Morbi venenatis ligula ac erat maximus dictum. Phasellus pulvinar rutrum tincidunt. Quisque ultricies fermentum mauris id dictum."
                ,"Cras rutrum in massa eu iaculis. Vivamus quis aliquet nibh. Vivamus eget risus a tortor posuere aliquam. In non orci non purus feugiat auctor sed ac mi. Praesent aliquet vitae odio eu facilisis. Morbi ac pretium ante. Integer malesuada odio et mauris finibus, in tempus quam egestas. Suspendisse neque nisl, mattis sed eros et, finibus mattis massa."
                ,"Ut mi libero, facilisis nec elit pulvinar, fringilla rhoncus augue. Quisque rutrum a velit vitae feugiat. Sed et quam nibh. Vestibulum vel sem nisi. Vestibulum massa dui, malesuada id ligula vitae, lobortis porta eros. Quisque id ornare justo, ac ornare ipsum. In sed erat feugiat, tincidunt leo in, faucibus odio. Mauris porta elementum commodo."
                ,"Nullam dapibus risus at pellentesque vulputate. Cras id risus at metus consequat congue quis ut nulla. Vestibulum varius, risus et venenatis consectetur, mauris eros dictum sem, sit amet molestie eros nibh non odio. Maecenas quis lorem eget arcu fringilla tristique. Proin aliquam, sem quis consectetur venenatis, urna neque venenatis enim, et pharetra leo ex at risus. Praesent in quam id mi accumsan pellentesque. Nam mauris tellus, molestie non mi vitae, placerat rhoncus est. Cras nec dui eget magna congue elementum. Duis scelerisque justo et nulla semper, ut sagittis nulla sagittis. Vivamus consequat dui metus, vitae iaculis leo placerat at. Suspendisse eget nunc congue purus interdum bibendum et ut purus. Pellentesque ut ex egestas mauris molestie consequat non lacinia neque. Sed viverra odio magna, blandit sagittis justo mollis id. Interdum et malesuada fames ac ante ipsum primis in faucibus. Curabitur scelerisque magna in ipsum hendrerit tristique."
                ,"Nunc tristique consectetur fringilla. Fusce porta, elit sit amet tristique dapibus, justo tellus rutrum turpis, quis rutrum sem tellus at dui. Donec condimentum sodales quam, in egestas libero congue ac. Maecenas tempor suscipit euismod. Ut euismod leo sed nisl mollis, vitae tristique quam sollicitudin. Quisque pellentesque finibus dolor in maximus. Morbi sit amet mi rutrum, tristique massa a, bibendum elit. Aliquam fermentum gravida nisl, eu iaculis eros placerat in. Vivamus efficitur ipsum in risus gravida semper. Vestibulum eget faucibus justo. Etiam accumsan tincidunt magna vitae pretium. Nulla nunc tortor, vestibulum non lacinia ac, vestibulum nec sem. Quisque leo magna, ultrices in ligula at, consequat facilisis est."
                ,"Nunc id justo luctus, imperdiet sapien eget, fermentum mauris. In fermentum, velit sit amet pharetra ullamcorper, massa felis porta dui, nec viverra enim elit nec eros. Proin non nisl quis lorem tincidunt porttitor. Maecenas id posuere enim. Vivamus ac mi id neque cursus congue sed nec ligula. Donec faucibus mi sed vulputate iaculis. Nam at lorem felis. Etiam at fringilla metus. Nulla semper rhoncus aliquet. Aenean sit amet ultricies eros. Mauris tincidunt euismod quam ut elementum. Aenean et quam dolor. In posuere quam eu turpis tincidunt, non gravida massa dignissim. Vivamus non pulvinar enim. Nunc efficitur tellus vitae odio tincidunt, sed dapibus tellus bibendum."
                ,"Proin efficitur viverra neque, eget mattis tortor sodales et. Sed interdum at nulla non semper. Proin luctus est mi, eget tincidunt ligula iaculis quis. Nam odio elit, aliquet aliquam enim ac, varius posuere ligula. Curabitur at malesuada tortor, eget lobortis purus. Donec egestas, mauris in dictum euismod, nisi tellus tempor nisl, sed scelerisque lorem lectus at eros. Maecenas vitae iaculis quam, dapibus pharetra magna. Vivamus rhoncus, sapien non porta tincidunt, arcu lectus laoreet tellus, non mollis ante eros at diam. Nullam posuere, felis eu fermentum blandit, mauris elit aliquet urna, eget molestie nibh eros eget orci. Morbi id ligula posuere, rutrum dui vestibulum, posuere augue."
                ,"Nunc placerat lacus eget pretium tincidunt. Nam lectus diam, tristique eget turpis quis, ornare iaculis eros. Nunc elementum, purus et congue iaculis, sapien libero varius orci, efficitur dapibus justo arcu in ipsum. Etiam luctus in dui in varius. Etiam malesuada ut est nec tristique. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Maecenas volutpat eu nunc quis molestie."
                ,"Fusce vel odio in nulla sagittis euismod. Etiam eget viverra diam. Fusce vestibulum diam dictum, dapibus metus at, gravida eros. Proin varius convallis lorem, vitae pharetra augue luctus nec. Maecenas tempor eros nec velit fringilla auctor. Vestibulum eget volutpat sapien. Nam rutrum fringilla nibh a suscipit. Fusce auctor est mollis sapien porta, eget hendrerit nisi eleifend. Mauris nulla tellus, euismod nec fermentum eu, fringilla vel lacus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce volutpat felis ac libero pulvinar, vitae blandit lectus pulvinar. Donec sit amet volutpat est, sit amet commodo dui. Praesent quis tristique ex, vel finibus felis."
                ,"Nullam porttitor id justo vehicula dictum. Cras id rutrum nunc, ut feugiat metus. Nam eleifend nunc leo, vel condimentum nisi aliquam et. Aliquam neque turpis, placerat eget tortor sed, ultrices porttitor velit. Nunc mattis, ante nec lacinia rhoncus, mi tortor ultricies est, sit amet condimentum leo arcu non risus. Proin viverra arcu quam, sit amet auctor lacus venenatis et. Quisque eleifend finibus aliquet. Nam ultrices ex tristique lobortis imperdiet. Mauris pellentesque finibus fermentum. Nullam commodo id enim sed cursus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam finibus sodales cursus. Mauris pulvinar ipsum vitae magna porta, facilisis placerat arcu sollicitudin. Aliquam sed ullamcorper massa."
                ,"Maecenas ornare sodales tellus sollicitudin mattis. Aliquam imperdiet at ipsum quis cursus. Praesent interdum tortor ac mauris dignissim placerat. Praesent luctus molestie orci, nec aliquam turpis dignissim quis. Nam sed congue dolor. Nunc sollicitudin pharetra nunc. Praesent tincidunt quam at tortor pulvinar, at fringilla arcu varius. Ut at interdum leo. Mauris nec mattis tortor. Curabitur vehicula arcu orci. Nam pulvinar, diam sit amet luctus aliquam, magna libero tristique odio, eget maximus ante odio commodo lacus. Nulla ac ultrices mi, a pellentesque justo."
                ,"Aliquam gravida arcu a diam luctus iaculis. Fusce a placerat nulla. Ut consectetur fermentum odio id mollis. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Curabitur sollicitudin neque sit amet ipsum elementum, quis commodo velit auctor. Sed non odio sit amet neque finibus viverra. Aenean vehicula mauris mauris, et accumsan lorem ultricies in. Aliquam feugiat enim vitae faucibus faucibus. Nullam eget porttitor lorem. Vivamus a risus non nisi interdum laoreet a efficitur magna. In nec odio faucibus ligula pharetra semper."
                ,"Proin sodales, nibh at finibus posuere, tortor turpis porta mauris, eu bibendum magna ligula vitae lectus. Proin molestie blandit felis, sed posuere libero congue vitae. Proin sed mi est. Mauris vulputate laoreet tellus, eget elementum ipsum vehicula vel. Curabitur tempor, metus vel facilisis sodales, ante arcu tincidunt orci, in porta ex metus vitae lorem. Ut sit amet eleifend turpis, nec aliquam justo. Curabitur sodales lorem ut nisi tempus ullamcorper. In euismod elit vel ligula sodales, id condimentum erat facilisis. Aenean condimentum dictum facilisis. Nulla placerat condimentum tortor, a consequat felis vehicula nec."
                ,"Etiam pellentesque turpis magna, sit amet fringilla eros dignissim quis. Integer ac urna id leo aliquet placerat. Quisque eget aliquet tellus. Nulla facilisi. Mauris porttitor tortor nulla, id consequat lacus pretium in. Aenean id ex vel mauris rhoncus ultrices. Nulla tincidunt magna tortor, ut tristique nibh cursus eu. Nunc consectetur venenatis leo a venenatis. Nunc finibus sem quis facilisis euismod."
                ,"Donec lacinia varius erat ut egestas. Phasellus blandit efficitur felis. In a magna ut leo venenatis placerat et eget justo. Praesent laoreet tincidunt ante ac tincidunt. Suspendisse viverra risus ac finibus ornare. Nam lacus nisi, elementum vitae velit eget, pulvinar malesuada leo. Aliquam est odio, vestibulum rutrum commodo vitae, consectetur ut ante. Vestibulum interdum pretium nisl pellentesque finibus."
                ,"Nulla tempus tempus euismod. Phasellus dictum nisl eget sapien eleifend, sit amet interdum tortor tincidunt. Praesent non cursus magna. Nulla faucibus eget enim eu commodo. Nullam in tellus vitae felis sollicitudin pulvinar sed id erat. Suspendisse egestas, arcu mattis tempus viverra, velit ligula aliquet lorem, a consequat odio quam id metus. Integer tincidunt lectus magna. Nulla maximus leo ac tortor imperdiet, at sagittis nulla pharetra. Pellentesque rutrum a mauris vitae pellentesque. Nunc dignissim ante lectus, quis hendrerit est aliquet at. Nunc ultrices cursus nisi, sed dapibus est facilisis sit amet. Aenean et elementum purus."
                ,"In facilisis neque vel ante lacinia rutrum. Suspendisse potenti. Suspendisse egestas odio justo, sit amet ultrices erat malesuada non. Cras nec erat enim. Donec sollicitudin efficitur nisl at dictum. Curabitur vitae fermentum ante, ac commodo diam. Vivamus massa ex, imperdiet eget maximus ac, fermentum et risus. In eget aliquet mauris."
                ,"Praesent sollicitudin suscipit orci nec dictum. Donec dignissim varius rutrum. Praesent felis nisl, fermentum at tincidunt eu, consectetur ac dolor. Sed pretium, ante vitae hendrerit porta, nisl eros rutrum nibh, in luctus leo nunc in est. Duis laoreet eros ipsum, nec molestie augue luctus vitae. Nulla fermentum rutrum nisi sit amet posuere. Donec tellus felis, vulputate interdum nunc id, finibus fermentum ante. Proin dictum diam at lorem rutrum imperdiet."
                ,"Vivamus dolor massa, blandit non ultrices at, varius nec ligula. Fusce ut condimentum lacus, et viverra odio. Nam nec tellus nec magna vulputate porttitor auctor sed justo. Aenean pretium ipsum quis dolor dictum, at vulputate elit dignissim. Quisque sit amet neque pretium eros pharetra mollis a vel massa. Donec nisi quam, porta sed dui ac, rhoncus posuere nunc. In hac habitasse platea dictumst. Aliquam vehicula sapien quis magna posuere gravida. Sed porttitor lectus nec elit tristique elementum. Aenean lacinia sit amet elit vitae finibus. Sed vitae bibendum urna. Sed fringilla ligula at dictum tempor. Aenean elementum sem metus, in lacinia ipsum aliquet at."
                ,"Phasellus rhoncus urna vel erat lobortis pellentesque. Donec feugiat eleifend euismod. Quisque quis mauris at sapien varius feugiat a finibus risus. Maecenas lacus velit, consequat vel massa condimentum, convallis mattis ex. Mauris cursus elementum augue a vehicula. Sed varius dui orci, at dictum arcu rutrum nec. Nunc fermentum, turpis at commodo dapibus, purus ex scelerisque urna, eget maximus nulla urna nec nisl. Nam posuere mi ante, nec imperdiet turpis consequat eu."
                ,"Maecenas eu justo vel quam aliquam sollicitudin ac sit amet elit. Mauris dictum, libero ut mollis ultrices, arcu enim blandit ipsum, vitae mattis augue justo a ligula. Vivamus ullamcorper condimentum leo, vitae maximus tortor imperdiet in. Proin porta facilisis massa, nec tincidunt velit tincidunt nec. Etiam dapibus quam eu neque imperdiet posuere nec id purus. Nunc et odio ipsum. Cras lacinia ante a purus ullamcorper, a lacinia purus mollis."
                ,"Proin enim erat, viverra nec cursus eget, dapibus at odio. Donec facilisis venenatis augue et gravida. Nulla tristique eros sodales felis pretium faucibus sit amet at erat. Sed sagittis rhoncus pellentesque. In cursus porta ullamcorper. Maecenas id metus sit amet nisl volutpat placerat vel sit amet nisi. Donec consequat, erat nec consequat rutrum, tortor ligula commodo justo, eget gravida leo erat in libero. Sed euismod sem sed efficitur aliquam. Aenean sit amet luctus lorem. Curabitur nisi ex, maximus quis dolor id, hendrerit pharetra dui. Curabitur quis elit ac nulla mollis gravida. Pellentesque sed sapien lobortis, ullamcorper lacus eget, auctor tellus. Donec vel velit rhoncus, imperdiet dolor quis, volutpat eros. Duis sit amet semper tellus. Morbi nibh quam, lobortis eu arcu ut, aliquet malesuada sem."
                ,"Sed mi sapien, fermentum imperdiet orci at, efficitur faucibus ipsum. Vestibulum rutrum ornare lacus ac ornare. Mauris semper et lectus id sagittis. Vestibulum tortor sem, venenatis in semper non, consequat fermentum arcu. Etiam aliquam rhoncus tortor in convallis. Etiam luctus nulla quis massa lobortis placerat. Aliquam augue orci, pulvinar nec mi in, gravida maximus purus."
                ,"Vestibulum tristique tincidunt pharetra. Aliquam varius eu massa sit amet sodales. Vivamus mattis leo magna, nec fermentum orci rutrum pulvinar. Sed ac consequat enim. Suspendisse aliquet felis lacus, at ultrices ante sodales non. Etiam vitae porta ligula. Duis tincidunt vehicula neque, ac fringilla augue sagittis gravida. Cras vel rutrum purus. Pellentesque laoreet lectus sem. Donec fermentum scelerisque nibh, lacinia pretium magna sollicitudin et. Fusce tincidunt ex non turpis maximus egestas. Fusce eros justo, commodo eu pellentesque vitae, auctor tincidunt est. Ut sit amet tempus purus. Aenean pretium lacus in elit rhoncus accumsan. Morbi accumsan, metus a ultrices posuere, felis sapien finibus justo, vitae fermentum massa urna at tellus. Cras placerat nibh ut tempus gravida."
                ,"Fusce ut leo vehicula, molestie sapien ac, venenatis risus. Fusce faucibus magna id eros accumsan congue. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Etiam ante magna, dictum ut eros non, molestie tempor libero. Donec rutrum hendrerit risus ut gravida. Vestibulum aliquet gravida hendrerit. Vivamus mollis ex tellus. Aenean dictum orci vitae tortor condimentum, et efficitur erat congue. In finibus massa eget velit ullamcorper tempor. Nulla imperdiet ornare laoreet. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam suscipit augue nec nulla rutrum, ac rutrum nisl ornare. Praesent id hendrerit magna. Praesent ut vulputate arcu. Curabitur congue gravida luctus."
                ,"Ut id accumsan diam, at fermentum nisl. Nullam quam massa, rutrum ut ornare sit amet, aliquet ac nisl. Sed velit turpis, fringilla nec vestibulum eu, maximus ac risus. Integer finibus ex purus, quis ultrices nibh sollicitudin at. Nam molestie mattis libero, vitae maximus turpis auctor sed. Morbi vitae egestas nunc. Ut tempus metus in ullamcorper porta. Quisque venenatis aliquet sapien, elementum aliquam lacus efficitur in. Cras at odio varius, luctus purus quis, tempus augue. Aliquam bibendum est vitae lorem pretium elementum. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam lacinia euismod dui. Sed rhoncus lacus eget dignissim interdum. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Quisque eget condimentum enim. Aenean finibus luctus hendrerit."
                ,"Praesent sit amet ex vel nunc pulvinar congue ut sed nulla. Fusce non libero id metus maximus dignissim. Sed condimentum arcu non tempus commodo. Ut vestibulum sed erat nec finibus. Etiam laoreet imperdiet velit, eu rhoncus urna suscipit non. Proin finibus libero ipsum, imperdiet eleifend magna placerat quis. In nec sollicitudin ligula. Cras porttitor vitae dolor eu mollis. Sed egestas convallis eros, sit amet bibendum urna tincidunt in. Ut eu massa est. Proin molestie risus et turpis venenatis semper."
                ,"In eget accumsan lectus. Nulla in viverra leo, eget accumsan purus. Praesent viverra nulla ac quam fermentum, at ullamcorper ex condimentum. Phasellus vel posuere lacus. Morbi eleifend diam ut varius congue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer cursus elit ac justo varius posuere. Ut cursus nulla at lacinia dapibus. Nullam ligula felis, pharetra a magna vel, euismod condimentum ex. Donec id venenatis lectus, nec consequat leo. Nulla dignissim metus ac ullamcorper imperdiet. Curabitur accumsan ipsum urna, eget bibendum enim commodo ac. Cras elementum non dui sollicitudin eleifend."
            };

            int numSentences = rnd.Next(1, arrAlltext.Length);
            output = arrAlltext[numSentences-1];
            return output;
        }
        #region old

        private string startProc_old(string nameproc, string pathProg)
        {
            string sout = "";
            Process[] proc = Process.GetProcessesByName(nameproc);
            if (proc.Count() == 0)
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = pathProg;
                //psi.Arguments = "/C start notepad.exe";
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                var proc1 = Process.Start(psi);
                sout += "Starting " + proc1.Id + " " + nameproc + Environment.NewLine;
            }
            else
            {
                sout += "Process " + nameproc + " is already running" + Environment.NewLine;
            }
            return sout;
        }
        
        public static bool ExecuteBatchFile_OLD(string batchFileName, string[] argumentsToBatchFile)
        {
            string argumentsString = string.Empty;
            try
            {
                //Add up all arguments as string with space separator between the arguments
                if (argumentsToBatchFile != null)
                {
                    for (int count = 0; count < argumentsToBatchFile.Length; count++)
                    {
                        argumentsString += " ";
                        argumentsString += argumentsToBatchFile[count];
                        //argumentsString += "\"";
                    }
                }

                //Create process start information
                System.Diagnostics.ProcessStartInfo DBProcessStartInfo = new System.Diagnostics.ProcessStartInfo(batchFileName, argumentsString);

                //Redirect the output to standard window
                DBProcessStartInfo.RedirectStandardOutput = true;

                //The output display window need not be falshed onto the front.
                DBProcessStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                DBProcessStartInfo.UseShellExecute = false;

                //Create the process and run it
                System.Diagnostics.Process dbProcess;
                dbProcess = System.Diagnostics.Process.Start(DBProcessStartInfo);

                //Catch the output text from the console so that if error happens, the output text can be logged.
                System.IO.StreamReader standardOutput = dbProcess.StandardOutput;

                /* Wait as long as the DB Backup or Restore or Repair is going on. 
                Ping once in every 2 seconds to check whether process is completed. */
                while (!dbProcess.HasExited)
                    dbProcess.WaitForExit(2000);

                if (dbProcess.HasExited)
                {
                    string consoleOutputText = standardOutput.ReadToEnd();
                    //TODO - log consoleOutputText to the log file.

                }

                return true;
            }
            // Catch the SQL exception and throw the customized exception made out of that
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                //throw new CustomizedException(ARCExceptionManager.ErrorCodeConstants.generalError, ex.Message);
                return false;
            }
        }
        #endregion
    }
}
