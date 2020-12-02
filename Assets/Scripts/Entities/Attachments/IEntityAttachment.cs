public interface IEntityAttachment {

    /// <summary>
    /// This function returns the entity to which this attachment is attached.
    /// </summary>
    /// <returns>An instance of a class implementing IEntity to which this attachment is attached.</returns>
    IEntity GetPossessingEntity ();

    /// <summary>
    /// This function determines whether or not this attachment collides with <paramref name="attachment"/>.
    /// </summary>
    /// <param name="attachment">The attachment to be checked for collision against.</param>
    /// <returns>A boolean denoting whether or not this attachment collides with <paramref name="attachment"/></returns>
    bool Collides (IEntityAttachment attachment);

}
