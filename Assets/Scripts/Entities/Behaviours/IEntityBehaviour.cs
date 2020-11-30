public interface IEntityBehaviour {

    /// <summary>
    /// This function returns the entity to which this behaviour is attached.
    /// </summary>
    /// <returns>An instance of a class implementing IEntity to which this behaviour is attached.</returns>
    IEntity GetPossessingEntity ();

    /// <summary>
    /// This function will be called upon initialization of this behaviour.
    /// </summary>
    void OnInitialize ();

    /// <summary>
    /// This function will be called every update tick.
    /// </summary>
    void OnUpdate ();

    /// <summary>
    /// This function determines whether or not this behaviour collides with <paramref name="behaviour"/>.
    /// </summary>
    /// <param name="behaviour">The behaviour to be checked for collision against.</param>
    /// <returns>A boolean denoting whether or not this behaviour collides with <paramref name="behaviour"/></returns>
    bool Collides (IEntityBehaviour behaviour);

}
