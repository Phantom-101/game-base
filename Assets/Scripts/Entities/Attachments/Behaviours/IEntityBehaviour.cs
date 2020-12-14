public interface IEntityBehaviour : IEntityAttachment {

    /// <summary>
    /// Will be called upon initialization of this behaviour.
    /// </summary>
    void OnInitialize ();

    /// <summary>
    /// Will be called every update tick.
    /// </summary>
    void OnUpdate ();

}
