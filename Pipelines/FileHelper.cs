using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary; //for binary formater
using System.IO; //for serilization expection
using System.Runtime.Serialization; //for serilization expection
using System.Windows.Forms;

namespace Pipelines
{
    class FileHelper
    {
        /// <summary>
        /// reads the object from specific class 
        /// </summary>
        private PipelineGround pg;


        /// <summary>
        /// constructor of specific class
        /// </summary>

        public FileHelper()
        {
            pg = new PipelineGround();
        }

        /// <summary>
        /// reads the manual from specific file and return list<string>
        /// </summary>
        /// <returns></returns>

        public List<string> GettingManual()
        {
            FileStream fs = new FileStream("Manual.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            List<string> manual = new List<string>();
            string s = sr.ReadLine();
            while (s != null)
            {
                manual.Add(s);
                s = sr.ReadLine();
            }
            sr.Dispose();
            fs.Dispose();
            return manual;
        }
        /// <summary>
        ///  save the project to a file as a binary format.
        /// user will give the filepath and the object that need to save as two paramaters.
        /// </summary>
        /// <returns></returns>
        public void SaveToFile(string filepath, PipelineGround p)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write);
            fs.SetLength(0);
            bf.Serialize(fs, p);
            fs.Dispose();
        }
        /// <summary>
        ///  reads a project and load  from a file.
        /// if the file selected is not a valid file, then return null.
        /// otherwise read the file and return the object with type of "pipeground".
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>the object created above (pipeground object mani)</returns>
        /// </summary>
        /// <returns></returns>
        public PipelineGround LoadFromFile(string filepath)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                if (fs.Length == 0)
                    pg = null;
                else
                    pg = (PipelineGround)bf.Deserialize(fs);
                fs.Dispose();
                return pg;
            }
            catch (Exception)
            {
                MessageBox.Show("Not a valid file!");
                return null;
            }
        }
    }
}
