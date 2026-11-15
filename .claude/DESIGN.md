---
version: "1.2"
name: RigWorks
status: "Project-specific design system, synthesized from public design analyses"
description: >-
  A dark, precise PC-configurator interface. Linear supplies the visual foundation:
  near-black canvas, charcoal surface hierarchy, restrained lavender accent,
  tight typography and hairline dividers. Raycast contributes compact, fast
  application controls and command-palette interaction patterns. Framer
  contributes selective atmospheric showcase treatment. RigWorks motion uses
  the productive/expressive distinction and timing/easing tokens from IBM Carbon.
sources:
  linear: "https://getdesign.md/linear.app/design-md"
  raycast: "https://getdesign.md/raycast/design-md"
  framer: "https://getdesign.md/framer/design-md"
  carbon-motion: "https://www.carbondesignsystem.com/building-blocks/foundations/motion/overview"
  reduced-motion: "https://developer.mozilla.org/en-US/docs/Web/CSS/@media/prefers-reduced-motion"
  animation-performance: "https://web.dev/articles/animations-guide"
colors:
  primary: "#5e6ad2"              # fill and border only; never text (3.89-4.44:1 on dark surfaces)
  primary-pressed: "#4c57b8"      # white text 6.24:1; visibly darker than primary
  primary-highlight: "#828fff"    # link text, focus ring, selection indicators; never a white-text fill
  on-primary: "#ffffff"
  link: "#828fff"                 # 7.27:1 canvas, 6.64:1 surface-1, 6.37:1 surface-2
  focus-ring: "#828fff"
  ink: "#f7f8f8"
  ink-muted: "#d0d6e0"
  ink-subtle: "#8a8f98"
  ink-tertiary: "#62666d"         # decorative/disabled only
  canvas: "#010102"
  surface-1: "#0f1011"
  surface-2: "#141516"
  surface-3: "#18191a"
  hairline: "#23252a"             # dividers, card edges (decorative)
  hairline-strong: "#34343a"      # hover/elevated edges
  control-border: "#62666d"       # edges that identify form controls: 3.30:1 on surface-1
  inverse-surface: "#ffffff"
  inverse-surface-hover: "#e8e8e8"    # Raycast's white-pressed value
  inverse-surface-pressed: "#d6d6d6"  # inverse-ink on it: 12:1
  inverse-ink: "#18191a"
  semantic-success: "#27a644"
  semantic-warning: "#ffc533"
  semantic-danger: "#ff6161"
  semantic-info: "#57c1ff"
  semantic-success-tint: "rgba(39, 166, 68, 0.14)"
  semantic-warning-tint: "rgba(255, 197, 51, 0.14)"
  semantic-danger-tint: "rgba(255, 97, 97, 0.14)"
  semantic-info-tint: "rgba(87, 193, 255, 0.14)"
  spotlight-violet: "#6a4cf5"
  spotlight-magenta: "#d44df0"
  overlay: "rgba(0, 0, 0, 0.64)"
fonts:
  ui: "Inter, ui-sans-serif, system-ui, -apple-system, BlinkMacSystemFont, 'Segoe UI', sans-serif"
  mono: "'JetBrains Mono', ui-monospace, Consolas, monospace"
typography:
  display-xl:
    fontFamily: Inter
    fontSize: 64px
    fontWeight: 600
    lineHeight: 1.08
    letterSpacing: -0.0375em
  display-lg:
    fontFamily: Inter
    fontSize: 48px
    fontWeight: 600
    lineHeight: 1.10
    letterSpacing: -0.031em
  display-md:
    fontFamily: Inter
    fontSize: 36px
    fontWeight: 600
    lineHeight: 1.15
    letterSpacing: -0.025em
  headline:
    fontFamily: Inter
    fontSize: 28px
    fontWeight: 600
    lineHeight: 1.20
    letterSpacing: -0.021em
  card-title:
    fontFamily: Inter
    fontSize: 18px
    fontWeight: 600
    lineHeight: 1.35
    letterSpacing: -0.017em
  body-lg:
    fontFamily: Inter
    fontSize: 16px
    fontWeight: 400
    lineHeight: 1.55
    letterSpacing: 0
  body:
    fontFamily: Inter
    fontSize: 14px
    fontWeight: 400
    lineHeight: 1.5
    letterSpacing: 0
  body-sm:
    fontFamily: Inter
    fontSize: 13px
    fontWeight: 400
    lineHeight: 1.45
    letterSpacing: 0
  caption:
    fontFamily: Inter
    fontSize: 12px
    fontWeight: 400
    lineHeight: 1.4
    letterSpacing: 0
  button:
    fontFamily: Inter
    fontSize: 14px
    fontWeight: 500
    lineHeight: 1.2
    letterSpacing: 0
  eyebrow:
    fontFamily: Inter
    fontSize: 12px
    fontWeight: 500
    lineHeight: 1.3
    letterSpacing: 0.033em
  mono:
    fontFamily: JetBrains Mono
    fontSize: 12px
    fontWeight: 400
    lineHeight: 1.5
    letterSpacing: 0
rounded:
  xs: 4px
  sm: 6px
  md: 8px
  lg: 12px
  xl: 16px
  pill: 9999px
spacing:
  xxs: 4px
  xs: 8px
  sm: 12px
  md: 16px
  lg: 24px
  xl: 32px
  xxl: 48px
  section: 96px
elevation:
  shadow-popover: "0 8px 24px rgba(0, 0, 0, 0.40)"
  shadow-modal: "0 16px 48px rgba(0, 0, 0, 0.56)"
motion:
  duration-instant: 70ms
  duration-quick: 110ms
  duration-short: 150ms
  duration-standard: 240ms
  duration-emphasis: 400ms
  duration-atmosphere: 700ms
  easing-productive-standard: "cubic-bezier(0.2, 0, 0.38, 0.9)"
  easing-productive-enter: "cubic-bezier(0, 0, 0.38, 0.9)"
  easing-productive-exit: "cubic-bezier(0.2, 0, 1, 0.9)"
  easing-expressive-standard: "cubic-bezier(0.4, 0.14, 0.3, 1)"
  easing-expressive-enter: "cubic-bezier(0, 0, 0.3, 1)"
  easing-expressive-exit: "cubic-bezier(0.4, 0.14, 1, 1)"
components:
  button-primary:
    backgroundColor: "{colors.primary}"
    textColor: "{colors.on-primary}"
    typography: "{typography.button}"
    rounded: "{rounded.md}"
    padding: "10px 14px"
    minHeight: 40px
  button-primary-pressed:
    backgroundColor: "{colors.primary-pressed}"
    textColor: "{colors.on-primary}"
    typography: "{typography.button}"
    rounded: "{rounded.md}"
  button-secondary:
    backgroundColor: "{colors.surface-2}"
    textColor: "{colors.ink}"
    borderColor: "{colors.hairline-strong}"
    typography: "{typography.button}"
    rounded: "{rounded.md}"
    padding: "10px 14px"
    minHeight: 40px
  button-quiet:
    backgroundColor: transparent
    textColor: "{colors.ink-muted}"
    typography: "{typography.button}"
    rounded: "{rounded.md}"
    padding: "8px 12px"
  button-inverse-showcase:
    backgroundColor: "{colors.inverse-surface}"
    textColor: "{colors.inverse-ink}"
    typography: "{typography.button}"
    rounded: "{rounded.pill}"
    padding: "10px 18px"
  text-input:
    backgroundColor: "{colors.surface-2}"
    textColor: "{colors.ink}"
    borderColor: "{colors.control-border}"
    typography: "{typography.body}"
    rounded: "{rounded.md}"
    padding: "10px 12px"
    minHeight: 44px
  filter-chip:
    backgroundColor: "{colors.surface-1}"
    textColor: "{colors.ink-muted}"
    borderColor: "{colors.hairline}"
    typography: "{typography.body-sm}"
    rounded: "{rounded.pill}"
    padding: "6px 12px"
  filter-chip-active:
    backgroundColor: "{colors.surface-3}"
    textColor: "{colors.ink}"
    borderColor: "{colors.ink-subtle}"
    typography: "{typography.body-sm}"
    rounded: "{rounded.pill}"
    padding: "6px 12px 6px 8px"
    leadingIcon: "check, 16px"
  part-card:
    backgroundColor: "{colors.surface-1}"
    textColor: "{colors.ink}"
    borderColor: "{colors.hairline}"
    typography: "{typography.body}"
    rounded: "{rounded.lg}"
    padding: 16px
  part-card-hover:
    backgroundColor: "{colors.surface-1}"
    borderColor: "{colors.hairline-strong}"
  part-card-selected:
    backgroundColor: "{colors.surface-2}"
    textColor: "{colors.ink}"
    borderColor: "{colors.primary}"
    typography: "{typography.body}"
    rounded: "{rounded.lg}"
    padding: 16px
    selectionMark: "check icon + visible 'Selected' label"
  build-summary:
    backgroundColor: "{colors.surface-1}"
    textColor: "{colors.ink}"
    borderColor: "{colors.hairline}"
    rounded: "{rounded.lg}"
    padding: 24px
  command-palette:
    backgroundColor: "{colors.surface-1}"
    textColor: "{colors.ink}"
    borderColor: "{colors.hairline-strong}"
    rounded: "{rounded.lg}"
    padding: 8px
  command-row-active:
    backgroundColor: "{colors.surface-3}"
    textColor: "{colors.ink}"
    indicator: "2px leading bar, {colors.primary-highlight}"
    rounded: "{rounded.sm}"
    padding: "8px 12px"
  keycap:
    backgroundColor: "{colors.surface-2}"
    textColor: "{colors.ink-subtle}"
    borderColor: "{colors.hairline}"
    typography: "{typography.caption}"
    rounded: "{rounded.xs}"
    padding: "2px 6px"
  status-badge:
    backgroundColor: "{colors.surface-2}"
    textColor: "{colors.ink-muted}"
    typography: "{typography.caption}"
    rounded: "{rounded.pill}"
    padding: "3px 8px"
  showcase-card:
    backgroundColor: "{colors.surface-1}"
    textColor: "{colors.ink}"
    borderColor: "{colors.hairline}"
    rounded: "{rounded.xl}"
    padding: 32px
  top-nav:
    backgroundColor: "{colors.canvas}"
    textColor: "{colors.ink}"
    borderColor: "{colors.hairline}"
    typography: "{typography.body-sm}"
    height: 56px
  power-estimate:
    backgroundColor: "{colors.surface-1}"
    textColor: "{colors.ink}"
    borderColor: "{colors.hairline}"
    typography: "{typography.body}"
    rounded: "{rounded.lg}"
    padding: 16px
    track: "{colors.surface-3}, 6px tall, {rounded.pill}"
    fill: "state colour; width set with transform: scaleX()"
    label: "'Estimated' always visible; tabular-nums"
  price-total:
    textColor: "{colors.ink}"
    typography: "{typography.headline}"
    numeric: "tabular-nums; locale-formatted"
    partialLabel: "{colors.ink-subtle}, {typography.caption}"
  spec-row:
    borderColor: "{colors.hairline}"
    labelColor: "{colors.ink-subtle}"
    valueColor: "{colors.ink}"
    typography: "{typography.body-sm}"
    padding: "8px 0"
    numeric: tabular-nums
  compatibility-status:
    typography: "{typography.body-sm}"
    rounded: "{rounded.pill}"
    padding: "3px 8px"
    compatible: "{colors.semantic-success} text + icon on {colors.semantic-success-tint}"
    conditional: "{colors.semantic-warning} text + icon on {colors.semantic-warning-tint}"
    incompatible: "{colors.semantic-danger} text + icon on {colors.semantic-danger-tint}"
    not-evaluated: "{colors.ink-subtle} text + neutral icon on {colors.surface-2}"
  comparison-table:
    headerBackground: "{colors.surface-2}"
    columnAltBackground: "{colors.surface-1}"
    borderColor: "{colors.hairline}"
    typography: "{typography.body-sm}"
    stickyHeader: true
  select:
    backgroundColor: "{colors.surface-2}"
    textColor: "{colors.ink}"
    borderColor: "{colors.control-border}"
    typography: "{typography.body}"
    rounded: "{rounded.md}"
    padding: "10px 12px"
    minHeight: 44px
  checkbox:
    size: 16px
    borderColor: "{colors.control-border}"
    checkedBackground: "{colors.primary}"
    checkColor: "{colors.on-primary}"
    rounded: "{rounded.xs}"
  toggle:
    track: "{colors.surface-3}"
    trackOn: "{colors.primary}"
    thumb: "{colors.ink}"
    borderColor: "{colors.control-border}"
    rounded: "{rounded.pill}"
  range-slider:
    track: "{colors.surface-3}"
    range: "{colors.primary}"
    thumb: "{colors.ink}, 16px, border {colors.control-border}"
    valueLabels: "{typography.body-sm}, tabular-nums"
  tabs:
    textColor: "{colors.ink-subtle}"
    activeTextColor: "{colors.ink}"
    indicator: "2px bottom bar, {colors.primary-highlight}"
    typography: "{typography.body-sm}"
  tooltip:
    backgroundColor: "{colors.surface-3}"
    textColor: "{colors.ink}"
    borderColor: "{colors.hairline-strong}"
    typography: "{typography.caption}"
    rounded: "{rounded.sm}"
    padding: "6px 8px"
  toast:
    backgroundColor: "{colors.surface-3}"
    textColor: "{colors.ink}"
    borderColor: "{colors.hairline-strong}"
    shadow: "{elevation.shadow-popover}"
    typography: "{typography.body-sm}"
    rounded: "{rounded.md}"
    padding: "12px 16px"
  drawer:
    backgroundColor: "{colors.surface-1}"
    borderColor: "{colors.hairline-strong}"
    shadow: "{elevation.shadow-modal}"
    padding: 24px
  modal:
    backgroundColor: "{colors.surface-1}"
    borderColor: "{colors.hairline-strong}"
    shadow: "{elevation.shadow-modal}"
    rounded: "{rounded.lg}"
    padding: 24px
  empty-state:
    textColor: "{colors.ink-muted}"
    titleTypography: "{typography.card-title}"
    typography: "{typography.body}"
  loading-state:
    skeleton: "{colors.surface-2}"
    skeletonHighlight: "{colors.surface-3}"
---

## Overview

RigWorks is a PC-configuration web application, not a storefront and not a generic SaaS dashboard. The interface should make intricate hardware decisions feel controlled, rewarding, and understandable. It should look remarkably refined *before* an animation runs and even better when users interact with it.

**Design lineage and authority:**

1. **Linear — primary foundation (dominant).** Use its dark canvas, subtle layered surfaces, lavender-blue action accent, fine borders, 4px spacing rhythm, disciplined typography, and product-first composition. The colour, spacing and radius tokens come directly from its getdesign.md analysis. The type scale keeps Linear's structure and weights, but is reduced by about one step for a dense application; only `headline` is unchanged.
2. **Raycast — application interaction reference.** Borrow its compact menu/search treatment, command-palette rows, understated selection, keyboard hints, and high-density information presentation. Raycast's category accents also supply the warning, danger and info hues, repurposed here as semantic status colours. Do **not** import Raycast's red brand stripes or replace RigWorks' primary lavender with Raycast's white CTA system.
3. **Framer — restricted showcase reference.** Borrow the idea of oversized atmospheric gradient tiles and bold, product-led showcases. Do **not** import Framer's blue link/selection accent, loud multi-color card grids, or its proprietary font.
4. **IBM Carbon — motion-system reference only.** Use its published duration and easing values and its distinction between *productive* and *expressive* motion. Specific RigWorks animation choreography below is intentionally project-specific.

These references are **independent analyses**, not the companies' official design files. This document establishes RigWorks' design decisions; it does not claim that its complete combination appears on any source website.

### Product character

- **Feel:** precise, modern, fast, premium, technical but approachable. Hardware is the visual subject; interface chrome supports it.
- **Theme:** dark exclusively. No auto-generated light variant, white page backgrounds, glassmorphism everywhere, or default Tailwind-looking cards.
- **Visual priority:** first usability and trust, then delight. Complex compatibility and price information must remain legible at a glance.
- **Brand identity:** use the name **RigWorks** consistently. Do not invent a final logo, slogan, mascot, or additional brand accent without an explicit design decision.
- **Interface versus landing page:** the public introduction may be cinematic; the working builder must be calm, direct, and information-dense.

## Colors

### Brand & actions

- `{colors.primary}` is the **single brand/action accent**, taken from Linear. Use it as a **fill or border**: primary buttons, selected-component borders, checked controls, slider ranges. It is not a text colour: at 3.89–4.44:1 it fails AA for normal text on RigWorks surfaces.
- `{colors.primary-highlight}` (#828fff) is the accent's **text and indicator** form: links (`{colors.link}`), focus rings (`{colors.focus-ring}`), active-row bars and tab indicators. Never use it as a fill behind white text (2.87:1). `{colors.primary-pressed}` is the pressed fill.
- Inverse white buttons (`button-inverse-showcase`) are allowed as rare Raycast/Framer-inspired marketing CTAs. Never mix white and lavender as two competing primary actions in the same view.

### Surfaces and text

- Canvas `{colors.canvas}` anchors all pages; the application shell does not alternate between large light and dark sections.
- Surface hierarchy moves from `{colors.surface-1}` (panels/cards), to `{colors.surface-2}` (inputs, selected panels), to `{colors.surface-3}` (small nested controls, tooltips, active rows). Distinguish levels chiefly with **surface lift and 1px borders**, not heavy shadows.
- Use `{colors.hairline}` for default 1px dividers and `{colors.hairline-strong}` for elevated/active boundaries. Avoid outlining every nested object twice.
- `{colors.control-border}` outlines form controls (inputs, selects, checkboxes, toggles), where the edge identifies the control. `{colors.hairline}` stays for decorative dividers and card edges.
- `{colors.ink}` for headings and primary text; `{colors.ink-muted}` for supporting content; `{colors.ink-subtle}` for labels, metadata, and less important text. `{colors.ink-tertiary}` is **decorative/disabled only**, not essential small text.
- Text on colored or illustrated panels must remain genuinely readable. Never assume a gradient provides adequate contrast.

### Semantic status

- Semantic colours are **foreground colours**: text, icons, 1px borders and indicator bars on dark surfaces. Status badges use the matching `*-tint` background with semantic-coloured text (4.60:1 or better on surface-1 to surface-3). **Never put white text on a semantic fill** (2.0–3.2:1). If a solid fill is truly needed, use `{colors.inverse-ink}` text (5.55:1 or better).
- `{colors.semantic-success}` = confirmed compatible or successful action.
- `{colors.semantic-warning}` = conditional fit, caution, or missing information that matters.
- `{colors.semantic-danger}` = confirmed incompatibility, blocked operation, or destructive action.
- `{colors.semantic-info}` = informational status only; it does not compete with the lavender primary action.
- Neutral/unchecked states use `{colors.ink-subtle}`, **not green**. Pair every status color with a label and/or icon. Never use color alone to communicate compatibility.

### Atmospheric color

- `{colors.spotlight-violet}` and `{colors.spotlight-magenta}` are borrowed from Framer's gradient vocabulary **only for isolated showcase art**: e.g., a home-page hardware composition or one hero illustration.
- Use radial spotlights over near-black, capped at **24% alpha for violet and 12% for magenta** wherever text sits on top. At that cap even `ink-subtle` keeps 5.38:1 or better. Reference: `radial-gradient(60% 60% at 70% 30%, rgb(106 76 245 / 0.24), transparent 70%), radial-gradient(40% 40% at 85% 20%, rgb(212 77 240 / 0.12), transparent 70%)`. The colourful area stays spatially confined and fades into the surrounding surface.
- Animate the atmosphere only by fading the **opacity** of a static gradient layer (`{motion.duration-atmosphere}`, `{motion.easing-expressive-enter}`, once). Never animate gradient stops, `background-position`, `filter: blur()` or `backdrop-filter`; these repaint every frame.
- No constant animated glow behind catalogs, filters, part specs, compatibility errors, or checkout-like actions. Do not introduce arbitrary cyan/pink/orange brand accents.

## Typography

### Font family

**Inter** is the practical cross-platform choice: Raycast's analysis uses it, and it is a widely used free alternative to Linear's proprietary families. No text is set below 12px. Load Inter Variable if available, with the system fallback defined in `{fonts.ui}`. The proprietary Linear Display and GT Walsheim fonts are *not* required or assumed available.

Use `{fonts.mono}` sparingly for part numbers, code-like identifiers, keyboard hints, and technical snippets. Ordinary spec values and prices stay in Inter with `font-variant-numeric: tabular-nums` when aligned in tables.

### Hierarchy

| Role | Token | Usage |
|---|---|---|
| Marketing hero | `{typography.display-xl}` | Short, confident front-page headline only |
| Section display | `{typography.display-lg}` / `{typography.display-md}` | Major landing or featured sections |
| App title | `{typography.headline}` | Page title, build title |
| Component title | `{typography.card-title}` | Hardware name, panel/card header |
| Supporting introduction | `{typography.body-lg}` | Brief descriptions, onboarding copy |
| Working UI | `{typography.body}` / `{typography.body-sm}` | Filters, technical metadata, rows, forms |
| Metadata | `{typography.caption}` / `{typography.eyebrow}` | Labels, timestamps, compact supplementary information |

- Use weight 600 for prominent headings and 400 for normal text; avoid defaulting everything to bold.
- Tight, negative letter-spacing belongs on **large headings**, not tiny specifications.
- Avoid excessive all-caps, artificial hacker/terminal styling, and decorative monospaced paragraphs.
- Long single words, model numbers and user-named builds can overflow narrow screens at display sizes. Headings use `overflow-wrap: break-word`. Check every display heading at 360px width.
- Never compromise legibility to fit a long GPU or motherboard model name. Allow sensible wrapping or intentional truncation with full text on demand.

## Layout

### Spacing system

- Linear's **4px base** and the named `spacing` tokens are the foundation; no unrelated 5/7/13/19px margins scattered through the app.
- Component insets may use 2px sub-steps (2, 6, 10, 14px) to reach optical heights. Layout gaps, margins and panel padding use only `spacing` tokens.
- Main marketing sections use approximately `{spacing.section}` vertical rhythm; application workflows use much denser 12–32px spacing.
- Default app panels: 16–24px internal padding. Larger marketing showcase panels: 24–32px. Card grids: 16–24px gutters.
- Controls are compact but not cramped: preserve 40px minimum primary-button height and 44px form/touch targets where appropriate.

### Grid & composition

- Marketing content max width approximately **1280px**, inherited from Linear; keep consistent side gutters.
- The configurator is **desktop-first in information architecture, responsive in implementation**. Its central component list remains the protagonist, not decorative illustration.
- When space permits, organize the workspace into filters/navigation, a flexible part catalog, and an accessible build-summary panel. Do not force three columns on widths where the actual part information becomes cramped.
- The build summary may be sticky on desktop when it does not obscure content. On smaller screens, transform secondary rails into drawers, tabs, or clear stacked sections with a persistently discoverable build-summary action.
- Rows and spec comparisons should align labels/values cleanly. Keep price and compatibility cues in predictable positions rather than shifting them card to card.
- Use whitespace to separate major decisions; use fine dividers for dense data, rather than placing every single specification in a large independent card.

## Elevation & Depth

- Depth is primarily **tonal**: `{colors.canvas}` → `{colors.surface-1}` → `{colors.surface-2}` → `{colors.surface-3}`.
- Cards and controls use 1px hairlines. Avoid heavy black drop shadows as the main depth signal.
- Floating layers (menus, popovers, command palettes, toasts) use `{elevation.shadow-popover}`. Modals and drawers use `{elevation.shadow-modal}` over `{colors.overlay}`. On a near-black canvas the shadow is secondary; the `{colors.hairline-strong}` edge does the separating. Never create conspicuous neon shadows.
- Atmospheric gradients are an illustration technique, **not** elevation. Do not put glass blur on every surface.

## Shapes & Imagery

- Default controls and compact rows: `{rounded.sm}`–`{rounded.md}` (6–8px). Feature cards/panels: `{rounded.lg}` (12px). Showcase art: `{rounded.xl}` (16px). Pills are reserved for chips, badges and the occasional isolated marketing CTA.
- Use **real, accurate component product images** when available, on neutral backgrounds with consistent containment. Never crop a GPU, CPU cooler, or motherboard so aggressively that it is difficult to identify.
- Distinguish real photographs from stylized renders. Do not fabricate product models, branding, ports, RGB layouts, or compatibility proof as decorative content.
- An unavailable image gets an intentional neutral placeholder or simple category glyph, not a misleading random PC part.
- Feature sections can frame screenshots or faithful build previews as heroes, in the Linear/Raycast tradition. Do not automatically invent a full 3D viewer or require WebGL just for appearance.

## Components

### Buttons & actionable elements

**`button-primary`** — Lavender fill, white text, 8px radius; reserved for the next major action (e.g., add part, save build). One obvious primary action per decision area. Pressed uses `button-primary-pressed`. Hover keeps the fill and adds a 1px inset `{colors.primary-highlight}` edge instead of switching to an inaccessible light fill; keyboard focus uses the shared focus ring, so hover and focus never look alike.

**`button-secondary`** — Raised charcoal background with a hairline border; for alternatives, comparison, and supporting actions.

**`button-quiet`** — Text-first action for removing filters, view details, and understated in-row controls. Destructive actions must be clearly labeled and verified before irreversible effects.

**`button-inverse-showcase`** — White pill with dark text for an isolated, high-contrast marketing area only. Do not use as the default application action.

**Interaction-state model.** Every interactive component inherits these rules unless its YAML entry overrides them. Buttons do not animate position on every hover in dense rows.

| State | Visual rule | Motion |
|---|---|---|
| Hover (fine pointer only) | Neutral controls: border one step stronger (`hairline` → `hairline-strong` → `control-border`) plus, where there is a fill, one surface step up. A surface step alone is too faint (about 1.04:1) to count as a hover state. Primary button: fill unchanged, plus a 1px inset `primary-highlight` edge. Quiet button: text `ink-muted` → `ink`, background `surface-2`. Inverse showcase button: `inverse-surface-hover`. | `duration-quick`, productive-standard |
| Pressed | Primary: `primary-pressed`. Inverse showcase: `inverse-surface-pressed`. Neutral: back to the default surface. Standalone buttons may use `scale(0.98)`; in-row controls may not. | `duration-instant` |
| Focus-visible | `outline: 2px solid {colors.focus-ring}; outline-offset: 2px` on every control. Text inputs also switch the border to `primary`. Never removed, and shown together with hover when both apply. | Appears instantly |
| Selected / active | Always a visible text or icon change, plus an indicator of 3:1 or better: `primary` border (cards), `ink-subtle` border and check icon (chips), 2px `primary-highlight` bar (rows, tabs). | `duration-short` |
| Disabled | Text and icons `ink-tertiary`, background `surface-1`, border `hairline`, no hover, `cursor: not-allowed`. Quiet buttons stay transparent and borderless, changing only their text. Never shown by opacity alone. If a reason exists ("Select a CPU first"), show it next to the control or in a tooltip. | None |
| Pending | Label stays; a 16px spinner replaces the leading icon; width is locked so nothing shifts; repeat activation is blocked. | Spinner only |
| Error | Border `semantic-danger`, plus an icon and a message in words below the field. | Appears instantly; no shake |

### Part catalogue & selection

**`part-card`** — Linear-style dark surfaced card with a clear image region, component title, manufacturer/model information, relevant specs, price/availability when known, and one obvious action. The amount of data can be denser in list mode.

**`part-card-hover`** — Border strengthens to `hairline-strong`; the surface does not change, so hover never resembles selection.

**`part-card-selected`** — The same geometry, one surface notch higher, a `primary` border (3.89:1), and a check icon with a visible "Selected" label. Do not enlarge selected cards enough to reflow a whole catalog.

**`spec-row`** — Thin divider, muted label on one side, readable aligned value on the other. Use tabular numbers for aligned numeric values. Long values wrap or reveal details instead of vanishing behind clipping.

**`filter-chip`** / **`filter-chip-active`** — Raycast-inspired compact neutral chips. The active state adds a leading check icon, `ink` text and an `ink-subtle` border (5.4:1 or better), so it reads at a glance while staying neutral; filters should not turn into a wall of glowing purple pills.

**`text-input`** — Surface-2 dark field, 1px `control-border` edge, readable placeholder, 44px target. Focus adds lavender border/focus ring. Error/valid states supplement rather than replace clear messages.

**`select`** / **`checkbox`** / **`toggle`** / **`range-slider`** / **`tabs`** — Compact form controls for filters (socket, chipset, price and wattage ranges, grid/list view). They share `control-border` edges, a `primary` fill when checked or on, and the shared state model. Range values are shown as text with tabular numbers, never only by thumb position. In narrow rails, keep option labels short and put the category in the field label ("Power supply" → "750 W"), so selected values never truncate.

### Builder status & summary

**`build-summary`** — A bordered charcoal panel showing selected categories, major identifiers, known total, and compatibility overview. A missing selection is explicit and neutral. A total that cannot be computed is labeled unknown or partial, never a fake €0.

**`compatibility-status`** — Four distinct semantic states: *compatible*, *incompatible*, *conditional*, *not evaluated*. The text identifies the basis of the result or explains what is missing. An incompatibility should lead to a comprehensible detail/next action, not just a red dot. Each state uses its semantic colour as text and icon on the matching tint.

**`power-estimate`** — Shows estimated system draw against the selected PSU's rating, as a bar plus words, e.g. "≈ 520 W estimated · 750 W PSU · 31% headroom". The headroom *thresholds* come from the product specification. This component only maps their result to the four `compatibility-status` states. No PSU selected, or missing wattage data, shows *not evaluated*, never an empty green bar.

**`price-total`** — Format through the app's shared number formatter, never by hand. If some parts lack prices, show "Partial total · 6 of 8 parts priced". Going over a user budget is a **warning**, with the amount over stated ("€85 over budget"). It is never *danger*, which is reserved for incompatibility.

**`comparison-table`** — Clear column headers and consistent spec rows; mild tonal column separation, narrow dividers, sticky identifying headers when genuinely helpful. Keep values readable and comparable instead of turning data into colorful feature cards.

**`status-badge`** — Neutral pill for state and metadata, compact and quiet. Semantic color is opt-in only when the meaning warrants it.

### Navigation & search

**`top-nav`** — Approximately 56px tall, dark continuous surface, restrained bottom rule, RigWorks wordmark, relevant top-level destinations and a clear current-page state. No excessive marketing links in the builder.

**`command-palette`** — Borrow Raycast's compact search-and-command model: dark floating panel, search input, grouped actionable rows, selected row one level lighter, optional keyboard shortcuts displayed as `keycap`. Use only if actual navigation/actions support it; not as a nonfunctional demo.

**`menu` / `popover` / `modal`** — Surface lift, clear edge, restrained entrance/exit motion. Manage focus, restore it on close, and provide keyboard dismissal where appropriate. For destructive decisions, use direct explanatory language rather than dramatic animation.

**`tooltip`** / **`drawer`** / **`toast`** — Tooltips are short supplementary text, never the only place essential information lives. Drawers hold secondary rails on narrow screens and slide from their edge. Save and share confirmations use a toast, announced to screen readers, which stays at least 5 seconds and pauses on hover or focus.

### Marketing/showcase

**`showcase-card`** — Framer-inspired atmospheric tile used sparingly among otherwise monochrome cards. One focal product composition or authentic UI preview, subtle lavender/violet spotlight, a strong short heading and minimal text. It is *not* a template for catalog cards.

**`empty-state`** — Useful explanation plus a real next action. A small category illustration is acceptable; full cinematic effects are not necessary for routine empty results.

**`loading-state`** — Match the final layout with neutral skeletons or a small indicator; avoid an endless animated skeleton wall. Skeletons are static `surface-2` blocks, or pulse their opacity between surface-2 and surface-3 at most. No moving shimmer, and static under reduced motion. Keep layout stable and announce relevant results when ready.

## Motion & Animation

### Motion philosophy

**Two modes, following IBM Carbon:**

- **Productive motion** supports work: selection, menus, filter changes, panels, sorting, feedback. It is short, quiet and repeatable.
- **Expressive motion** marks *rare* moments: first landing-page reveal, opening a finished-build view, a deliberately designed visual showcase. It may be noticeable, but never delays a task.

Productive motion should dominate normal usage; expressive motion should remain unusual. A user repeatedly selecting components should not have to sit through a show.

### Duration & easing tokens

Use the exact values in `motion:` rather than arbitrary per-component transitions. They come from the published IBM Carbon motion scale.

| Token | Time | Primary use |
|---|---:|---|
| `{motion.duration-instant}` | 70ms | Immediate press feedback |
| `{motion.duration-quick}` | 110ms | Hover, focus, simple opacity |
| `{motion.duration-short}` | 150ms | Small content/selection shift |
| `{motion.duration-standard}` | 240ms | Popovers, drawers, status messages, summary transitions |
| `{motion.duration-emphasis}` | 400ms | Important large reveal or a showcase entry |
| `{motion.duration-atmosphere}` | 700ms | Rare, non-blocking background dim/atmospheric introduction |

Use productive easing for most actions. Use expressive easing only when the larger visual event earns it. No elastic bounce or spring overshoot by default.

**Easing assignment.** Use *standard* when an element stays visible, *enter* when it arrives, and *exit* when it leaves for good. Panels that leave but stay nearby (drawers, the summary rail) use *standard*, per Carbon. Exits run one step shorter than entrances.

| Event | Duration | Easing |
|---|---|---|
| Press feedback | instant | productive-standard |
| Hover, focus, chip toggle | quick | productive-standard |
| Selection border, row emphasis, results crossfade | short | productive-standard |
| Tooltip in / out | short / quick | productive-enter / productive-exit |
| Menu, popover, toast in / out | standard / short | productive-enter / productive-exit |
| Modal in / out | standard / short | productive-enter / productive-exit |
| Drawer, summary rail open / close | standard | productive-standard |
| Page content swap | short–standard | productive-standard |
| Hero reveal, completed-build reveal | emphasis | expressive-enter |
| Showcase element leaving | standard | expressive-exit |
| Atmospheric fade-in (once) | atmosphere | expressive-enter |

### Interaction choreography

**Part-card hover (productive):** 110–150ms border/surface emphasis. If the card is a primary clickable target, an optional tiny upward transform (maximum 2px) is permitted in roomy grids, but *not* in tightly packed comparison tables.

**Part selected (productive):** respond instantly to the action. Over 150–240ms, show the selected border/state and update the build summary. The card itself should remain at a stable size. Never postpone the actual data update until animation completes.

**Build-summary update (productive):** update price, part name, and status together from the same current data state. A 110–240ms soft crossfade or small local position transition can clarify the change. Do not animate each digit for several seconds or imply unverified totals.

**Compatibility feedback (productive):** show labeled state immediately. A short 150–240ms local transition may emphasize a changed row. Confirmed errors must remain visible after animation; no red flashing, shaking, or repeated pulses.

**Filters/search (productive):** focus states at 110ms; updated results may crossfade modestly (150ms) only if it does not interrupt keyboard navigation or scrolling. Prevent results and buttons from jumping unexpectedly.

**Menus, tooltips, popovers (productive):** 110–240ms fade with a small 4–8px translation where useful; avoid scaling from zero. Preserve sensible placement and focus throughout.

**Page transitions (productive):** 150–240ms, optional slight fade/translation of *nonpersistent* content; navigation, headings and key controls should feel stable. Do not force full-screen page wipe animations for every builder step.

**Hero / feature showcase (expressive):** a restrained 240–400ms staged reveal of heading and real product visual, with optional slowly settling violet/magenta atmospheric glow (up to 700ms, once on entry). No infinite marquee of effects competing with the CTA. The first meaningful content must not depend on the animation finishing.

**Completed-build reveal (expressive):** an optional single 400ms coordinated transition bringing the selected components into an attractive review composition; preserve exact component identity and data. Provide an immediate, static equivalent.

### Signature RigWorks moments

These are **project-specific interaction patterns**, constrained by the source-based visual and motion systems. They are not claims about Linear, Raycast or Framer.

- **Part-detail reveal:** when opening a real part inspector, preserve the image and title as continuous visual anchors while details appear over 240–400ms. A simple slide/fade is preferable to a fragile shared-element animation if layouts or image dimensions differ.
- **Part-to-build handoff:** after selecting a component, the source card registers selection immediately and its corresponding summary slot receives a brief, coordinated 150–240ms reveal. An optional restrained image handoff is allowed only when it is smooth, accurate, and does not shift surrounding rows.
- **Finished-build composition:** on the dedicated build-review surface, real selected components may assemble into a unified product presentation once (400ms). No fabricated 3D representation, no looping celebration, and no dependency on motion for comprehending the result.

**Productive signatures.** These repeat many times per session, so each finishes within 240ms and never delays data.

- **Slot fill:** the new content in the summary slot enters with opacity 0→1 and translateY 4px→0 (short, productive-enter). The slot border fades from `primary-highlight` back to `hairline` over standard. The price total updates in the same frame.
- **Selection mark:** the check icon enters with opacity and scale 0.8→1 (short, productive-enter). No overshoot, and never from scale 0.
- **Compatibility change:** the label, icon and tint switch with the data. The row may fade in its new tint over short. Persistent states (incompatible, conditional) keep their tint; nothing flashes or pulses.
- **Power bar:** the fill is a full-width element scaled with `transform: scaleX(load / capacity)` from the left (standard, productive-standard). The state label changes immediately, not when the bar arrives.
- **Price change:** crossfade old and new values (quick), with an optional 4px offset in the direction of change. No counting animation.
- **Stagger:** only on first render of 8 or fewer items (summary slots, the first row of results). Steps of 30ms, adding no more than 240ms in total. Never on filter or sort updates.
- **Part-detail reveal:** a shared-element transition for the image/title anchor is preferred when the source and target image dimensions match; otherwise use the simple slide/fade.

**Reduced motion:** every item above becomes an instant state change, except that opacity fades of quick (110ms) or less may stay.

**Coverage rule:** every major interactive state—selection, deselection, panel opening, search result update, save feedback, and compatibility change—needs deliberate visual feedback. Use the relevant productive motion pattern instead of leaving the application entirely static; reduce or eliminate motion when accessibility preferences require it.

### Restraint & sequencing

- Animate **one focal event at a time**. Never stagger every row in a 100-item results list.
- Keep interaction-to-feedback immediate; animation follows state, not the other way around.
- Never loop decorative effects behind controls, tables, forms or technical explanations.
- Avoid parallax, cursor-following light fields, giant bouncing cards, forced scroll animation, auto-rotating 3D products, and long full-screen transitions.
- Use subtle hover changes consistently rather than different choreography for every card type.

### Performance & accessibility

- Prefer `transform` and `opacity` for movement and fades; avoid animating `top`, `left`, width, height, large shadows or expensive blur across many elements. Use browser profiling rather than assuming an effect is fast.
- Do not add `will-change` to every component. Use it sparingly when measured performance warrants it.
- Respect `prefers-reduced-motion: reduce`: remove decorative motion, large translations, zoom, parallax and automated atmospheric movement. Important state changes remain instant or use a minimal non-spatial change.
- Motion must never be the only indicator of a change. Use text, shape and state labels in addition to color or animation.
- Keep the UI functional on mid-range laptops and phones. If an effect harms scrolling, input latency, or responsiveness, reduce or remove the effect before sacrificing usability.
- Animation library choices are made in CLAUDE.md. Whatever implements motion must use these tokens and honour the reduced-motion rule. Do not introduce a 3D engine for decoration.

## Responsive Behavior

| Range | Layout intention |
|---|---|
| ≥1440px | Comfortable desktop builder, optional persistent summary rail |
| 1024–1439px | Compact multi-column layout if real content fits; otherwise collapse filters |
| 768–1023px | Main catalog emphasized; secondary panels become tabs/drawers |
| <768px | Single main column, discoverable build summary, full-width controls where needed |
| <480px | Reduce hero display scale, stack card actions, prioritize critical specs |

These are layout **guides**, not a mandate to implement brittle device categories. Breakpoints should respond to content constraints. Marketing card grids can follow Linear's broad 3 → 2 → 1 pattern.

- Display type scales down to approximately 34–36px on the narrowest screens; app text remains readable rather than artificially shrinking.
- Touch controls must remain operable without hover. Target roughly 44px for common tap areas.
- On coarse pointers, controls drawn smaller than 44px (chips, quiet buttons, row actions) extend their hit area to 44×44px without changing their visual size.
- Dense comparison data should use a deliberate narrow-screen pattern (horizontal scrolling with clearly visible column identity, or one-part-at-a-time comparison), not unreadably small fonts.
- Keep product images contained and avoid cropping essential detail at each breakpoint.
- Hover enhancements are optional; selected, active, and focus states are **not** optional.

## Accessibility & Content Integrity

- Aim for WCAG AA readability: normal text ≥4.5:1 and essential non-text indicators ≥3:1. The primary lavender fill with white text is suitable (4.70:1), but `{colors.primary-highlight}` must **not** become a white-text fill, and `{colors.primary}` is not a text colour; links use `{colors.link}`.
- Keep readable labels, keyboard focus order, accessible names, form error text and screen-reader announcements for consequential changes.
- Semantic statuses must be expressed in words, not only icons, hue, or motion.
- Do not render unsupported claims of compatibility, price, availability or performance as visually authoritative. If the data is unavailable, design the unknown/partial state explicitly.
- Icons should come from a coherent icon set with consistent stroke treatment. Decorative 3D/gradient imagery should not pretend to communicate verified hardware properties.
- UI copy is English. Labels, buttons and table cells must survive long strings (part names, user-named builds) without clipping.

## Do's and Don'ts

### Do

- Start every screen with Linear's near-black canvas, readable text hierarchy and tonal surface ladder.
- Keep the primary lavender accent scarce and meaningful.
- Treat hardware imagery and authentic interface previews as the visual center.
- Borrow Raycast's command/search clarity, keyboard hints and understated active rows when relevant.
- Reserve Framer-style atmospheric gradients for an occasional showcase moment.
- Use Carbon-based concise motion timings; make repeated configurator work feel instantaneous.
- Show clear compatibility reasoning and distinguish *unknown* from *valid*.
- Build reusable variants from the named components and tokens above.

### Don't

- Turn the whole site into a glowing violet gradient, or mix unrelated saturated accents.
- Build a generic dashboard made of huge, identical rounded metric cards.
- Copy Linear/Raycast/Framer logos, proprietary fonts, brand illustrations or page layouts verbatim.
- Use animations to conceal loading, delay component selection, or repeatedly celebrate basic actions.
- Override accessibility focus, text contrast, semantics or reduced-motion settings for aesthetics.
- Infer technical facts from decorative imagery or pretend missing data has been validated.
- Overwrite these deliberate design rules with a component library's default theme.

## Implementation & Iteration Guide

1. Treat this file as the visual specification. If an implementation choice conflicts with a token or explicit rule, follow the rule unless a concrete accessibility or usability issue requires adaptation.
2. Build tokens first, then shared buttons/fields/cards, then page-specific layouts. Do not duplicate the same design values in unrelated CSS files.
3. Decide whether a new screen is a *working application surface* or a *showcase*. The former defaults to restrained Linear/Raycast language; the latter may use the limited Framer vocabulary.
4. When adding a component, reuse a named variant or define one consistent new variant. Never generate a different corner radius, purple, shadow or animation on a whim.
5. Verify states: normal, hover, focus, active, disabled, loading, empty, error, conditional and unknown where applicable.
6. Check narrow widths, long part and build names, keyboard operation, visible status labels, reduced-motion mode and contrast.
7. Profile nontrivial effects on real hardware. If motion causes visible dropped frames or input lag, simplify it.
8. Keep content density intentional. Visual polish does not justify hiding essential specifications or compatibility rationale.

## Known Gaps & Boundaries

- The **underlying visual tokens** are predominantly from Linear; Raycast/Framer patterns are selective. This is a designed synthesis, **not** a claimed extraction of a live RigWorks UI.
- The exact layout for every future feature is not dictated here. New pages should derive their styling from these foundations rather than introducing another visual language.
- Custom logo, icon, imagery library, illustration assets, chart palette and any true 3D hardware viewer have not been chosen; do not fabricate them as if already approved.
- Source documents predominantly analyze **marketing pages**. RigWorks-specific configurator controls and their choreography are explicitly derived adaptations, not source-company components.
- **RigWorks decisions added in v1.1** (not taken from any source document, chosen and contrast-checked for this project): `primary-pressed` #4c57b8; the link and focus-ring role for #828fff; `control-border`; the 14% semantic tints; the overlay opacity; both `elevation` shadows; the 24%/12% spotlight caps; the interaction-state model; the easing-assignment table (it applies Carbon's standard/enter/exit rule, but the event mapping is RigWorks'); the productive signature motions and the 30ms stagger; and the em-based tracking. Revise them through the same process as any other token.
- Some component fields are descriptions rather than values (for example `selectionMark`, `indicator`, `track`, `fill`). They tell implementers what to build; they are not machine-readable tokens.
- This file defines appearance and interaction behavior, **not** compatibility algorithms, application architecture, feature completion, or test assertions. Those belong in product specifications and engineering documentation.
