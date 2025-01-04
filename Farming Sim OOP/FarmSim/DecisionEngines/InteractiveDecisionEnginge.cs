
public class InteractiveDecisionEngine : DecisionEngine
{
    public override INavigator<T> GetNavigator<T>(IMenu<T> menu, IDisplay display)
        => new InteractiveNavigator<T>(menu, display);
}