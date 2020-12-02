public interface IEntityBehaviour : IEntityAttachment {

    /// <summary>
    /// This function will be called upon initialization of this behaviour.
    /// </summary>
    void OnInitialize ();

    /// <summary>
    /// This function will be called every update tick.
    /// </summary>
    void OnUpdate ();

}
