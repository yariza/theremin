s.boot

NetAddr.langPort;

s.free


v = 0;
f = 440;

x = { arg vol =0, pitch = 440 ; vol * SinOsc.ar(pitch,0,1,0)}.play;

o = OSCFunc({ 'increaseVol'.postln; 'hi'.postln; v = v + 0.01; x.set(\vol, v); }, '/foo1');

p = OSCFunc({ 'decreaseVol'.postln; 'hi'.postln; v = v - 0.01; x.set(\vol, v); }, '/foo2');

q = OSCFunc({ 'increasePitch'.postln; 'hi'.postln; f = f - 1; x.set(\pitch, f); }, '/foo3');

r = OSCFunc({ 'decreasePitch'.postln; 'hi'.postln; f = f + 1; x.set(\pitch, f); }, '/foo4');


x.play;
x.free

