using System;
using UnityEngine;

public class CountUpTimer {
	float _startTime;
	float? _snapshot = 0f;
	Func<float> _time;

	public CountUpTimer(Func<float> time = null) {
		_time = time ?? (() => Time.time);
	}

	public bool isRunning {
		get { return _snapshot == null; }
	}

	public float elapsed {
		get { return _snapshot ?? (_time() - _startTime); }
	}

	public Func<float> time {
		get { return _time; }
		set { _time = value; }
	}

	public static CountUpTimer StartNew(Func<float> time = null) {
		var timer = new CountUpTimer(time);
		timer.Start();
		return timer;
	}

	public void Start() {
		_startTime = _time() - (_snapshot ?? 0f);
		_snapshot = null;
	}

	public void Stop() {
		_snapshot = elapsed;
	}

	public void Reset() {
		_snapshot = 0f;
	}

	public void Restart() {
		Reset();
		Start();
	}
}
