import { readFile, writeFile } from 'node:fs/promises'
import { fileURLToPath } from 'node:url'
import { parse } from 'yaml'

const source = await readFile(new URL('../../.claude/DESIGN.md', import.meta.url), 'utf8')
const frontMatter = source.match(/^---\r?\n([\s\S]*?)\r?\n---/)
if (!frontMatter) throw new Error('DESIGN.md must contain YAML front matter.')
const design = parse(frontMatter[1])
const kebab = (name) => name.replace(/[A-Z]/g, (letter) => `-${letter.toLowerCase()}`)
const declarations = []
const families = { Inter: '{fonts.ui}', Archivo: '{fonts.display}', 'JetBrains Mono': '{fonts.mono}' }

function valueToCss(value) {
  return String(value).replace(/\{([^}]+)\}/g, (_, path) => `var(--${path.split('.').map(kebab).join('-')})`)
}

function flatten(value, path = []) {
  for (const [key, child] of Object.entries(value)) {
    const next = [...path, kebab(key)]
    if (typeof child === 'object' && child !== null) flatten(child, next)
    else if (typeof child === 'string' || typeof child === 'number') {
      const actual = key === 'fontFamily' ? (families[child] ?? child) : child
      declarations.push(`  --${next.join('-')}: ${valueToCss(actual)};`)
    }
  }
}

// Component metadata containing prose is intentionally not emitted as CSS.
for (const group of ['colors', 'fonts', 'typography', 'rounded', 'spacing', 'elevation', 'motion']) {
  flatten(design[group], [group])
}
for (const [name, component] of Object.entries(design.components)) {
  const values = Object.fromEntries(Object.entries(component).filter(([key]) =>
    ['padding', 'minHeight', 'height', 'size'].includes(key)))
  flatten(values, ['components', name])
}

const css = `/* Generated from .claude/DESIGN.md. Run npm run tokens:generate. */\n:root {\n${declarations.join('\n')}\n}\n`
const seconds = (key) => Number.parseFloat(design.motion[key]) / 1000
const bezier = (key) => design.motion[key].match(/[\d.]+/g).map(Number)
const motion = {
  duration: Object.fromEntries(['instant', 'quick', 'short', 'standard', 'emphasis', 'atmosphere']
    .map((key) => [key, seconds(`duration-${key}`)])),
  easing: Object.fromEntries(['productive-standard', 'productive-enter', 'productive-exit',
    'expressive-standard', 'expressive-enter', 'expressive-exit'].map((key) =>
    [key.replace(/-([a-z])/g, (_, letter) => letter.toUpperCase()), bezier(`easing-${key}`)])),
}
const ts = `// Generated from .claude/DESIGN.md. Run npm run tokens:generate.\nexport const motionTokens = ${JSON.stringify(motion, null, 2)} as const\n`
for (const [relative, content] of [['../src/styles/tokens.css', css], ['../src/lib/motion.ts', ts]]) {
  const path = new URL(relative, import.meta.url)
  if (process.argv.includes('--check')) {
    if (await readFile(path, 'utf8') !== content) throw new Error(`Regenerate ${fileURLToPath(path)}`)
  } else {
    await writeFile(path, content)
  }
}
