public interface IEntityData : IEntityAttachment {

    /// <summary>
    /// Will be called upon initialization of this data.
    /// </summary>
    void OnInitialize ();

    /// <summary>
    /// Will be called every update tick.
    /// </summary>
    void OnUpdate ();

}
