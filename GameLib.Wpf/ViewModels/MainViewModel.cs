using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simpler.Net.Wpf;

namespace GameLib.Wpf.ViewModels {
	public class MainViewModel : Bindable {
		private String _activityText;

		public String ActivityText
		{
			get => this._activityText;
			set => this.SetAndNotify(ref this._activityText, value);
		}
	}
}
