using System;
using System.Collections.Generic;

#nullable disable

namespace BackGetTalentsV2.Business.User
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address.Address>();
            Messages = new HashSet<Message.Message>();
            RelationshipUserLikedNavigations = new HashSet<Relationship.Relationship>();
            RelationshipUsers = new HashSet<Relationship.Relationship>();
            ReviewCommentators = new HashSet<Review.Review>();
            ReviewUsers = new HashSet<Review.Review>();
            UserHasConversations = new HashSet<UserHasConversation.UserHasConversation>();
            UserHasSkills = new HashSet<UserHasSkill.UserHasSkill>();
        }

        public int Id { get; set; }
        public string FirebaseUid { get; set; }
        public string Pseudo { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public int? PictureId { get; set; }

        public virtual Picture.Picture Picture { get; set; }
        public virtual ICollection<Address.Address> Addresses { get; set; }
        public virtual ICollection<Message.Message> Messages { get; set; }
        public virtual ICollection<Relationship.Relationship> RelationshipUserLikedNavigations { get; set; }
        public virtual ICollection<Relationship.Relationship> RelationshipUsers { get; set; }
        public virtual ICollection<Review.Review> ReviewCommentators { get; set; }
        public virtual ICollection<Review.Review> ReviewUsers { get; set; }
        public virtual ICollection<UserHasConversation.UserHasConversation> UserHasConversations { get; set; }
        public virtual ICollection<UserHasSkill.UserHasSkill> UserHasSkills { get; set; }
    }
}