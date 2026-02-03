using SmartHomeLib;

var hub = new SmartHomeHub();

// You will add your devices here once you implement them.
// Example flow you should be able to run by the end:
// - create devices
// - SetOnline(true)
// - TurnOn()
// - ApplyModeToAll("Night")
// - PrintAllStatuses()
var light = new SmartLight("L1", "Living Room Light");
var thermostat = new SmartThermostat("T1", "Hallway Thermostat");
var camera = new SecurityCamera("C1", "Front Door Camera",100000);

hub.AddDevice(light);
hub.AddDevice(thermostat);
hub.AddDevice(camera);

light.SetOnline(true);
thermostat.SetOnline(true);
camera.SetOnline(true);

light.TurnOn();
thermostat.TurnOn();
camera.TurnOn();

hub.ApplyModeToAll("Night");
hub.PrintAllStatuses();