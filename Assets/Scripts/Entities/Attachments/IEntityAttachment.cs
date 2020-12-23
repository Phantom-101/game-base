using System.Collections.Generic;

public interface IEntityAttachment {

    /// <summary>
    /// Returns the entity to which this attachment is attached.
    /// </summary>
    /// <returns>An instance of a class implementing IEntity to which this attachment is attached.</returns>
    IEntity GetPossessingEntity ();

    /// <summary>
    /// Attaches this attachment to an entity.
    /// </summary>
    /// <param name="entity">The entity to attach to.</param>
    /// <returns>A boolean denoting whether or not the attachment has been successfully attached.</returns>
    bool AttachTo (IEntity entity);

    /// <summary>
    /// Returns a list of this entity's attachment collision modes.
    /// </summary>
    /// <returns>A list of entity attachment collision modes.</returns>
    List<EntityAttachmentCollisionMode> GetAttachmentCollisionModes ();

    /// <summary>
    /// Determines whether or not this attachment collides with <paramref name="attachment"/>.
    /// </summary>
    /// <param name="attachment">The attachment to be checked for collision against.</param>
    /// <returns>A boolean denoting whether or not this attachment collides with <paramref name="attachment"/>.</returns>
    bool Collides (IEntityAttachment attachment);

}
