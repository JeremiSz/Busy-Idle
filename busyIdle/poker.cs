using System;
using System.Runtime.InteropServices;

namespace busyIdle;

class poker
{
	[Flags]
	private enum EXECUTION_STATE : uint
	{
		ES_AWAYMODE_REQUIRED = 0x40u,
		ES_CONTINUOUS = 0x80000000u,
		ES_DISPLAY_REQUIRED = 2u,
		ES_SYSTEM_REQUIRED = 1u
	}

	private Random random;

	private int maxX;

	private int maxY;

	public poker(int maxX, int maxY)
	{
		random = new Random(DateTime.Now.Second);
		this.maxX = maxX;
		this.maxY = maxY;
	}

	public int[] poke(bool keepWake)
	{
		int num = random.Next(0, maxX);
		int num2 = random.Next(0, maxY);
		SetCursorPos(num, num2);
		SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED);
		if (keepWake)
		{
			SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED);
		}
		return new int[2] { num, num2 };
	}

	[DllImport("user32.dll")]
	private static extern bool SetCursorPos(int x, int y);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlag);
}
