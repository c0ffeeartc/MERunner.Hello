using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Runtime.InteropServices;
using Entitas;
using Entitas.Generic;
using Ent = Entitas.Generic.Entity<Settings>;

namespace MERunner
{
[Export(typeof(ISystem_Factory))]
public sealed class Factory_HelloWorld_System : TSystem_Factory<HelloWorld_System> { }

	[Guid("024DB39B-12D1-471E-B6D2-5078F5543F5F")]
	public sealed class HelloWorld_System : ReactiveSystem<Ent>
	{
		public				HelloWorld_System	( Contexts contexts ) : base( contexts.Get<Settings>() )
		{
			_contexts			= contexts;
		}

		private				Contexts				_contexts;

		protected override	ICollector<Ent>			GetTrigger				( IContext<Ent> context )
		{
			return context.CreateCollector( Matcher_<Settings, SettingsDict>.I );
		}

		protected override	Boolean					Filter					( Ent entity )
		{
			return entity.Has_<SettingsDict>();
		}

		protected override	void					Execute					( List<Ent> ents )
		{
			var ent					= _contexts.Get<Main>().CreateEntity();
			ent.Add_( new Some( $">> {nameof(HelloWorld_System)}" ) );
			Console.WriteLine( ent.Get_<Some>(  ).value );

			var dict				= _contexts.Get<Settings>().Get_<SettingsDict>().Dict;
			var key					= "HelloWorld";
			if( !dict.ContainsKey( key ) )
			{
				Console.WriteLine( $"No key \"{key}\" in settings file" );
				return;
			}

			for ( var i = 0; i < dict[key].Count; i++ )
			{
				var s = dict[key][i];
				Console.WriteLine( $"{key}[{i}] = {s}" );
			}
		}
	}
}