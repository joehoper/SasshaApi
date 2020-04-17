using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeyExampleApp
{
    public class DocumentLocation
    {
        public string Context { get; private set; }
        public string Id { get; private set; }

        public DocumentLocation(string context, string id)
        {
            Context = context;
            Id = id;
        }

        public override string ToString() => $"{Context}/{Id}";
    }
}