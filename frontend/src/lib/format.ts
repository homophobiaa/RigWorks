export const FORMAT_LOCALE = 'en-IE'

const numberFormatter = new Intl.NumberFormat(FORMAT_LOCALE)
const priceFormatter = new Intl.NumberFormat(FORMAT_LOCALE, {
  style: 'currency',
  currency: 'EUR',
})

export const formatNumber = (value: number) => numberFormatter.format(value)
export const formatPrice = (value: number) => priceFormatter.format(value)
export const formatUnit = (value: number, unit: Intl.NumberFormatOptions['unit']) =>
  new Intl.NumberFormat(FORMAT_LOCALE, { style: 'unit', unit }).format(value)
