using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APanel.MVVM.Model
{
    internal class ConsoleModel
    {
        private readonly StartupModel startupModel;

        public string Name { get; }

        public ConsoleModel()
        {
            startupModel = new StartupModel("", "", "");
        }
    }
}
