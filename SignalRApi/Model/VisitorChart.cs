using System.Collections.Generic;

namespace SignalRApi.Model
{
	public class VisitorChart
	{
		public VisitorChart()
		{

		}
		public string VisitDate { get; set; }
	
	    public List<int> Counts { get; set; }	
	}
}
