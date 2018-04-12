using System;
using System.Collections.Generic;
using Entitas;
using Debug = UnityEngine.Debug;

public class TickUpdateSystem : IInitializeSystem, IExecuteSystem
{
    private readonly GameContext _context;

    public TickUpdateSystem(GameContext context)
    {
        _context = context;
    }

    public void Initialize()
    {
        _context.ReplaceTickComponents(0);
    }

    public void Execute()
    {
       _context.ReplaceTickComponents(_context.tickComponents.currentTic+1);
    }
}

public class NotifyTickListenerSystem : ReactiveSystem<GameEntity>
{
    private Group<GameEntity> listener;
    
    public NotifyTickListenerSystem(IContext<GameEntity> context) : base(context)
    {
        context.GetGroup(GameMatcher.TickListener);
    }
    
   
    
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.TickComponents.AddedOrRemoved());
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in listener.GetEntities())
        {
            entity.tickListener.listener.TickChanged();
        }
    }

}

public class DebugMessageSystem : ReactiveSystem<GameEntity>
{
    public DebugMessageSystem(IContext<GameEntity> context) : base(context)
    {
    }

    public DebugMessageSystem(ICollector<GameEntity> collector) : base(collector)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.DebugMessage);
    }

    protected override bool Filter(GameEntity entity)
    {
       return entity.hasDebugMessage;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            Debug.Log(entity.debugMessage);
        }
    }
}