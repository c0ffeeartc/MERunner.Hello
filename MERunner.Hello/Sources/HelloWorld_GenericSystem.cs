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
public sealed class Factory_HelloWorld_GenericSystem : TSystem_Factory<HelloWorld_GenericSystem> { }

	[Guid("024DB39B-12D1-471E-B6D2-5078F5543F5F")]
	public class HelloWorld_GenericSystem : ReactiveSystem<Ent>
	{
		public				HelloWorld_GenericSystem	( Contexts contexts ) : base( contexts.Get<Settings>() )
		{
			_contexts			= contexts;
		}

		public				HelloWorld_GenericSystem	(  ) : this( Hub.Contexts )
		{
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
			ent.Add_( new Some( ">> Hello world system" ) );
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