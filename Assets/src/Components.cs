using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game,Unique]
public class TickComponents : IComponent
{
    public long currentTic;
}

public interface ITickListener {
    void TickChanged();
}

[Game]
public class TickListenerComponent : IComponent {
    public ITickListener listener;
}

[Game]
public class DebugMessageComponent : IComponent
{
    public string message;
}