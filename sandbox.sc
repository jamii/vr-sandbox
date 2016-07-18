	(

	SynthDef("tutorial-args", { arg freq = 440, out = 0, vol = 1;

		Out.ar(out, SinOsc.ar(freq, 0, 0.2) * vol);

	}).send(s);

	);

/*	x = Synth("tutorial-args");							// no args, so default values

	y = Synth("tutorial-args", ["freq", 660]);			// change freq

	z = Synth("tutorial-args", ["freq", 880, "out", 1]);	// change freq and output channel

	x.free; y.free; z.free;*/
/*
s.sendMsg("/s_new", "tutorial-args", x = s.nextNodeID, 1, 1, "freq", 900);*/

s.sendMsg("/dumpOSC", 1);