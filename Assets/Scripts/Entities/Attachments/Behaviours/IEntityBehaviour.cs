public interface IEntityBehaviour : IEntityAttachment {

    /// <summary>
    /// Will be called upon initialization of this behaviour.
    /// </summary>
    void OnInitialize ();

    /// <summary>
    /// Will be called every update tick.
    /// </summary>
    void OnUpdate ();

    /// <summary>
    /// Queries the tick length of this behaviour, i.e. how often its OnUpdate function should be called.
    /// </summary>
    /// <returns>A double representing the tick length of this behaviour.</returns>
    float GetTickLength ();

}
