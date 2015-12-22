using System;
using UnityEngine;

public class CountDownTimer {
	float _startTime = 0f;
	CountUpTimer _countUpTimer;

	public CountDownTimer(Func<float> time = null) {
		_countUpTimer = new CountUpTimer(time);
	}

	public float startTime {
		get { return _startTime; }
	}

	public bool isRunning {
		get { return _countUpTimer.isRunning; }
	}

	public float current {
		get { return Mathf.Max(0f, _startTime - _countUpTimer.elapsed); }
	}

	public bool isZero {
		get { return current <= 0f; }
	}

	public static CountDownTimer StartNew(float startTime, Func<float> time = null) {
		var timer = new CountDownTimer(time);
		timer.Start(startTime);
		return timer;
	}

	public void Start(float startTime) {
		_startTime = startTime;
		_countUpTimer.Start();
	}

	public void Stop() {
		_startTime = 0f;
		_countUpTimer.Stop();
	}

	public void Reset() {
		_startTime = 0f;
		_countUpTimer.Reset();
	}

	public void Restart(float time) {
		Reset();
		Start(time);
	}
}
