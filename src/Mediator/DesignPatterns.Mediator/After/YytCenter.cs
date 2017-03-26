using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Mediator.After
{
	public class YytCenter : IAirTrafficControl
    {
        private readonly HashSet<Aircraft> _aircraftUnderGuidance;                

        public YytCenter()
        {
            _aircraftUnderGuidance = new HashSet<Aircraft>();
        }

        public void ReceiveAircraftLocation(Aircraft aircraft)
        {
            foreach (var currentAircraftUnderGuidance in _aircraftUnderGuidance.Where(a => a != aircraft))
            {
                if (Math.Abs(currentAircraftUnderGuidance.Altitude - aircraft.Altitude) < 1000)
                {
                    currentAircraftUnderGuidance.Climb(1000);
                    // communicate to the object
                    currentAircraftUnderGuidance.WarnOfAirspaceIntrusionBy(aircraft);
                }
            }
        }

        public void RegisterAircraftUnderGuidance(Aircraft aircraft)
        {
            _aircraftUnderGuidance.Add(aircraft);
        }
    }
}
