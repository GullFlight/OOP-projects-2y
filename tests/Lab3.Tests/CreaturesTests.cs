using Itmo.ObjectOrientedProgramming.Lab3.Builders;

using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

using Itmo.ObjectOrientedProgramming.Lab3.Spells;

using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class CreaturesTests
{
    [Fact]
    public void Attack_ShouldDecreaseTargetHealth()
    {
        // Arrange
        ICreature analyst = new WarAnalystBuilder()
            .WithBaseStats(new Health(4), new Attack(2)).Build(); // 2/4

        ICreature angry = new AngryFighterBuilder()
            .WithBaseStats(new Health(6), new Attack(1))
            .Build(); // 1/6

        // Act
        analyst.Attacking(angry);

        // Assert
        Assert.Equal(4, analyst.Attack.Value);
        Assert.Equal(2, angry.Health.Value);
        Assert.Equal(2, angry.Attack.Value);
    }

    [Fact]
    public void MutualAttack_ShouldMimicDied()
    {
        // Arrange
        ICreature mimic = new MimicChestBuilder()
            .WithBaseStats(new Health(1), new Attack(1))
            .Build(); // 1/1

        ICreature horror = new ImmortalHorrorBuilder()
            .WithBaseStats(new Health(4), new Attack(4))
            .Build(); // 4/4

        // Act
        mimic.Attacking(horror); // 4/4 4/1
        int temp1 = mimic.Health.Value;
        int temp2 = mimic.Attack.Value;
        horror.Attacking(mimic);

        // Assert
        Assert.Equal(1, horror.Health.Value);
        Assert.False(mimic.IsAlive);
        Assert.Equal(4, temp1);
        Assert.Equal(4, temp2);
    }

    [Fact]
    public void MagicShield_ShouldBlockDamage_WhenUsedMagicalShield()
    {
        // Arrange
        ICreature mimicWithShield = new MimicChestBuilder()
            .WithBaseStats(new Health(1), new Attack(1))
            .WithModifier(new MagicShieldApplier()).Build();

        ICreature angry = new AngryFighterBuilder()
            .WithBaseStats(new Health(6), new Attack(1))
            .Build();

        // Act
        angry.Attacking(mimicWithShield);

        // Assert
        Assert.Equal(1, mimicWithShield.Health.Value);
    }

    [Fact]
    public void DoubleAttack_ShouldAttackTwice_WhenUsedDoubleAttack()
    {
        // Arrange
        ICreature amuletMaster = new AmuletMasterBuilder()
            .CreateDefault()
            .Build(); // 5/2 + DoubleAttack + shield

        ICreature horror = new ImmortalHorrorBuilder()
            .WithBaseStats(new Health(4), new Attack(4))
            .Build(); // 4/4

        // Act
        amuletMaster.Attacking(horror);

        // Assert
        Assert.False(horror.IsAlive);
        Assert.Equal(2, amuletMaster.Health.Value);
        Assert.Equal(5, amuletMaster.Attack.Value);
    }

    [Fact]
    public void DoubleAttackAndSpell_ShouldAttackTwiceAndHealMaster_WhenUsedDoubleAttackAndStaminaPotion()
    {
        // Arrange
        ICreature angryWithDoubleAttack = new AngryFighterBuilder()
            .WithBaseStats(new Health(6), new Attack(1))
            .WithModifier(new DoubleAttackApplier()).Build(); // 1/6 + DoubleAttack

        ICreature horror = new ImmortalHorrorBuilder()
            .WithBaseStats(new Health(4), new Attack(4))
            .Build(); // 4/4

        var staminaForAngry = new StaminaPotion();

        // Act
        staminaForAngry.ApplyTo(horror); // 4/9
        angryWithDoubleAttack.Attacking(horror);

        // Assert
        Assert.Equal(7, horror.Health.Value);
        Assert.Equal(6, angryWithDoubleAttack.Health.Value);
    }
}