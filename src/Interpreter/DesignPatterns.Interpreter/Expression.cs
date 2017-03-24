using System;
using System.Collections.Generic;

namespace DesignPatterns.Interpreter
{
    public interface IExpression
    {
        void Interpret(Context context);
    }

    public class Context
    {
        public string Output { get; set; }
    }

    // BNF
    // <sandwich> ::= <bread> <condimentList> <ingredientList> <condimentList> <bread>
    // <condimentList> ::= { <condiment> }
    // <ingredientList> ::= { <ingredient> }
    // <bread> ::= <whiteBread> | <wheatBread>
    // <condiment> ::= <mayoCondiment> | <mustardCondiment> | <ketchupCondiment>
    // <ingredient> ::= <lettuceIngredient> | <tomatoIngredient> | <chickenIngredient>
    public class Sandwich : IExpression
    {
        private readonly IBread topBread;
        private readonly CondimentList topCondiments;
        private readonly IngredientList ingredients;
        private readonly CondimentList bottomCondiments;
        private readonly IBread bottomBread;

        public Sandwich(IBread topBread, CondimentList topCondiments, IngredientList ingredients, CondimentList bottomCondiments, IBread bottomBread)
        {
            this.topBread = topBread;
            this.topCondiments = topCondiments;
            this.ingredients = ingredients;
            this.bottomCondiments = bottomCondiments;
            this.bottomBread = bottomBread;
        }

        public void Interpret(Context context)
        {
            context.Output += "|";
            this.topBread.Interpret(context);
            context.Output += "|";
            context.Output += "<--";
            this.topCondiments.Interpret(context);
            context.Output += "-";
            this.ingredients.Interpret(context);
            context.Output += "-";
            this.bottomCondiments.Interpret(context);
            context.Output += "-->";
            context.Output += "|";
            this.bottomBread.Interpret(context);
            context.Output += "|";
            Console.WriteLine(context.Output);
        }
    }

    public class IngredientList : IExpression
    {
        private readonly List<IIngredient> ingredients;

        public IngredientList(List<IIngredient> ingredients)
        {
            this.ingredients = ingredients;
        }

        public void Interpret(Context context)
        {
            foreach (var ingredient in this.ingredients)
                ingredient.Interpret(context);
        }
    }

    public interface IIngredient : IExpression { }

    public class TomatoIngredient : IIngredient
    {
        public void Interpret(Context context) => context.Output += " Tomato ";
    }

    public class LettuceIngredient : IIngredient
    {
        public void Interpret(Context context) => context.Output += " Lettuce ";
    }

    public class ChickenIngredient : IIngredient
    {
        public void Interpret(Context context) => context.Output += " Chicken ";
    }

    public class CondimentList : IExpression
    {
        private readonly List<ICondiment> condiments;

        public CondimentList(List<ICondiment> condiments)
        {
            this.condiments = condiments;
        }

        public void Interpret(Context context)
        {
            foreach (var condiment in this.condiments)
                condiment.Interpret(context);
        }
    }

    public interface ICondiment : IExpression { }

    public class MayoCondiment : ICondiment
    {
        public void Interpret(Context context) => context.Output += " Mayo ";
    }

    public class MustardCondiment : ICondiment
    {
        public void Interpret(Context context) => context.Output += " Mustard ";
    }

    public class KetchupCondiment : ICondiment
    {
        public void Interpret(Context context) => context.Output += " Ketchup ";
    }

    public interface IBread : IExpression { }

    public class WhiteBread : IBread
    {
        public void Interpret(Context context) => context.Output += " White-Bread ";
    }

    public class WheatBread : IBread
    {
        public void Interpret(Context context) => context.Output += " Wheat-Bread ";
    }
}
