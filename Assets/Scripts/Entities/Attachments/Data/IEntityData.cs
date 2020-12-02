public interface IEntityData : IEntityAttachment {

    /// <summary>
    /// This function will be called upon initialization of this data.
    /// </summary>
    void OnInitialize ();

    /// <summary>
    /// This function will be called every update tick.
    /// </summary>
    void OnUpdate ();

}
