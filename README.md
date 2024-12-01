  This is a Windows Form application that uses ASCOM to connect to a telescope mount and an observing conditions device.
  There are five tabs:
  
Mount (connect / disconnect / park / unpark / home / abort mount) with status flags and readouts.
also includes a jog feature, allowing one to jog the mount in specified amounts. The homing and parking routines 
accommodate some of the idiosynchracies of the mount.

Weather (connect / disconnect) with 8 readouts (I uses this with the latest AAG Cloudwatcher)
  
Graphs - graphs of last two hours of some of the more important enviromental data
  
Pol. Algn.  - polar alignment utility for use with PoleMaster or SharpCap Pro - homes mount and then moves
RA by 45 degrees to starting point, another button shifts in 45 degrees the other way, for PA measurements

Setup - choosers for mount and weather device, readout and/or update of location, time, guide rate
