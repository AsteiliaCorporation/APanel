﻿using APanel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APanel.Helpers
{
    public class Navigation
    {
        public event Action CurrentViewModelChanged;

		private BaseViewModel _currentViewModel;

		public BaseViewModel CurrentViewModel
		{
			get { return _currentViewModel; }
			set
			{
				_currentViewModel = value;

				OnCurrentViewModelChanged();
			}
		}

		private void OnCurrentViewModelChanged()
        {
			CurrentViewModelChanged?.Invoke();
		}
	}
}
