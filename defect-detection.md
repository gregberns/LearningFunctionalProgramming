# Defect Detection 

Using multiple forms of defect detection (ways to find software bugs) is not just a nice idea, it is critical to find a high percentage of issues.

Most forms of defect detection only find, on average, 30-40% of defects. But if we use multiple forms of detection, probability says we will find a much higher percent of issues.

## Example

Check this out...

If these techniques are used:
* Unit tests - 30% of defects will be found
* Regression - 25%
* Low volume beta - 35%

In total, about 65% of defects will be caught. Math: (1-((1-.3) * (1-.25) * (1-.35))) (I think this math is correct)

Lets say we add one more technique:
* Unit tests - 30%
* Regression - 25%
* Low volume beta - 35%
* Informal code reviews - 25%

Then we'll catch almost 75% of defects, one more form and you'll see a 10% bump. Math: (1-((1-.3) * (1-.25) * (1-.35) * (1-.25)))

Lets add just one more...

* Unit tests - 30%
* Regression - 25%
* Low volume beta - 35%
* Informal code reviews - 25%
* Informal design reviews - 35%

Were now up to 83% of defects caught. (1-((1-.3) * (1-.25) * (1-.35) * (1-.25) * (1-.35)))

**So we've gone from 65% to 83% of defects on average caught, by adding two more steps to our process**

Let's switch from using 'Informal design reviews' to 'Modeling or prototyping', which has a higher detection rate.

* Unit tests - 30%
* Regression - 25%
* Low volume beta - 35%
* Informal code reviews - 25%
* Modeling or prototyping - 65%

**91%** Mic drop. (1-((1-.3) * (1-.25) * (1-.35) * (1-.25) * (1-.65)))

## Numbers

These numbers come from [Code Complete](http://aroma.vn/web/wp-content/uploads/2016/11/code-complete-2nd-edition-v413hav.pdf) page 470.

**Table 20-2 Defect-Detection Rates**

| Removal Step                          | Lowest Rate | Modal Rate | Highest Rate |
| Informal design reviews               | 25%         | 35%        | 40%          |
| Formal design inspections             | 45%         | 55%        | 65%          |
| Informal code reviews                 | 20%         | 25%        | 35%          |
| Formal code inspections               | 45%         | 60%        | 70%          |
| Modeling or prototyping               | 35%         | 65%        | 80%          |
| Personal desk-checking of code        | 20%         | 40%        | 60%          |
| Unit test                             | 15%         | 30%        | 50%          |
| New function (component) test         | 20%         | 30%        | 35%          |
| Integration test                      | 25%         | 35%        | 40%          |
| Regression test                       | 15%         | 25%        | 30%          |
| System test                           | 25%         | 40%        | 55%          |
| Low-volume beta test (<10 sites)      | 25%         | 35%        | 40%          |
| High-volume beta test (>1,000 sites)  | 60%         | 75%        | 85%          |

Source: Adapted from Programming Productivity (Jones 1986a), “Software Defect-Removal Efficiency”
(Jones 1996), and “What We Have Learned About Fighting Defects” (Shull et al. 2002).


