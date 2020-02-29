using System;
using Entitas;
using Entitas.Generic;

namespace MERunner
{
	public struct Some : IComponent, ICompData, Scope<Main>
	{
		public string value;

		public Some( String value)
		{
			this.value = value;
		}
	}
}