using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BackGetTalentsV2.Business.Address;
using BackGetTalentsV2.Business.Category;
using BackGetTalentsV2.Business.Convers;
using BackGetTalentsV2.Business.Message;
using BackGetTalentsV2.Business.Picture;
using BackGetTalentsV2.Business.Relationship;
using BackGetTalentsV2.Business.Review;
using BackGetTalentsV2.Business.Skill;
using BackGetTalentsV2.Business.User;
using BackGetTalentsV2.Business.UserHasConversation;
using BackGetTalentsV2.Business.UserHasSkill;

#nullable disable

namespace BackGetTalentsV2.Data
{
    public partial class gettalentsContext : DbContext
    {
        public gettalentsContext()
        {
        }

        public gettalentsContext(DbContextOptions<gettalentsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Conversation> Conversations { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Relationship> Relationships { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserHasConversation> UserHasConversations { get; set; }
        public virtual DbSet<UserHasSkill> UserHasSkills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.HasIndex(e => e.UserId, "fk_address_user1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.Lat)
                    .HasPrecision(10)
                    .HasColumnName("lat");

                entity.Property(e => e.Lng)
                    .HasPrecision(10)
                    .HasColumnName("lng");

                entity.Property(e => e.Number)
                    .HasMaxLength(45)
                    .HasColumnName("number");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(45)
                    .HasColumnName("postal_code");

                entity.Property(e => e.Street)
                    .HasMaxLength(255)
                    .HasColumnName("street");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_address_user1");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.HasIndex(e => e.PictureId, "fk_category_picture1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.PictureId).HasColumnName("picture_id");

                entity.HasOne(d => d.Picture)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.PictureId)
                    .HasConstraintName("fk_category_picture1");
            });

            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.ToTable("conversation");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("message");

                entity.HasIndex(e => e.ConversationId, "fk_message_conversation1_idx");

                entity.HasIndex(e => e.UserId, "fk_message_user1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.ConversationId).HasColumnName("conversation_id");

                entity.Property(e => e.SendAt)
                    .HasColumnType("datetime")
                    .HasColumnName("send_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Conversation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ConversationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_message_conversation1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_message_user1");
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.ToTable("picture");

                entity.HasIndex(e => e.ReviewId, "fk_picture_review1_idx");

                entity.HasIndex(e => e.MessageId, "fk_picture_message1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MessageId).HasColumnName("message_id");

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .HasColumnName("path");

                entity.Property(e => e.ReviewId).HasColumnName("review_id");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Pictures)
                    .HasForeignKey(d => d.MessageId)
                    .HasConstraintName("fk_picture_message1");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.Pictures)
                    .HasForeignKey(d => d.ReviewId)
                    .HasConstraintName("fk_picture_review1");
            });

            modelBuilder.Entity<Relationship>(entity =>
            {
                entity.ToTable("relationship");

                entity.HasIndex(e => e.UserId, "fk_favoredUser_user1_idx");

                entity.HasIndex(e => e.UserLiked, "fk_favoredUser_user2_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status)
                    .HasColumnType("enum('ANONYMOUS','FAVORITE','BLACKLISTED')")
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserLiked).HasColumnName("user_liked");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RelationshipUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_favoredUser_user1");

                entity.HasOne(d => d.UserLikedNavigation)
                    .WithMany(p => p.RelationshipUserLikedNavigations)
                    .HasForeignKey(d => d.UserLiked)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_favoredUser_user2");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("review");

                entity.HasIndex(e => e.CommentatorId, "fk_review_user1_idx");

                entity.HasIndex(e => e.UserId, "fk_review_user2_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.CommentatorId).HasColumnName("commentator_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Title)
                    .HasMaxLength(45)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Commentator)
                    .WithMany(p => p.ReviewCommentators)
                    .HasForeignKey(d => d.CommentatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_review_user1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReviewUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_review_user2");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.Idskill)
                    .HasName("PRIMARY");

                entity.ToTable("skill");

                entity.HasIndex(e => e.CategoryId, "fk_skill_category1_idx");

                entity.Property(e => e.Idskill).HasColumnName("idskill");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Skills)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_skill_category1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.PictureId, "fk_user_picture1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.PictureId).HasColumnName("picture_id");

                entity.Property(e => e.Presentation).HasColumnName("presentation");

                entity.Property(e => e.Pseudo)
                    .HasMaxLength(255)
                    .HasColumnName("pseudo");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registration_date");

                entity.Property(e => e.Role)
                    .HasColumnType("enum('ADMIN','USER')")
                    .HasColumnName("role");

                entity.Property(e => e.Status)
                    .HasColumnType("enum('AVAILABLE','UNAVAILABLE','BANNED','DEACTIVATED')")
                    .HasColumnName("status");

                entity.HasOne(d => d.Picture)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PictureId)
                    .HasConstraintName("fk_user_picture1");
            });

            modelBuilder.Entity<UserHasConversation>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ConversationId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("user_has_conversation");

                entity.HasIndex(e => e.ConversationId, "fk_user_has_conversation_conversation1_idx");

                entity.HasIndex(e => e.UserId, "fk_user_has_conversation_user1_idx");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ConversationId).HasColumnName("conversation_id");

                entity.HasOne(d => d.Conversation)
                    .WithMany(p => p.UserHasConversations)
                    .HasForeignKey(d => d.ConversationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_has_conversation_conversation1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserHasConversations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_has_conversation_user1");
            });

            modelBuilder.Entity<UserHasSkill>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SkillIdskill })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("user_has_skill");

                entity.HasIndex(e => e.SkillIdskill, "fk_user_has_skill_skill1_idx");

                entity.HasIndex(e => e.UserId, "fk_user_has_skill_user1_idx");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.SkillIdskill).HasColumnName("skill_idskill");

                entity.HasOne(d => d.SkillIdskillNavigation)
                    .WithMany(p => p.UserHasSkills)
                    .HasForeignKey(d => d.SkillIdskill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_has_skill_skill1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserHasSkills)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_has_skill_user1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
