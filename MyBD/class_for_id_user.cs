using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBD
{
    class class_for_id_user
    {
        static private string id_user;
        static private string buffer;
       
        public void set_doc(string doc)
        {
            buffer = doc;
        }
        public string get_buffer() 
        {
            return buffer;
        }
        public void set_Id(string id) {

            id_user = id;
        
        }

      
        public string get_idUser()
        {
            return id_user;
        }

     



    }
}
