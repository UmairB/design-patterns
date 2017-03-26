namespace DesignPatterns.Mediator.After
{
	public interface IAirTrafficControl
    {
        void ReceiveAircraftLocation(Aircraft aircraft);

        void RegisterAircraftUnderGuidance(Aircraft aircraft);
    }
}
