using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APanel.MVVM.Model
{
    internal class StartupModel
    {
        private readonly string startupCommand;
        private readonly string serverJarFileName;
        private readonly string serverVersion;

        public StartupModel(string startupCommand, string serverJarFileName, string serverVersion)
        {
            this.startupCommand = startupCommand;
            this.serverJarFileName = serverJarFileName;
            this.serverVersion = serverVersion;
        }
    }
}
