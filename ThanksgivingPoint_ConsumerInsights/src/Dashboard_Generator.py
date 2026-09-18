import pandas as pd
import numpy as np
import plotly.graph_objects as go
from plotly.subplots import make_subplots


# ============================================================
# 1. LOAD DATA
# ============================================================

data = pd.read_csv("../data/guest_survey_data.csv")


# ============================================================
# 2. CALCULATE KEY METRICS
# ============================================================

total_respondents = len(data)
avg_age = data["age"].mean()
avg_family_size = data["family_size"].mean()
avg_satisfaction = data["satisfaction"].mean()
avg_learning = data["learning_score"].mean()
avg_spending = data["spending"].mean()
avg_return = data["likelihood_return"].mean()
avg_recommend = data["likelihood_recommend"].mean()


# ============================================================
# 3. VISITOR PROFILE
# ============================================================

visitor_counts = (data["visit_frequency"].value_counts())

# ============================================================
# 4. REASONS FOR VISITING
# ============================================================

reason_counts = (data["visit_motivation"].value_counts().sort_values())

# ============================================================
# 5. SATISFACTION BY VENUE
# ============================================================

venue_satisfaction = (data.groupby("venue")["satisfaction"].mean().sort_values())

# ============================================================
# 6. SATISFACTION BY VISITOR TYPE
# ============================================================

visitor_satisfaction = (data.groupby("visit_motivation")["satisfaction"].mean())

# ============================================================
# 7. LEARNING BY EDUCATION PROGRAM
# ============================================================

learning_by_program = (data.groupby("education_program")["learning_score"].mean())

# ============================================================
# 8. CORRELATIONS
# ============================================================

correlation = data.corr(numeric_only=True)
satisfaction_return_corr = correlation.loc["satisfaction","likelihood_return"]
satisfaction_recommend_corr = correlation.loc["satisfaction","likelihood_recommend"]


# ============================================================
# 9. CREATE RECOMMENDATIONS
# ============================================================

recommendations = []


# Recommendation 1
if avg_satisfaction < 4:
    recommendations.append(
        "Focus on improving the guest experience because "
        f"average satisfaction is {avg_satisfaction:.1f}/5."
    )
else:
    recommendations.append(
        "Maintain the current guest experience while identifying "
        "specific opportunities to move satisfaction even higher."
    )


# Recommendation 2
if satisfaction_return_corr >= 0.5:
    recommendations.append(
        "Prioritize factors that improve satisfaction because "
        f"satisfaction and return intent show a strong positive "
        f"relationship ({satisfaction_return_corr:.2f})."
    )


# Recommendation 3
top_reason = reason_counts.idxmax()
recommendations.append(
    f"Continue emphasizing {top_reason.lower()} experiences because "
    "it is the most common reason guests report for visiting."
)


# Recommendation 4
if "Yes" in learning_by_program.index and "No" in learning_by_program.index:
    program_learning = learning_by_program["Yes"]
    control_learning = learning_by_program["No"]
    learning_difference = (program_learning - control_learning)
    if learning_difference > 0:
        recommendations.append(
            f"Continue evaluating the education program because "
            f"guests in the program group reported learning scores "
            f"{learning_difference:.2f} points higher than the control group."
        )


# Recommendation 5
if avg_spending > 50:
    recommendations.append(
        f"Explore opportunities to increase guest engagement and "
        f"on-site spending; average reported spending is "
        f"${avg_spending:.0f}."
    )


# ============================================================
# 10. CREATE DASHBOARD
# ============================================================

fig = make_subplots(rows=5,cols=4,
    specs=[
        [{"type": "indicator"},
         {"type": "indicator"},
         {"type": "indicator"},
         {"type": "indicator"}],

        [{"type": "bar", "colspan": 2},
         None,
         {"type": "bar", "colspan": 2},
         None
         ],
        [{"type": "bar", "colspan": 2},
         None,
         {"type": "bar", "colspan": 2},
         None
         ],
        [{"type": "scatter", "colspan": 2},
         None,
         {"type": "bar", "colspan": 2},
         None],
        [{"type": "domain", "colspan": 4},
         None,
         None,
         None]
    ],

    vertical_spacing=0.08,
    horizontal_spacing=0.08,

    subplot_titles=[
        "Total Respondents",
        "Average Satisfaction",
        "Average Spending",
        "Return Intent",
        "Visitor Type",
        "Why Guests Visit",
        "Satisfaction by Venue",
        "Learning by Education Program",
        "Satisfaction vs. Return Intent",
        "Satisfaction by Visitor Type"
    ],

)


# ============================================================
# 11. KPI — TOTAL RESPONDENTS
# ============================================================

fig.add_trace(go.Indicator(mode="number",value=total_respondents,title={"text": "Guests"}),row=1,col=1)


# ============================================================
# 12. KPI — SATISFACTION
# ============================================================

fig.add_trace(go.Indicator(mode="number",value=avg_satisfaction,number={"suffix": "/5","valueformat": ".1f"},title={"text": "Satisfaction"}),row=1,col=2)


# ============================================================
# 13. KPI — SPENDING
# ============================================================

fig.add_trace(go.Indicator(mode="number",value=avg_spending,number={"prefix": "$","valueformat": ".0f"},
        title={"text": "Average Spending"}),row=1,col=3)

# ============================================================
# 14. KPI — RETURN INTENT
# ============================================================

fig.add_trace(go.Indicator(mode="number",value=avg_return,
        number={"suffix": "/5","valueformat": ".1f"},
        title={"text": "Return Intent"}),row=1,col=4)

# ============================================================
# 15. VISITOR TYPE
# ============================================================

fig.add_trace(go.Bar(x=visitor_counts.index,
                    y=visitor_counts.values,
                    name="Visitor Type"),row=2,col=1)

# ============================================================
# 16. VISIT REASONS
# ============================================================

fig.add_trace(go.Bar(
        x=reason_counts.values,
        y=reason_counts.index,
        orientation="h",
        name="Visit Reason"),row=2,col=3)


# ============================================================
# 17. SATISFACTION BY VENUE
# ============================================================

fig.add_trace(
    go.Bar(
        x=venue_satisfaction.values,
        y=venue_satisfaction.index,
        orientation="h",
        name="Satisfaction"),row=3,col=1)


# ============================================================
# 18. LEARNING BY EDUCATION PROGRAM
# ============================================================

fig.add_trace(
    go.Bar(
        x=learning_by_program.index,
        y=learning_by_program.values,
        name="Learning Score"),row=3,col=3)


# ============================================================
# 19. SATISFACTION VS RETURN INTENT
# ============================================================

fig.add_trace(
    go.Scatter(
        x=data["satisfaction"],
        y=data["likelihood_return"],
        mode="markers",
        name="Guests",
        opacity=0.6),row=4,col=1)


# ============================================================
# 20. SATISFACTION BY VISITOR TYPE
# ============================================================

fig.add_trace(
    go.Bar(
        x=visitor_satisfaction.index,
        y=visitor_satisfaction.values,
        name="Satisfaction"),row=4,col=3)

# ============================================================
# 21. AXIS LABELS
# ============================================================

fig.update_xaxes(title_text="Respondents",row=2,col=1)
fig.update_xaxes(title_text="Average Satisfaction",range=[0, 5],row=2,col=2)
fig.update_xaxes(title_text="Satisfaction",range=[1, 5],row=2,col=3)
fig.update_yaxes(title_text="Return Intent",range=[1, 5],row=2,col=4)


# ============================================================
# 22. DASHBOARD TITLE
# ============================================================

recommendation_text = "<b>KEY INSIGHTS & RECOMMENDATIONS</b><br><br>"
for recommendation in recommendations:
    recommendation_text += ("• " + recommendation + "<br><br>")
fig.add_annotation(
    text=recommendation_text,
    xref="paper",yref="paper",
    x=0.5,y=0.02,
    xanchor="center",yanchor="bottom",
    showarrow=False,
    align="left",
    font={"size": 16},
    borderwidth=1,
    borderpad=15,
    bgcolor="white",
    width=1250
)

# ============================================================
# 23. DASHBOARD TITLE
# ============================================================

fig.update_layout(
    title={ "text":
            "Thanksgiving Point<br>"
            "<sup>Guest Consumer Insights Dashboard</sup>",
            "x": 0.5,
            "xanchor": "center",
            "font":{"size":32}},

    height=1500,
    width=1400,
    showlegend=False,
    template="plotly_white")


# ============================================================
# 24. SAVE DASHBOARD
# ============================================================

fig.write_html("Thanksgiving_Point_Dashboard.html",include_plotlyjs=True)
print("Dashboard saved as Thanksgiving_Point_Dashboard.html")