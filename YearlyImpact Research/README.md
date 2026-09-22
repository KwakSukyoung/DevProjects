# Thanksgiving Point Family & Children Impact Research

## Project Overview

This research project examines how Thanksgiving Point may impact children and families over the course of one year. The study focuses on changes in children's and families' behaviors. The project will compare families who visit Thanksgiving Point frequently with families who visit less frequently to determine whether patterns of change over time differ between the two groups. The study will also explore how visitation patterns relate to return visits, spending, membership, and participation in Thanksgiving Point programs and events.

---

## Research Question

**How do child and family outcomes change over one year among families who visit Thanksgiving Point frequently compared with families who visit infrequently?**


---

## Study Design

This project uses a **longitudinal two-group comparison design**.

The same families will be followed for approximately 12 months. Surveys will be administered at consistent intervals so changes in child and family outcomes can be measured over time.

### Group 1 — Frequent visitors: 
Families who visit approximately **at least 4 times** a year with approximately **3 months gaps**.
### Group 2 — Infrequent visitors: 
Families who visit **around twice** during the year, with a long interval between visits—for example, approximately **7 months** between visits.

---
## Data Collection

I would like to build an automated process for identifying eligible guests and collecting survey responses.
1. Connect to Thanksgiving Point’s guest database to identify guest visits and available information, using a guest or household ID to connect visits from the same family.
2. Identify families who meet the predefined criteria for Group 1 or Group 2 and automatically send them an email invitation to complete the survey after their qualifying visit.
3. At the end of the research period, review the number of qualifying visits and the guest IDs with sufficient matching information to determine whether there is an adequate sample for each group.
4. Before conducting the primary analysis, if one group is substantially larger than the other, randomly sample participants from the larger group so the groups have sufficiently comparable sample sizes for analysis.

---

# Outcomes

## Children

The study will examine four primary child outcomes:

### Learning

Measures whether children demonstrate learning that may extend beyond their Thanksgiving Point experiences.
**Learning Score: 1–5**

### Curiosity

Measures children's interest in exploring, questioning, and discovering.
**Curiosity Score: 1–5**

### Confidence

Measures children's willingness to participate, explore, communicate, and try unfamiliar activities.
**Confidence Score: 1–5**

### Social Interaction

Measures children's interaction and communication with family members and others.
**Social Interaction Score: 1–5**

# Family Outcomes

### Quality Time

Measures families' perceptions of meaningful time spent together.
**Family Quality Time Score: 1–5**

### Shared Experiences

Measures whether Thanksgiving Point experiences become meaningful shared experiences or memories for the family.
**Shared Experience Score: 1–5**

### Activities at Home

Measures whether experiences extend into family activities outside Thanksgiving Point.

# Thanksgiving Point Behavioral Measures

In addition to survey-based child and family outcomes, the project will examine behavioral measures related to families' relationship with Thanksgiving Point.

These include:
**Return Visits, Visit Frequency, Total visits during the study, Average number of visits, Number of days between visits,Spending,Membership, Programs and Events**

---

# Survey Scoring

Most child and family outcome questions will use a five-point Likert-type scale.

Example:

1 — Strongly Disagree
2 — Disagree
3 — Neither Agree nor Disagree
4 — Agree
5 — Strongly Agree

Multiple questions will be used to measure each construct.

For example:

**Learning Score = Mean of Learning Questions**

If a participant responds:

`4, 5, 3, 4, 5`

then:

`Learning Score = (4 + 5 + 3 + 4 + 5) / 5 = 4.2`

---

# Measuring Change

The primary objective is not simply to determine whether one group has higher scores.

The study will examine **how scores change over time**.

For example:

`Change Score = 12-Month Score - Baseline Score`

If:

`Baseline Confidence = 3.1`

and:

`12-Month Confidence = 4.0`

then:

`Confidence Change = +0.9`

Changes can then be compared between frequent and infrequent visitors.

Example:

| Outcome                    | Frequent Visitors | Infrequent Visitors |
| -------------------------- | ----------------: | ------------------: |
| Learning Change            |              +0.8 |                +0.2 |
| Curiosity Change           |              +0.7 |                +0.1 |
| Confidence Change          |              +0.6 |                +0.3 |
| Social Interaction Change  |              +0.5 |                +0.1 |
| Family Quality Time Change |              +0.7 |                +0.2 |

*Values above are examples only and are not research findings.*

---

# Primary Analysis

The analysis will examine three major components:

**Time**

How do scores change from baseline through 12 months?

**Group**

Are there differences between frequent and infrequent visitors?

**Group × Time**

Do the two groups show different patterns of change over time?

Because participants provide repeated measurements, longitudinal statistical methods such as linear mixed-effects models may be considered for the final analysis.

---

# Additional Analysis

The project may also examine relationships between:

* Number of visits and learning scores
* Time between visits and outcome changes
* Curiosity and return visits
* Confidence and program participation
* Social interaction and family experiences
* Family quality time and membership renewal
* Child/family outcomes and annual spending
* Program participation and return behavior

These analyses can help explore how family and child outcomes relate to families' continued relationship with Thanksgiving Point.

---

# Example Dataset Structure

Each survey response may contain variables such as:

| Variable                | Description                      |
| ----------------------- | -------------------------------- |
| Family_ID               | Anonymous participant identifier |
| Time_Point              | Baseline, 3M, 6M, 9M, 12M        |
| Group                   | Frequent / Infrequent            |
| Visit_Count             | Number of visits                 |
| Days_Between_Visits     | Visit interval                   |
| Learning_Score          | 1–5                              |
| Curiosity_Score         | 1–5                              |
| Confidence_Score        | 1–5                              |
| Social_Score            | 1–5                              |
| Quality_Time_Score      | 1–5                              |
| Shared_Experience_Score | 1–5                              |
| At_Home_Activity        | Frequency/count                  |
| Membership              | Membership status                |
| Program_Count           | Programs/events attended         |
| Spending                | Household spending               |

---

# Data Analysis Tools

Potential tools for this project include:

* Python
* pandas
* NumPy
* SciPy
* statsmodels
* Matplotlib
* Jupyter Notebook

Additional statistical tools may be added as the research design develops.

---

# Planned Project Structure

```text
thanksgiving-point-family-impact/
│
├── README.md
│
├── data/
│   ├── raw/
│   └── processed/
│
├── surveys/
│   ├── baseline-survey.md
│   ├── 3-month-survey.md
│   ├── 6-month-survey.md
│   ├── 9-month-survey.md
│   └── 12-month-survey.md
│
├── notebooks/
│   ├── 01-data-cleaning.ipynb
│   ├── 02-exploratory-analysis.ipynb
│   ├── 03-longitudinal-analysis.ipynb
│   └── 04-visualizations.ipynb
│
├── src/
│   ├── scoring.py
│   └── analysis.py
│
└── results/
    ├── figures/
    └── reports/
```

---

## Additional Research:
1) Do research seniors, no children couples
2) Apply observation research in the field with their behavior
3) Analyze qaulitative comments
4) How does thanksgiving point affect people on holidays

## Current Project Status

Status: In Progress

This project is an ongoing personal research study using synthetic data to explore how visit frequency may be associated with children's learning and behavioral outcomes at Thanksgiving Point.

### Completed Work

* Designed a relational SQL database containing household, child, visit, and survey data.

* Generated synthetic data to simulate visitor experiences over a 12-month period.

* Performed exploratory data analysis (EDA), including data cleaning, distribution analysis, and visitor group comparisons.

* Conducted preliminary statistical analyses to compare changes in learning, curiosity, confidence, and social interaction between frequent and infrequent visitors.

