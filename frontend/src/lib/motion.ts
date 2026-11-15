// Generated from .claude/DESIGN.md. Run npm run tokens:generate.
export const motionTokens = {
  "duration": {
    "instant": 0.07,
    "quick": 0.11,
    "short": 0.15,
    "standard": 0.24,
    "emphasis": 0.4,
    "atmosphere": 0.7
  },
  "easing": {
    "productiveStandard": [
      0.2,
      0,
      0.38,
      0.9
    ],
    "productiveEnter": [
      0,
      0,
      0.38,
      0.9
    ],
    "productiveExit": [
      0.2,
      0,
      1,
      0.9
    ],
    "expressiveStandard": [
      0.4,
      0.14,
      0.3,
      1
    ],
    "expressiveEnter": [
      0,
      0,
      0.3,
      1
    ],
    "expressiveExit": [
      0.4,
      0.14,
      1,
      1
    ]
  }
} as const
