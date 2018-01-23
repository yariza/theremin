s.boot;

v = 0;
f = 440;

(x = {
    arg vol =0, pitch = 440 ;
    VarLag.kr(
        vol,
        0.032, // 30 hz
        0,
        \squared,
    ) *
    SinOsc.ar(
        VarLag.kr(
            pitch,
            0.032, // 30 hz
            0,
            \squared
        )
    )
}.play);

o = OSCFunc({ 'increaseVol'.postln; 'hi'.postln; v = v + 0.01; x.set(\vol, v); }, '/foo1');

p = OSCFunc({ 'decreaseVol'.postln; 'hi'.postln; v = v - 0.01; x.set(\vol, v); }, '/foo2');

q = OSCFunc({ 'increasePitch'.postln; 'hi'.postln; f = f - 1; x.set(\pitch, f); }, '/foo3');

r = OSCFunc({ 'decreasePitch'.postln; 'hi'.postln; f = f + 1; x.set(\pitch, f); }, '/foo4');

(OSCFunc({
    arg msg, time, addr, recvPort;
    x.set(\pitch, msg[1]);
}, '/pitch'));

(OSCFunc({
    arg msg, time, addr, recvPort;
    x.set(\vol, msg[1]);
}, '/amplitude'));


// x.play;
// x.free

