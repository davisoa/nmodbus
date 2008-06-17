using System.IO.Ports;
using System.Diagnostics;
using System;

namespace Modbus.IO
{
	/// <summary>
	/// Concrete Implementor - http://en.wikipedia.org/wiki/Bridge_Pattern
	/// </summary>
	internal class SerialPortAdapter : IStreamResource
	{
		private readonly SerialPort _serialPort;

		public SerialPortAdapter(SerialPort serialPort)
		{
			Debug.Assert(serialPort != null, "Argument serialPort cannot be null.");
			
			_serialPort = serialPort;
			NewLine = Environment.NewLine;
		}

		public int InfiniteTimeout
		{
			get { return SerialPort.InfiniteTimeout; }
		}

		public int ReadTimeout
		{
			get { return _serialPort.ReadTimeout; }
			set { _serialPort.ReadTimeout = value; }
		}

		public int WriteTimeout
		{
			get { return _serialPort.WriteTimeout; }
			set { _serialPort.WriteTimeout = value; }
		}

		public string NewLine
		{
			get { return _serialPort.NewLine; }
			set { _serialPort.NewLine = value; }
		}

		public void DiscardInBuffer()
		{
			_serialPort.DiscardInBuffer();
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return _serialPort.Read(buffer, offset, count);
		}

		public string ReadLine()
		{
			return _serialPort.ReadLine();
		}

		public void Write(byte[] buffer, int offset, int count)
		{
			_serialPort.Write(buffer, offset, count);
		}
	}
}