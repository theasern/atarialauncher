using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atarialauncher
{
    class AuthorManifiest
    {
        public class AssemblyAuthorAttribute : Attribute
        {
            private string _author;

            public string Author
            {
                get { return _author; }
                set { _author = value; }
            }


            public AssemblyAuthorAttribute(string author)
            {
                _author = author;
            }

        }
    }
}
